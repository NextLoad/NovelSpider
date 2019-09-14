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
    public class NovelCharpterConfig : EntityTypeConfiguration<NovelCharpter>
    {
        public NovelCharpterConfig()
        {
            this.ToTable("T_NovelCharpter");
            this.Property(n => n.CharpterLinkPath).HasMaxLength(300);
            this.HasRequired(n=>n.Novel).WithMany().HasForeignKey(n=>n.NovelId).WillCascadeOnDelete(false);
        }
    }
}
