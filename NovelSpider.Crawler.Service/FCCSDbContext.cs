using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NovelSpider.Framework.Log;
using SpiderForFCSS.Model;

namespace NovelSpider.Crawler.Service
{
    public class FCCSDbContext:DbContext
    {
        private Log4NetHelper loger = new Log4NetHelper(typeof(NovelDbContext));
        public FCCSDbContext() : base("name=strSql")
        {
            Database.SetInitializer<NovelDbContext>(null);
            this.Database.Log = sql => loger.Debug($"sql执行日志{sql}");
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Area> Areas { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<HouseType> HouseTypes { get; set; }
        public DbSet<RealEstate> RealEstates { get; set; }
        public DbSet<RealEstatePrice> RealEstatePrices { get; set; }
        public DbSet<TenementCompany> TenementCompanies { get; set; }
        public DbSet<Tenement> Tenements { get; set; }
    }
}
