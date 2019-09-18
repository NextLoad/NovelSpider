using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NovelSpider.Crawler.IService.DatabaseIServices.FCCS;
using SpiderForFCSS.Model;

namespace NovelSpider.Crawler.Service.DatabaseServices.FCCS
{
    public class RealEstatePriceService : IRealEstatePriceService
    {
        public long AddNew(long realEstateId, long? tenementId, double? price, string unit, DateTime recordTime)
        {
            RealEstatePrice realEstatePrice = new RealEstatePrice()
            {
                RealEstateId = realEstateId,
                TenementId = tenementId,
                Price = price,
                Unit = unit,
                RecordTime = recordTime
            };
            using (FCCSDbContext ctx = new FCCSDbContext())
            {
                ctx.RealEstatePrices.Add(realEstatePrice);
                ctx.SaveChanges();
            }

            return realEstatePrice.Id;
        }
    }
}
