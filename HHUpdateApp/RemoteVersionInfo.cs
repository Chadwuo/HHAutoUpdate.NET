using System;
using System.Collections.Generic;
using System.Text;

namespace HHUpdateApp
{
    /// <summary>
    /// 服务器上版本更新的json文件 实体
    /// </summary>
    public class RemoteVersionInfo
    {
        /// <summary>
        /// 更新后启动的应用程序名
        /// </summary>
        public String ApplicationStart { get; set; }
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
        /// 更新方式：Cover表示覆盖原文件更新，NewInstall表示删除源文件全新安装
        /// </summary>
        public String UpdateMode { get; set; }
        /// <summary>
        /// 更新说明
        /// </summary>
        public String VersionDesc { get; set; }
        /// <summary>
        /// 忽略文件
        /// </summary>
        public String IgnoreFile { get; set; }
    }
}
