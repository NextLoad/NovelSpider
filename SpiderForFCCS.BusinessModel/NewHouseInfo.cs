using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiderForFCCS.BusinessModel
{
    public class NewHouseInfo
    {
        /// <summary>
        /// 楼盘名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 楼盘详细链接
        /// </summary>
        public string DetailLinkPath { get; set; }

        /// <summary>
        /// 楼盘的价格信息
        /// </summary>
        public IList<string> PriceDic{ get; set; }

        /// <summary>
        /// 楼盘简介信息
        /// </summary>
        public IList<string> BriefList{ get; set; }

        /// <summary>
        /// 楼盘户型信息
        /// </summary>
        public IList<HouseModelInfo> HouseModelInfos { get; set; }

        /// <summary>
        /// 楼盘价格走势
        /// </summary>
        public IList<PriceTrend> PriceTrends { get; set; }
}
}
