using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpiderForFCSS.Model;

namespace NovelSpider.Crawler.Service.EntityConfig.FCCS
{
    public class HouseTypeConfig : EntityTypeConfiguration<HouseType>
    {
        public HouseTypeConfig()
        {
            this.ToTable("T_HouseType");
            this.Property(a => a.Name).IsRequired().HasMaxLength(100);
            this.HasRequired(h=>h.RealEstate).WithMany().HasForeignKey(h=>h.RealEstateId).WillCascadeOnDelete(false);
            this.HasRequired(h=>h.Tenement).WithMany().HasForeignKey(h=>h.TenementId).WillCascadeOnDelete(false);
        }
    }
}
