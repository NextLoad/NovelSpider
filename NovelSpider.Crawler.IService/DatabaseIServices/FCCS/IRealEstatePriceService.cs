using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovelSpider.Crawler.IService.DatabaseIServices.FCCS
{
    public interface IRealEstatePriceService
    {
        long AddNew(long realEstateId, long? tenementId, double? price, string unit, DateTime recordTime);
    }
}
