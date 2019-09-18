using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiderForFCCS.BusinessModel
{
    public class HouseModelInfo
    {
        /// <summary>
        /// 户型名称
        /// </summary>
        public string HouseTypeName { get; set; }

        /// <summary>
        /// 物业类型名称
        /// </summary>
        public string TenementName { get; set; }

        /// <summary>
        /// 出售状态
        /// </summary>
        public string HouseTypeStatus { get; set; }

        /// <summary>
        /// 户型描述 几室几厅
        /// </summary>
        public string HouseTypeDesc { get; set; }

        /// <summary>
        /// 面积
        /// </summary>
        public string Area { get; set; }
    }
}
