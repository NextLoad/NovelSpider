using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpiderForFCSS.Model;

namespace NovelSpider.Crawler.Service.EntityConfig.FCCS
{
    public class DeveloperConfig : EntityTypeConfiguration<Developer>
    {
        public DeveloperConfig()
        {
            this.ToTable("T_Developer");
            this.Property(a => a.Name).IsRequired().HasMaxLength(100);
        }
    }
}
