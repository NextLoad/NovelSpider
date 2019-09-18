using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NovelSpider.Crawler.IService.DatabaseIServices.FCCS;
using SpiderForFCSS.Model;

namespace NovelSpider.Crawler.Service.DatabaseServices.FCCS
{
    public class DeveloperService : IDeveloperService
    {
        public long AddNew(string name)
        {
            if (IsExists(name))
            {
                throw new Exception($"已存在的开发商{name}");
            }
            Developer developer = new Developer();
            developer.Name = name;
            using (FCCSDbContext ctx = new FCCSDbContext())
            {
                ctx.Developers.Add(developer);
                ctx.SaveChanges();
            }

            return developer.Id;
        }

        public bool IsExists(string name)
        {
            using (FCCSDbContext ctx = new FCCSDbContext())
            {
                BaseService<Developer> service = new BaseService<Developer>(ctx);
                return service.GetAll().Any(d => d.Name == name);
            }
        }

        public bool IsExists(long id)
        {
            using (FCCSDbContext ctx = new FCCSDbContext())
            {
                BaseService<Developer> service = new BaseService<Developer>(ctx);
                return service.GetAll().Any(d => d.Id == id);
            }
        }

        public long? GetByName(string name)
        {
            using (FCCSDbContext ctx = new FCCSDbContext())
            {
                BaseService<Developer> service = new BaseService<Developer>(ctx);
                var developer = service.GetAll().Where(a => a.Name == name);
                return developer.SingleOrDefault() == null ? null : (long?)developer.SingleOrDefault().Id;
            }
        }
    }
}
