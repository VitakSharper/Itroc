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
        public ICodepostalApiRepository CodepostalApi { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Ads = new AdsRepository(_context);
            Home = new HomeRepository(_context);
            Image = new ImageRepository(_context);
            CodepostalApi = new CodepostalApiRepository(_context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }


    }
}