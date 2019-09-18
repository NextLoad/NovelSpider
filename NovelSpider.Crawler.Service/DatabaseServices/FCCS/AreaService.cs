using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NovelSpider.Crawler.IService.DatabaseIServices.FCCS;
using SpiderForFCSS.Model;

namespace NovelSpider.Crawler.Service.DatabaseServices.FCCS
{
    public class AreaService : IAreaService
    {
        public long AddNew(string name, long? parentId)
        {
            using (FCCSDbContext ctx = new FCCSDbContext())
            {
                BaseService<Area> service = new BaseService<Area>(ctx);
                if (IsExists(name))
                {
                    throw new Exception($"已存在name为{name}的区域");
                }
                var area = new Area()
                {
                    Name = name,
                    ParentId = parentId
                };
                ctx.Areas.Add(area);
                ctx.SaveChanges();
                return area.Id;
            }
        }

        public bool IsExists(string name)
        {
            using (FCCSDbContext ctx = new FCCSDbContext())
            {
                BaseService<Area> service = new BaseService<Area>(ctx);
                var area = service.GetAll().Where(a => a.Name == name);
                return area.Any();
            }
        }

        public bool IsExists(long id)
        {
            using (FCCSDbContext ctx = new FCCSDbContext())
            {
                BaseService<Area> service = new BaseService<Area>(ctx);
                var area = service.GetAll().Where(a => a.Id == id);
                return area.Any();
            }
        }

        public long? GetByName(string name)
        {
            using (FCCSDbContext ctx = new FCCSDbContext())
            {
                BaseService<Area> service = new BaseService<Area>(ctx);
                var area = service.GetAll().Where(a => a.Name == name);
                return area.SingleOrDefault() == null ? null: (long?)area.SingleOrDefault().Id;
            }
        }
    }
}
