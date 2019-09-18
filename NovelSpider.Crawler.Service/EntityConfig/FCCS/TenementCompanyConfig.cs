using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpiderForFCSS.Model;

namespace NovelSpider.Crawler.Service.EntityConfig.FCCS
{
    public class TenementCompanyConfig : EntityTypeConfiguration<TenementCompany>
    {
        public TenementCompanyConfig()
        {
            this.ToTable("T_TenementCompany");
            this.Property(a => a.Name).IsRequired().HasMaxLength(50);
        }
    }
}
