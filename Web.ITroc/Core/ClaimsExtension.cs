using System.Security.Claims;
using System.Security.Principal;

namespace Web.ITroc.Core
{
    public static class ClaimsExtension
    {
        public static string GetFullName(this IIdentity identity)
        {
            var nom = (((ClaimsIdentity)identity).FindFirst("Nom"));
            var prenom = (((ClaimsIdentity)identity).FindFirst("Prenom"));

            return (nom != null) ? nom.Value + " " + prenom.Value : string.Empty;
        }
    }
}