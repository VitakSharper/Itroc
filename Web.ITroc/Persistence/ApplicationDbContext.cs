using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using Web.ITroc.Core.Models;
using Web.ITroc.Persistence.FluentConfiguration;

namespace Web.ITroc.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Ads> Adses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Codepostal> Codepostals { get; set; }
        public DbSet<Image> Images { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AdsConfiguration());
            modelBuilder.Configurations.Add(new ApplicationUserConfiguration());
            modelBuilder.Configurations.Add(new ImageConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}