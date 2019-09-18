using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NovelSpider.Crawler.IService.DatabaseIServices.FCCS;
using NovelSpider.Framework.ModelDtoTrans;
using SpiderForFCCS.DTO;
using SpiderForFCSS.Model;

namespace NovelSpider.Crawler.Service.DatabaseServices.FCCS
{
    public class HouseTypeService : IHouseTypeService
    {
        public long AddNew(HouseTypeDTO houseTypeDto)
        {
            HouseType houseType = ModelDtoTransHelper.DTOToModel<HouseTypeDTO, HouseType>(houseTypeDto);
            using (FCCSDbContext ctx = new FCCSDbContext())
            {
                ctx.HouseTypes.Add(houseType);
                ctx.SaveChanges();
            }
            return houseType.Id;
        }

        public bool IsExistis(long realEstateId, long tenementId, string houseTypeName,int roomCount)
        {
            using (FCCSDbContext ctx = new FCCSDbContext())
            {
                BaseService<HouseType> service = new BaseService<HouseType>(ctx);
                return service.GetAll().Any(h => h.RealEstateId == realEstateId && h.TenementId == tenementId && h.Name == houseTypeName && h.RoomCount == roomCount);
            }
        }
    }
}
