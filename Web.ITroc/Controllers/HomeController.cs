using Microsoft.AspNet.Identity;
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



        public ActionResult Index()
        {
            //if (User.Identity.GetFullName() == string.Empty)
            //    return RedirectToAction("LogOffEmptyUser", "Account");
            var results = _unitOfWork.Home.GetAllAdsToIndex();

            return View(results);
        }




        [Authorize]
        public ActionResult UserAds()
        {
            var userId = User.Identity.GetUserId();

            var results = _unitOfWork.Home.GetUsersAdsToIndex(userId);

            return View("Index", results);
        }

    }
}