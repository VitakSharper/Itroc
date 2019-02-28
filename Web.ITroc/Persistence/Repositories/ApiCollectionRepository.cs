using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Web.ITroc.Core.Dtos;
using Web.ITroc.Core.Models;
using Web.ITroc.Core.Repositories;

namespace Web.ITroc.Persistence.Repositories
{


    public class ApiCollectionRepository : IApiCollectionRepository
    {


        private readonly ApplicationDbContext _context;

        public ApiCollectionRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public IEnumerable<Codepostal> GetCpOrVilleByQuery(string query)
        {
            return _context.Codepostals
                .Where(m => m.Cp.StartsWith(query) || m.Ville.StartsWith(query))
                .ToList();
        }


        public async Task<IEnumerable<AdsDto>> GetOneAdFromDb(int id)
        {
            var resultDbAdses = await _context.Adses
                .Include(m => m.Category)
                .Include(m => m.Images)
                .Include(m => m.Codepostal)
                .Include(m => m.User)
                .Where(m => m.Id == id && m.Poubelle == false)
                .ToListAsync();


            var resultDto = resultDbAdses.Select(x => new AdsDto
            {
                Id = x.Id,
                AdCeate = x.AdCeate,
                AdTitle = x.AdTitle,
                AdDescription = x.AdDescription,
                AdAdresse = x.AdAdresse,
                Category = new CategoryDto { CatName = x.Category.CatName },
                Codepostal = new CodepostalDto { Cp = x.Codepostal.Cp, Ville = x.Codepostal.Ville },
                User = new ApplicationUserDto { CodePostal = x.User.CodePostal, Nom = x.User.Nom, Prenom = x.User.Prenom },
                Images = x.Images.Select(w => w.FileBase64).ToList()
            });



            return resultDto;
        }

    }
}