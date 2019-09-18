using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpiderForFCCS.DTO;

namespace NovelSpider.Crawler.IService.DatabaseIServices.FCCS
{
    public interface IRealEstateService
    {
        long AddNew(RealEstateDTO realEstateDto);
        bool IsExistis(string name);
        bool IsExistis(long id);
        long GetByName(string name);

        bool UpdateEstate(long id, string linkPath);
    }
}
