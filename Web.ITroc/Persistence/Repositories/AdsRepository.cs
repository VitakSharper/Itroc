using System.Collections.Generic;
using System.Linq;
using Web.ITroc.Core.Models;
using Web.ITroc.Core.Repositories;
using Web.ITroc.Core.ViewModels;

namespace Web.ITroc.Persistence.Repositories
{
    public class AdsRepository : IAdsRepository
    {
        private readonly ApplicationDbContext _context;

        public AdsRepository(ApplicationDbContext context)
        {
            _context = context;
        }



        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public int? CheckCpVilleIsMatch(AddAnnonceViewModel viewModel)
        {
            return _context.Codepostals.SingleOrDefault(m => m.Cp == viewModel.CodePostal && m.Ville == viewModel.Ville)?.Id;
        }



        public void AddAds(Ads ads)
        {
            _context.Adses.Add(ads);
        }





    }
}