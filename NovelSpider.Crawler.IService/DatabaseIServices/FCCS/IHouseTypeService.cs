using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpiderForFCCS.DTO;

namespace NovelSpider.Crawler.IService.DatabaseIServices.FCCS
{
    public interface IHouseTypeService
    {
        long AddNew(HouseTypeDTO houseTypeDto);
        bool IsExistis(long realEstateId, long tenementId,string houseTypeName,int roomCount);
    }
}
