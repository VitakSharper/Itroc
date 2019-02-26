using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Web.ITroc.Core.Dtos;
using Web.ITroc.Core.Models;
using Web.ITroc.Core.Repositories;

namespace Web.ITroc.Persistence.Repositories
{


    public class CodepostalApiRepository : ICodepostalApiRepository
    {


        private readonly ApplicationDbContext _context;

        public CodepostalApiRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public IEnumerable<Codepostal> GetCpOrVilleByQuery(string query)
        {
            return _context.Codepostals
                .Where(m => m.Cp.StartsWith(query) || m.Ville.StartsWith(query))
                .ToList();
        }


        public IEnumerable<AdsDto> GetOneAdFromDb(int id)
        {
            var resultDbAdses = _context.Adses
                .Include(m => m.Category)
                .Include(m => m.Images)
                .Include(m => m.Codepostal)
                .Where(m => m.Id == id && m.Poubelle == false)
                .ToList();




            var resultDto = resultDbAdses.Select(x => new AdsDto
            {
                Id = x.Id,
                AdCeate = x.AdCeate,
                AdTitle = x.AdTitle,
                AdDescription = x.AdDescription,
                AdAdresse = x.AdAdresse,
                FileBase64 = x.Images[2],
                Category = new CategoryDto { CatName = x.Category.CatName },
                Codepostal = new CodepostalDto { Cp = x.Codepostal.Cp, Ville = x.Codepostal.Ville }
            });


            return resultDto;
        }

    }
}