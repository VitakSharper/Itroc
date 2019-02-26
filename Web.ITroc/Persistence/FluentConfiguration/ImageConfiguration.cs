using System.Data.Entity.ModelConfiguration;
using Web.ITroc.Core.Models;

namespace Web.ITroc.Persistence.FluentConfiguration
{
    public class ImageConfiguration : EntityTypeConfiguration<Image>
    {
        public ImageConfiguration()
        {
            Property(p => p.FileBase64)
                .IsRequired()
                .IsMaxLength();
            Property(p => p.Poubelle)
                .IsRequired();

        }
    }
}