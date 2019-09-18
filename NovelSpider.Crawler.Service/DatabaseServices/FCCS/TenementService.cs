using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NovelSpider.Crawler.IService.DatabaseIServices.FCCS;
using SpiderForFCSS.Model;

namespace NovelSpider.Crawler.Service.DatabaseServices.FCCS
{
    public class TenementService: ITenementService
    {
        public long AddNew(string name)
        {
            if (IsExists(name))
            {
                throw new Exception($"已存在的物业类型{name}");
            }
            Tenement tenement = new Tenement();
            tenement.Name = name;
            using (FCCSDbContext ctx = new FCCSDbContext())
            {
                ctx.Tenements.Add(tenement);
                ctx.SaveChanges();
            }

            return tenement.Id;
        }

        public bool IsExists(string name)
        {
            using (FCCSDbContext ctx = new FCCSDbContext())
            {
                BaseService<Tenement> service = new BaseService<Tenement>(ctx);
                return service.GetAll().Any(d => d.Name == name);
            }
        }

        public bool IsExists(long id)
        {
            using (FCCSDbContext ctx = new FCCSDbContext())
            {
                BaseService<Tenement> service = new BaseService<Tenement>(ctx);
                return service.GetAll().Any(d => d.Id == id);
            }
        }
        public long? GetByName(string name)
        {
            using (FCCSDbContext ctx = new FCCSDbContext())
            {
                BaseService<Tenement> service = new BaseService<Tenement>(ctx);
                var tenement = service.GetAll().Where(a => a.Name == name);
                return tenement.SingleOrDefault() == null ? null : (long?)tenement.SingleOrDefault().Id;
            }
        }
    }
}
