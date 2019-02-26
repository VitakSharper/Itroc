using System.Collections.Generic;
using Web.ITroc.Core.Models;
using Web.ITroc.Core.ViewModels;

namespace Web.ITroc.Core.Repositories
{
    public interface IAdsRepository
    {
        IEnumerable<Category> GetCategories();
        int? CheckCpVilleIsMatch(AddAnnonceViewModel viewModel);
        void AddAds(Ads ads);
    }
}