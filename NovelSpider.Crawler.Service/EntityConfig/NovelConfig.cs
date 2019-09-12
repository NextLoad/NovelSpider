using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NovelSpider.Model;

namespace NovelSpider.Crawler.Service.EntityConfig
{
    public class NovelConfig: EntityTypeConfiguration<Novel>
    {
        public NovelConfig()
        {
            this.ToTable("T_NovelSpider");
            this.Property(n => n.LinkPath).HasMaxLength(300);
            this.Property(n => n.State).HasMaxLength(2);
        }
    }
}
