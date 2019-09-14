using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NovelSpider.Framework.Log;
using NovelSpider.Model;

namespace NovelSpider.Crawler.Service
{
    public class NovelDbContext : DbContext
    {
        private Log4NetHelper loger = new Log4NetHelper(typeof(NovelDbContext));
        public NovelDbContext() : base("name=strSql")
        {
            Database.SetInitializer<NovelDbContext>(null);
            this.Database.Log = sql => loger.Debug($"sql执行日志{sql}"); 
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Novel> Novels { get; set; }
        public DbSet<NovelCharpter> NovelCharpters { get; set; }
    }
}
