using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiderForFCCS.DTO
{
    /// <summary>
    /// 楼盘价格实体
    /// </summary>
    public class RealEstatePriceDTO:BaseDTO
    {
        /// <summary>
        /// 楼盘
        /// </summary>
        public long RealEstateId { get; set; }

        public string RealEstateName { get; set; }

        /// <summary>
        /// 物业类型（高层，花园洋房等）
        /// </summary>
        public long? TenementId { get; set; }
        public string TenementName { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        public double? Price { get; set; }

        /// <summary>
        /// 价格单位
        /// </summary>
        public string Unit { get; set; } = "元/㎡";

        /// <summary>
        /// 记录时间
        /// </summary>
        public DateTime RecordTime { get; set; }
        
    }
}
