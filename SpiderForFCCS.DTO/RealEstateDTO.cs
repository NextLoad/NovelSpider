using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiderForFCCS.DTO
{
    /// <summary>
    /// 楼盘实体
    /// </summary>
    public class RealEstateDTO:BaseDTO
    {
        /// <summary>
        /// 楼盘名称
        /// </summary>
        public string Name { get; set; }

        public string LinkPath { get; set; }
        /// <summary>
        /// 物业公司
        /// </summary>
        public long? TenementCompanyId { get; set; }

        public string TenementCompanyName { get; set; }

        /// <summary>
        /// 开发商
        /// </summary>
        public long DeveloperId { get; set; }

        public string DeveloperName{ get; set; }

        /// <summary>
        /// 所属区域
        /// </summary>
        public long AreaId { get; set; }

        public string AreaName{ get; set; }

        /// <summary>
        /// 建筑面积
        /// </summary>
        public string BuildingArea { get; set; }

        /// <summary>
        /// 占地面积
        /// </summary>
        public string FloorArea { get; set; }

        /// <summary>
        /// 绿化率
        /// </summary>
        public string GreeningRate { get; set; }

        /// <summary>
        /// 容积率
        /// </summary>
        public string PlotRatio { get; set; }

        /// <summary>
        /// 交房日期
        /// </summary>
        public string HandoverDate { get; set; }

        /// <summary>
        /// 开盘日期
        /// </summary>
        public string OpeningDate { get; set; }

        /// <summary>
        /// 房屋结构
        /// </summary>
        public string HousingStructure { get; set; }

        /// <summary>
        /// 产权年限
        /// </summary>
        public string PropertyRightLimit { get; set; }

        /// <summary>
        /// 总户数
        /// </summary>
        public string HouseCount { get; set; }
        
        /// <summary>
        /// 总栋数
        /// </summary>
        public string BuildingCount { get; set; }

        /// <summary>
        /// 售楼热线
        /// </summary>
        public string SalesHotline { get; set; }

        /// <summary>
        /// 售楼地址
        /// </summary>
        public string SalesAddress { get; set; }

        /// <summary>
        /// 楼盘地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 售楼许可证号
        /// </summary>
        public string SalesPermitNumber { get; set; }

        /// <summary>
        /// 车库说明
        /// </summary>
        public string Carport { get; set; }

        /// <summary>
        /// 楼盘简介
        /// </summary>
        public string Introduction { get; set; }
    }
}
