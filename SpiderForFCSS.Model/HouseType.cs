using System.Collections;
using System.Collections.Generic;
using SpiderForFCSS.Model.EnumModel;

namespace SpiderForFCSS.Model
{
    /// <summary>
    /// 户型实体
    /// </summary>
    public class HouseType : BaseModel
    {
        /// <summary>
        /// 楼盘
        /// </summary>
        public long RealEstateId{ get; set; }
        public virtual RealEstate RealEstate { get; set; }
        /// <summary>
        /// 户型名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 面积
        /// </summary>
        public double Area { get; set; }

        public long TenementId { get; set; }

        /// <summary>
        /// 物业类型
        /// </summary>
        public virtual Tenement Tenement { get; set; } 

        /// <summary>
        /// 室
        /// </summary>
        public int RoomCount { get; set; }

        /// <summary>
        /// 厅
        /// </summary>
        public int HallCount { get; set; }

        /// <summary>
        /// 卫
        /// </summary>
        public int ToiletCount { get; set; }

        /// <summary>
        /// 阳台
        /// </summary>
        public int BalconyCount { get; set; }

        /// <summary>
        /// 出售状态
        /// </summary>
        public HouseTypeStatus Status { get; set; }


    }
}