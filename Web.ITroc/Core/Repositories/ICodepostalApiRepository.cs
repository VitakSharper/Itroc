using System.Collections.Generic;
using Web.ITroc.Core.Models;

namespace Web.ITroc.Core.Repositories
{
    public interface ICodepostalApiRepository
    {
        IEnumerable<Codepostal> GetCpOrVilleByQuery(string query);
    }
}