using Web.ITroc.Core;
using Web.ITroc.Core.Repositories;
using Web.ITroc.Persistence.Repositories;

namespace Web.ITroc.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IAdsRepository Ads { get; private set; }
        public IHomeRepository Home { get; private set; }
        public IImageRepository Image { get; private set; }
        public IApiCollectionRepository ApiCollection { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Ads = new AdsRepository(_context);
            Home = new HomeRepository(_context);
            Image = new ImageRepository(_context);
            ApiCollection = new ApiCollectionRepository(_context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }


    }
}