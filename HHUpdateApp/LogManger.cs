using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHUpdateApp
{
    /// <summary>
    /// 系统日志帮助类
    /// </summary>
    internal class LogManger
    {
        /// <summary>
        /// 系统日志实体类
        /// </summary>
        public static ILog Instance = LogManager.GetLogger("SystemLogger");
    }
}
