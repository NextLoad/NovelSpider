using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpiderForFCSS.Model;

namespace NovelSpider.Crawler.Service.EntityConfig.FCCS
{
    public class AreaConfig : EntityTypeConfiguration<Area>
    {
        public AreaConfig()
        {
            this.ToTable("T_Area");
            this.Property(a => a.Name).IsRequired().HasMaxLength(100);
        }
    }
}
