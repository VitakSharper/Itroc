using System.Collections.Generic;
using System.Threading.Tasks;
using Web.ITroc.Core.ViewModels;

namespace Web.ITroc.Core.Repositories
{
    public interface IHomeRepository
    {
        Task<List<AdsToIndexViewModel>> GetAllAdsToIndex();
        Task<List<AdsToIndexViewModel>> GetUsersAdsToIndex(string userId);
    }
}