using SpiderForFCSS.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpiderForFCSS.Model.EnumModel;

namespace NovelSpider.Crawler.Service.DatabaseServices.FCCS
{
    public class BaseService<T> where T:BaseModel
    {
        private DbContext dbContext;
        protected BaseService() { }
        public BaseService(DbContext ctx)
        {
            this.dbContext = ctx;
        }

        public IQueryable<T> GetAll()
        {
            return dbContext.Set<T>().Where(t => t.StateFccs == DataStateFCCS.NotDeleted);
        }

        public T GetById(long id)
        {
            return dbContext.Set<T>().SingleOrDefault(t => t.Id == id);
        }

        public long GetTotalCount()
        {
            return GetAll().LongCount();
        }

        public IQueryable<T> GetPageData(int pageIndex, int pageCount)
        {
            return dbContext.Set<T>().OrderByDescending(t => t.CreateTime).Skip((pageIndex - 1) * pageCount).Take(pageCount);
        }

        public int MarkDeleted(long id)
        {
            var item = GetById(id);
            item.StateFccs = DataStateFCCS.Deleted;
            return dbContext.SaveChanges();
        }
    }
}
