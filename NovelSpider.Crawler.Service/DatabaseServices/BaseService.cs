using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NovelSpider.Model;
using NovelSpider.Model.EnumModel;

namespace NovelSpider.Crawler.Service.DatabaseServices
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
            return dbContext.Set<T>().Where(t => t.State == DataState.NotDeleted);
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
            item.State = DataState.Deleted;
            return dbContext.SaveChanges();
        }
    }
}
