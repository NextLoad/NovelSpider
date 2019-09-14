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
            this.Property(n => n.DetailLinkPath).HasMaxLength(300);
            this.Property(n => n.Author).HasMaxLength(50);
            this.Property(n => n.NovelStatus).HasMaxLength(50);
            this.Property(n => n.NovelType).HasMaxLength(50);
            this.Property(n => n.Name).HasMaxLength(100);
        }
    }
}
