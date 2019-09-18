using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NovelSpider.Crawler.IService.DatabaseIServices.FCCS;
using SpiderForFCSS.Model;

namespace NovelSpider.Crawler.Service.DatabaseServices.FCCS
{
    public class TenementCompanyService : ITenementCompanyService
    {
        public long AddNew(string name)
        {
            if (IsExists(name))
            {
                throw new Exception($"已存在的物业公司{name}");
            }
            TenementCompany tenementCompany = new TenementCompany();
            tenementCompany.Name = name;
            using (FCCSDbContext ctx = new FCCSDbContext())
            {
                ctx.TenementCompanies.Add(tenementCompany);
                ctx.SaveChanges();
            }

            return tenementCompany.Id;
        }

        public bool IsExists(string name)
        {
            using (FCCSDbContext ctx = new FCCSDbContext())
            {
                BaseService<TenementCompany> service = new BaseService<TenementCompany>(ctx);
                return service.GetAll().Any(d => d.Name == name);
            }
        }

        public bool IsExists(long id)
        {
            using (FCCSDbContext ctx = new FCCSDbContext())
            {
                BaseService<TenementCompany> service = new BaseService<TenementCompany>(ctx);
                return service.GetAll().Any(d => d.Id == id);
            }
        }

        public long? GetByName(string name)
        {
            using (FCCSDbContext ctx = new FCCSDbContext())
            {
                BaseService<TenementCompany> service = new BaseService<TenementCompany>(ctx);
                var tenementCompany = service.GetAll().Where(a => a.Name == name);
                return tenementCompany.SingleOrDefault() == null ? null : (long?)tenementCompany.SingleOrDefault().Id;
            }
        }
    }
}
