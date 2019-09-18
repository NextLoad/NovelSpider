using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpiderForFCSS.Model;

namespace NovelSpider.Crawler.Service.EntityConfig.FCCS
{
    public class RealEstateConfig : EntityTypeConfiguration<RealEstate>
    {
        public RealEstateConfig()
        {
            this.ToTable("T_RealEstate");
            this.Property(a => a.Name).IsRequired().HasMaxLength(100);
            this.Property(a => a.LinkPath).IsRequired().HasMaxLength(100);
            this.Property(a => a.BuildingArea).HasMaxLength(32);
            this.Property(a => a.FloorArea).HasMaxLength(32);
            this.Property(a => a.GreeningRate).HasMaxLength(32);
            this.Property(a => a.PlotRatio).HasMaxLength(32);
            this.Property(a => a.HandoverDate).HasMaxLength(32);
            this.Property(a => a.OpeningDate).HasMaxLength(32);
            this.Property(a => a.HousingStructure).HasMaxLength(32);
            this.Property(a => a.PropertyRightLimit).HasMaxLength(32);
            this.Property(a => a.HouseCount).HasMaxLength(32);
            this.Property(a => a.BuildingCount).HasMaxLength(100);
            this.Property(a => a.SalesHotline).HasMaxLength(200);
            this.Property(a => a.SalesAddress).HasMaxLength(500);
            this.Property(a => a.Address).HasMaxLength(500);
            this.Property(a => a.SalesPermitNumber).HasMaxLength(500);
            this.Property(a => a.Carport).HasMaxLength(100);
            //this.Property(a => a.Introduction).HasMaxLength(1000);
            this.HasRequired(h => h.Area).WithMany().HasForeignKey(h => h.AreaId).WillCascadeOnDelete(false);
            this.HasRequired(h => h.Developer).WithMany().HasForeignKey(h => h.DeveloperId).WillCascadeOnDelete(false);
            this.HasOptional(h => h.TenementCompany).WithMany().HasForeignKey(h => h.TenementCompanyId).WillCascadeOnDelete(false);
        }
    }
}
