using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cudo.Entities
{
    public class AndroidVersionInfo
    {
        public int Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 版本号
        /// </summary>
        public int VersionCode { get; set; }

        /// <summary>
        /// 版本名称
        /// </summary>
        public string VersionName { get; set; }

        /// <summary>
        /// 下载路径
        /// </summary>
        public string Src { get; set; }

        /// <summary>
        /// 更新说明
        /// </summary>
        public string Introduction { get; set; }
    }
}
