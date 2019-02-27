using System.Collections.Generic;
using System.Threading.Tasks;
using Web.ITroc.Core.Dtos;
using Web.ITroc.Core.Models;

namespace Web.ITroc.Core.Repositories
{
    public interface IApiCollectionRepository
    {
        IEnumerable<Codepostal> GetCpOrVilleByQuery(string query);
        Task<IEnumerable<AdsDto>> GetOneAdFromDb(int id);
    }
}