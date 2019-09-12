using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NovelSpider.Model;

namespace NovelSpider.Crawler.Service
{
    public class NovelDbContext : DbContext
    {
        public NovelDbContext() : base("name=strSql")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Novel> Novels { get; set; }
    }
}
