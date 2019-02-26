using System.Collections.Generic;

namespace Web.ITroc.Core.Models
{
    public class Codepostal
    {
        public int Id { get; set; }

        public string Cp { get; set; }

        public string Ville { get; set; }
        public IList<Ads> Ads { get; set; }
    }
}