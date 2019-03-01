using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using System.Web.Mvc;
using Web.ITroc.Core;

namespace Web.ITroc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        public async Task<ActionResult> Index()
        {
            //if (User.Identity.GetFullName() == string.Empty)
            //    return RedirectToAction("LogOffEmptyUser", "Account");
            var results = await _unitOfWork.Home.GetAllAdsToIndex();

            return View(results);
        }




        [Authorize]
        public async Task<ActionResult> UserAds()
        {
            var userId = User.Identity.GetUserId();

            var results = await _unitOfWork.Home.GetUsersAdsToIndex(userId);

            return View(results);
        }

    }
}