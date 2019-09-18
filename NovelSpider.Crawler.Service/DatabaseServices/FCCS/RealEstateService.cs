using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using NovelSpider.Crawler.IService.DatabaseIServices.FCCS;
using NovelSpider.Framework.ModelDtoTrans;
using SpiderForFCCS.DTO;
using SpiderForFCSS.Model;

namespace NovelSpider.Crawler.Service.DatabaseServices.FCCS
{
    public class RealEstateService : IRealEstateService
    {
        public long AddNew(RealEstateDTO realEstateDto)
        {
            RealEstate realEstate = ModelDtoTransHelper.DTOToModel<RealEstateDTO, RealEstate>(realEstateDto);
            using (FCCSDbContext ctx = new FCCSDbContext())
            {
                ctx.RealEstates.Add(realEstate);
                ctx.SaveChanges();
            }
            return realEstate.Id;
        }

        public bool IsExistis(string name)
        {
            using (FCCSDbContext ctx = new FCCSDbContext())
            {
                BaseService<RealEstate> service = new BaseService<RealEstate>(ctx);
                return service.GetAll().Any(r => r.Name == name);
            }
        }

        public bool IsExistis(long id)
        {
            using (FCCSDbContext ctx = new FCCSDbContext())
            {
                BaseService<RealEstate> service = new BaseService<RealEstate>(ctx);
                return service.GetAll().Any(r => r.Id == id);
            }
        }

        public long GetByName(string name)
        {
            using (FCCSDbContext ctx = new FCCSDbContext())
            {
                BaseService<RealEstate> service = new BaseService<RealEstate>(ctx);
                var model = service.GetAll().Where(r => r.Name == name).SingleOrDefault();
                if (model == null)
                {
                    throw new Exception($"不存在的楼盘{name}");
                }
                return model.Id;
            }
        }

        public bool UpdateEstate(long id, string linkPath)
        {
            using (FCCSDbContext ctx = new FCCSDbContext())
            {
                BaseService<RealEstate> service = new BaseService<RealEstate>(ctx);
                var model = service.GetById(id);
                model.LinkPath = linkPath;
                ctx.SaveChanges();
            }
            return true;
        }
    }
}
