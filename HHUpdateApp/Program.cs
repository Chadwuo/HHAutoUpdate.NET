using HHUpdateApp.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
        /// <param name="args">[0]程序名称</param>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //C# Mutex：（互斥锁）线程同步
            //避免程序重复运行
            System.Threading.Mutex mutex = new System.Threading.Mutex(true, "HHUpdateApp_OnlyRunOneInstance", out bool isRuned);
            //第一个参数:true--给调用线程赋予互斥体的初始所属权
            //第一个参数:TQ_WinClient_OnlyRunOneInstance--互斥体的名称
            //第三个参数:返回值isRuned,如果调用线程已被授予互斥体的初始所属权,则返回true

            if (isRuned)
            {
                try
                {
                    if (args.Length == 0)
                    {
                        SettingForm set = new SettingForm();
                        set.ShowDialog();
                    }
                    else
                    {
                        //拉起更新请求的业务程序，稍后更新时，根据这个值关闭对应的进程
                        LaunchAppName = args[0];
                        //检查更新模式：0,自动更新；1，手动检查（区别就是，自动更新的状态下，如果有新版本更新，才会显示提示框）
                        CheckMode = args[1];
                    }

                    /* 
                     * 当前用户是管理员的时候，直接启动应用程序 
                     * 如果不是管理员，则使用启动对象启动程序，以确保使用管理员身份运行 
                     */
                     
                    //获得当前登录的Windows用户标示 
                    System.Security.Principal.WindowsIdentity identity = System.Security.Principal.WindowsIdentity.GetCurrent();
                    System.Security.Principal.WindowsPrincipal principal = new System.Security.Principal.WindowsPrincipal(identity);
                    
                    //判断当前登录用户是否为管理员 
                    if (principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator))
                    {
                        Application.Run(new MainForm(LaunchAppName, CheckMode));
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

                                Arguments = " " + LaunchAppName
                            };
                            //如果不是管理员，则启动UAC 
                            System.Diagnostics.Process.Start(startInfo);
                        }
                        else
                        {
                            Application.Run(new MainForm(LaunchAppName, CheckMode));
                        }
                    }
                }
                catch (Exception ex)
                {
                    HHMessageBox.Show(ex.Message, "错误");
                }
            }
        }

        /// <summary>
        /// 拉起更新请求的业务程序名，稍后更新时，根据这个值关闭对应的进程
        /// </summary>
        public static String LaunchAppName = "";

        /// <summary>
        /// 更新信息的JSON文件所在位置
        /// </summary>
        public static String ServerUpdateUrl = Settings.Default.ServerUpdateUrl;

        /// <summary>
        /// 检查更新模式：0,自动更新；1，手动检查（区别就是，自动更新的状态下，如果有新版本更新，才会显示提示框）
        /// </summary>
        public static String CheckMode = "1";
    }
}
