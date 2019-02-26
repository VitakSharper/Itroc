using System.Data.Entity.ModelConfiguration;
using Web.ITroc.Core.Models;

namespace Web.ITroc.Persistence.FluentConfiguration
{
    public class ApplicationUserConfiguration : EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserConfiguration()
        {
            Property(p => p.Adresse)
                .IsRequired()
                .HasMaxLength(255);

            Property(m => m.CodePostal)
                .IsRequired()
                .HasMaxLength(5);

            Property(m => m.Ville)
                .IsRequired()
                .HasMaxLength(50);

            Property(m => m.Nom)
                .IsRequired()
                .HasMaxLength(50);

            Property(m => m.Prenom)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}