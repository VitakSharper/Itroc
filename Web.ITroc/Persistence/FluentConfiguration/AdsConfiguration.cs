using System.Data.Entity.ModelConfiguration;
using Web.ITroc.Core.Models;

namespace Web.ITroc.Persistence.FluentConfiguration
{
    public class AdsConfiguration : EntityTypeConfiguration<Ads>
    {
        public AdsConfiguration()
        {
            HasRequired<Category>(s => s.Category)
                .WithMany(g => g.Ads)
                .HasForeignKey(s => s.CategoryId);

            HasRequired<Codepostal>(m => m.Codepostal)
                .WithMany(m => m.Ads)
                .HasForeignKey(f => f.CodePostalId)
                .WillCascadeOnDelete(false);

            HasMany(i => i.Images)
                .WithRequired(a => a.Ads)
                .HasForeignKey(f => f.AdId);


            Property(m => m.AdAdresse)
                .IsRequired()
                .HasMaxLength(255);

            Property(m => m.AdDescription)
                .IsRequired()
                .HasMaxLength(255);

            Property(m => m.AdTitle)
                .IsRequired()
                .HasMaxLength(50);




        }
    }
}