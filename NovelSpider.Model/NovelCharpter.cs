using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovelSpider.Model
{
    public class NovelCharpter:BaseModel
    {
        /// <summary>
        /// 小说ID
        /// </summary>
        public long NovelId { get; set; }

        public virtual Novel Novel{ get; set; }
        /// <summary>
        /// 章节
        /// </summary>
        public int CharpterNum { get; set; }

        /// <summary>
        /// 章节链接
        /// </summary>
        public string CharpterLinkPath { get; set; }
    }
}
