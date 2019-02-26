using System.Collections.Generic;

namespace Web.ITroc.Core.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string CatName { get; set; }
        public IList<Ads> Ads { get; set; }
    }
}