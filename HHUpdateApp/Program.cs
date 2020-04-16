using HHUpdateApp.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace HHUpdateApp
{
    static class Program
    {
        /// <summary>
        /// 程序主入口
        /// </summary>
        /// <param name="args">[0]程序名称，[1]静默更新 0：否 1：是 </param>
        [STAThread]
        static void Main(string[] args)
        {
            //避免程序重复运行
            System.Threading.Mutex mutex = new System.Threading.Mutex(true, "HHUpdateApp_OnlyRunOneInstance", out bool isRuned);
            if (isRuned)
            {
                try
                {
                    //拉起更新请求的业务程序，稍后更新时，根据这个值关闭对应的进程
                    string launchAppName = "";
                    if (args.Length > 0)
                    {
                        launchAppName = args[0];
                    }

                    //string silentUpdate = args[1];
                    /* 当前用户是管理员的时候，直接启动应用程序 
                     * 如果不是管理员，则使用启动对象启动程序，以确保使用管理员身份运行 
                     */

                    //获得当前登录的Windows用户标示 
                    System.Security.Principal.WindowsIdentity identity = System.Security.Principal.WindowsIdentity.GetCurrent();
                    //创建Windows用户主题 
                    Application.EnableVisualStyles();
                    System.Security.Principal.WindowsPrincipal principal = new System.Security.Principal.WindowsPrincipal(identity);
                    //判断当前登录用户是否为管理员 
                    if (principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator))
                    {
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new MainForm(launchAppName));
                    }
                    else
                    {
                        string result = Environment.GetEnvironmentVariable("systemdrive");
                        if (AppDomain.CurrentDomain.BaseDirectory.Contains(result))
                        {
                            //创建启动对象 
                            ProcessStartInfo startInfo = new ProcessStartInfo
                            {
                                //设置运行文件 
                                FileName = System.Windows.Forms.Application.ExecutablePath,
                                //设置启动动作,确保以管理员身份运行 
                                Verb = "runas",

                                Arguments = " " + launchAppName
                            };
                            //如果不是管理员，则启动UAC 
                            System.Diagnostics.Process.Start(startInfo);
                        }
                        else
                        {
                            Application.EnableVisualStyles();
                            Application.SetCompatibleTextRenderingDefault(false);
                            Application.Run(new MainForm(launchAppName));
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
