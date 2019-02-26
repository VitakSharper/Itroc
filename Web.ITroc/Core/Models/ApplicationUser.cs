using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Web.ITroc.Core.Models
{
    public class ApplicationUser : IdentityUser
    {

        public string Adresse { get; set; }
        public string CodePostal { get; set; }
        public string Ville { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }



        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            userIdentity.AddClaim(new Claim("Nom", Nom));
            userIdentity.AddClaim(new Claim("Prenom", Prenom));
            return userIdentity;
        }
    }



}