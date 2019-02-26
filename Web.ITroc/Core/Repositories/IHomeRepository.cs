using System.Collections.Generic;
using Web.ITroc.Core.ViewModels;

namespace Web.ITroc.Core.Repositories
{
    public interface IHomeRepository
    {
        IEnumerable<AdsToIndexViewModel> GetAllAdsToIndex();
        IEnumerable<AdsToIndexViewModel> GetUsersAdsToIndex(string userId);
    }
}