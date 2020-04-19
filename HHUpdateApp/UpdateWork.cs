using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Xml;
using Ionic.Zip;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;
using HHUpdateApp.Properties;

namespace HHUpdateApp
{
    public class UpdateWork
    {
        #region 字段
        /// <summary>
        /// 临时目录（WIN7以及以上在C盘只有对于temp目录有操作权限）
        /// </summary>
        string tempPath = Path.Combine(Environment.GetEnvironmentVariable("TEMP"), @"HHUpdateApp\temp\");
        /// <summary>
        /// 备份目录
        /// </summary>
        string bakPath = Path.Combine(Environment.GetEnvironmentVariable("TEMP"), @"HHUpdateApp\bak\");

        /// <summary>
        /// 此更新程序所在目录
        /// </summary>
        private string mainDirectoryName;

        #endregion

        #region 属性
        /// <summary>
        /// 远程服务器上版本更新参数
        /// </summary>
        public RemoteVersionInfo RemoteVerInfo { get; set; }

        /// <summary>
        /// 需要更新的业务应用程序所在目录
        /// </summary>
        public string ProgramDirectoryName { get; set; }

        #endregion

        /// <summary>
        /// 初始化配置目录信息
        /// </summary>
        /// <param name="_programName">需要更新的业务应用程序</param>
        /// <param name="_remoteVerInfo">远程服务器上版本更新参数</param>
        public UpdateWork(string _programDirectoryName, RemoteVersionInfo _remoteVerInfo)
        {
            ProgramDirectoryName = _programDirectoryName;
            RemoteVerInfo = _remoteVerInfo;

            Process cur = Process.GetCurrentProcess();

            mainDirectoryName = Path.GetFileName(Path.GetDirectoryName(cur.MainModule.FileName));

            //创建备份目录信息
            DirectoryInfo bakinfo = new DirectoryInfo(bakPath);
            if (bakinfo.Exists == false)
            {
                bakinfo.Create();
            }
            //创建临时目录信息
            DirectoryInfo tempinfo = new DirectoryInfo(tempPath);
            if (tempinfo.Exists == false)
            {
                tempinfo.Create();
            }
        }

        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public UpdateWork()
        {

        }


        /// <summary>
        /// 业务应用重启
        /// </summary>
        public void AppStart()
        {
            string[] AppStartName = RemoteVerInfo.ApplicationStart.Split('#');
            foreach (var item in AppStartName)
            {
                LogTool.AddLog("更新程序：启动" + item);
                Process.Start(Path.Combine(ProgramDirectoryName, item));
            }
            return;
        }

        /// <summary>
        /// 下载方法
        /// </summary>
        public void DownLoad()
        {
            //从服务器上下载升级文件包
            using (WebClient web = new WebClient())
            {
                try
                {
                    LogTool.AddLog("更新程序：下载更新包文件" + RemoteVerInfo.ReleaseVersion);
                    web.DownloadFile(RemoteVerInfo.ReleaseUrl, tempPath + RemoteVerInfo.ReleaseVersion + ".zip");

                    return;
                }
                catch (Exception ex)
                {
                    LogTool.AddLog("更新程序：更新包文件" + RemoteVerInfo.ReleaseVersion + "下载失败,本次停止更新，异常信息：" + ex.Message);
                    throw ex;
                }

            }
        }

        /// <summary>
        /// 备份当前的程序目录信息
        /// </summary>
        public void Bak()
        {
            try
            {
                LogTool.AddLog("更新程序：准备执行备份操作");
                DirectoryInfo di = new DirectoryInfo(ProgramDirectoryName);
                foreach (var item in di.GetFiles())
                {
                    File.Copy(item.FullName, bakPath + item.Name, true);
                }
                //文件夹复制 
                foreach (var item in di.GetDirectories())
                {
                    //升级程序文件不需要备份
                    if (item.Name != mainDirectoryName)
                    {
                        CopyDirectory(item.FullName, bakPath);
                    }
                }
                LogTool.AddLog("更新程序：备份操作执行完成,开始关闭应用程序");
                return;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update()
        {
            try
            {
                //如果是全新安装的话，先删除原先的所有程序
                if (RemoteVerInfo.UpdateMode == "NewInstall")
                {
                    DelLocal();
                }
                string path = tempPath + RemoteVerInfo.ReleaseVersion + ".zip";
                using (ZipFile zip = new ZipFile(path))
                {
                    LogTool.AddLog("更新程序：解压" + RemoteVerInfo.ReleaseVersion + ".zip");
                    zip.ExtractAll(ProgramDirectoryName, ExtractExistingFileAction.OverwriteSilently);
                    LogTool.AddLog("更新程序：" + RemoteVerInfo.ReleaseVersion + ".zip" + "解压完成");
                }
            }
            catch (Exception ex)
            {
                LogTool.AddLog("更新程序出现异常：异常信息：" + ex.Message);
                LogTool.AddLog("更新程序：更新失败，进行回滚操作");
                Restore();
            }
            finally
            {
                //删除下载的临时文件
                LogTool.AddLog("更新程序：删除临时文件" + RemoteVerInfo.ReleaseVersion);
                DelTempFile(RemoteVerInfo.ReleaseVersion + ".zip");//删除更新包
                LogTool.AddLog("更新程序：临时文件删除完成" + RemoteVerInfo.ReleaseVersion);
            }
        }

        /// <summary>
        /// 文件拷贝
        /// </summary>
        /// <param name="srcdir">源目录</param>
        /// <param name="desdir">目标目录</param>
        private void CopyDirectory(string srcdir, string desdir)
        {
            string folderName = srcdir.Substring(srcdir.LastIndexOf("\\") + 1);

            string desfolderdir = desdir + "\\" + folderName;

            if (desdir.LastIndexOf("\\") == (desdir.Length - 1))
            {
                desfolderdir = desdir + folderName;
            }
            string[] filenames = Directory.GetFileSystemEntries(srcdir);
            foreach (string file in filenames)// 遍历所有的文件和目录
            {
                if (Directory.Exists(file))// 先当作目录处理如果存在这个目录就递归Copy该目录下面的文件
                {
                    string currentdir = desfolderdir + "\\" + file.Substring(file.LastIndexOf("\\") + 1);
                    if (!Directory.Exists(currentdir))
                    {
                        Directory.CreateDirectory(currentdir);
                    }
                    CopyDirectory(file, desfolderdir);
                }
                else // 否则直接copy文件
                {
                    string srcfileName = file.Substring(file.LastIndexOf("\\") + 1);
                    srcfileName = desfolderdir + "\\" + srcfileName;
                    if (!Directory.Exists(desfolderdir))
                    {
                        Directory.CreateDirectory(desfolderdir);
                    }
                    File.Copy(file, srcfileName, true);
                }
            }
            return;
        }


        /// <summary>
        /// 删除临时文件
        /// </summary>
        private void DelTempFile(String name)
        {
            FileInfo file = new FileInfo(tempPath + name);
            file.Delete();
            return;
        }

        /// <summary>
        /// 更新失败的情况下，回滚当前更新
        /// </summary>
        private void Restore()
        {
            DelLocal();
            CopyDirectory(bakPath, ProgramDirectoryName);
            return;
        }

        /// <summary>
        /// 删除本地文件夹的文件
        /// </summary>
        private void DelLocal()
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo(ProgramDirectoryName);
                foreach (var item in di.GetFiles())
                {
                    //判断文件是否是指定忽略的文件
                    if (!RemoteVerInfo.IgnoreFile.Contains(item.Name))
                    {
                        File.Delete(item.FullName);
                    }


                }
                foreach (var item in di.GetDirectories())
                {
                    if (item.Name != mainDirectoryName)
                    {
                        item.Delete(true);
                    }
                }
                return;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

    }
}
