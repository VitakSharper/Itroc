using Web.ITroc.Core.Models;
using Web.ITroc.Core.Repositories;

namespace Web.ITroc.Persistence.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly ApplicationDbContext _context;

        public ImageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddImage(Image image)
        {
            _context.Images.Add(image);
        }
    }
}