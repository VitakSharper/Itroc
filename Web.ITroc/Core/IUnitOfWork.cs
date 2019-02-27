using Web.ITroc.Core.Repositories;

namespace Web.ITroc.Core
{
    public interface IUnitOfWork
    {
        IAdsRepository Ads { get; }
        IHomeRepository Home { get; }
        IImageRepository Image { get; }
        IApiCollectionRepository ApiCollection { get; }
        void Complete();
    }
}