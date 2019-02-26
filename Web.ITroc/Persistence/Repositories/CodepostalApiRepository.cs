using System.Collections.Generic;
using System.Linq;
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

    }
}