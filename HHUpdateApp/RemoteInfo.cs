using System;
using System.Collections.Generic;
using System.Text;

namespace HHUpdateApp
{
    public class RemoteInfo
    {
        /// <summary>
        /// 更新后启动的应用程序名
        /// </summary>
        public String ApplicationStart { get; set; }
        /// <summary>
        /// 最小版本号
        /// </summary>
        public String MinVersion { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        public String ReleaseDate { get; set; }
        /// <summary>
        /// 发布地址
        /// </summary>
        public String ReleaseUrl { get; set; }
        /// <summary>
        /// 发布版本号
        /// </summary>
        public String ReleaseVersion { get; set; }
        /// <summary>
        /// 更新方式：Cover表示覆盖更新，Increment表示增量更新
        /// </summary>
        public String UpdateMode { get; set; }
        /// <summary>
        /// 更新说明文件的链接地址信息
        /// </summary>
        public String VersionDesc { get; set; }
    }
}
