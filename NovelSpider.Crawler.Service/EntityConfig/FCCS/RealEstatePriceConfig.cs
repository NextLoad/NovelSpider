using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpiderForFCSS.Model;

namespace NovelSpider.Crawler.Service.EntityConfig.FCCS
{
    public class RealEstatePriceConfig:EntityTypeConfiguration<RealEstatePrice>
    {
        public RealEstatePriceConfig()
        {
            this.ToTable("T_RealEstatePrice");
            this.HasRequired(r=>r.RealEstate).WithMany().HasForeignKey(r=>r.RealEstateId).WillCascadeOnDelete(false);
            this.HasOptional(r => r.Tenement).WithMany().HasForeignKey(r=>r.TenementId).WillCascadeOnDelete(false);
            this.Property(r => r.Unit).IsRequired().HasMaxLength(32);
        }
    }
}
