using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Web.ITroc.Core.Repositories;
using Web.ITroc.Core.ViewModels;

namespace Web.ITroc.Persistence.Repositories
{
    public class HomeRepository : IHomeRepository
    {
        private readonly ApplicationDbContext _context;

        public HomeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<List<AdsToIndexViewModel>> GetAllAdsToIndex()
        {

            var result = _context.Adses
                .Include(m => m.Category)
                .Include(m => m.User)
                .Include(m => m.Codepostal)
                .Include(i => i.Images)
                .OrderByDescending(m => m.AdCreate)
                .Select(m => new AdsToIndexViewModel
                {
                    Id = m.Id,
                    AdCreate = m.AdCreate,
                    AdTitle = m.AdTitle,
                    AdDescription = m.AdDescription,
                    PhotoAd = m.Images.Select(i => i.FileBase64).Take(1).FirstOrDefault()
                }).ToListAsync();
            return result;
        }



        public Task<List<AdsToIndexViewModel>> GetUsersAdsToIndex(string userId)
        {
            return _context.Adses
                .Include(m => m.Images)
                .Where(m => m.UserId == userId && m.Poubelle == false)
                .OrderByDescending(m => m.AdCreate)
                .Select(m => new AdsToIndexViewModel
                {
                    Id = m.Id,
                    AdCreate = m.AdCreate,
                    AdTitle = m.AdTitle,
                    AdDescription = m.AdDescription,
                    PhotoAd = m.Images.Select(i => i.FileBase64).Take(1).FirstOrDefault()
                }).ToListAsync();
        }
    }
}