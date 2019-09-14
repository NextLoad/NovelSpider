using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovelSpider.DTO
{
    public class NovelDTO:BaseDTO
    {
        /// <summary>
        /// 小说名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 小说详情链接
        /// </summary>
        public string DetailLinkPath { get; set; }
        /// <summary>
        /// 小说类别
        /// </summary>
        public string NovelType { get; set; }
        /// <summary>
        /// 小说作者
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// 小说状态
        /// </summary>
        public string NovelStatus { get; set; }
        /// <summary>
        /// 收藏数
        /// </summary>
        public int NumberOfFavorites { get; set; }
        /// <summary>
        /// 全文长度
        /// </summary>
        public int ContentLength { get; set; }
        /// <summary>
        /// 最后更新时间
        /// </summary>
        public DateTime LastUpdateTime { get; set; }
    }
}
