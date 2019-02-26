using Microsoft.AspNet.Identity;
using System;
using System.Web.Mvc;
using Web.ITroc.Core;
using Web.ITroc.Core.Models;
using Web.ITroc.Core.ViewModels;

namespace Web.ITroc.Controllers
{

    public class AdsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;


        public AdsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new AddAnnonceViewModel
            {
                Categories = _unitOfWork.Ads.GetCategories()
            };
            return View(viewModel);
            
        }

        
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddAnnonceViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categories = _unitOfWork.Ads.GetCategories();
                return View("Create", viewModel);
            }

            if (viewModel.PutFileInDb() == "Nok")
            {
                viewModel.Categories = _unitOfWork.Ads.GetCategories();
                return View("Create", viewModel);
            }

            if (_unitOfWork.Ads.CheckCpVilleIsMatch(viewModel) == null)
            {
                viewModel.Categories = _unitOfWork.Ads.GetCategories();
                viewModel.ErrorMess = "Ville ou Code Postal erroné !!!";
                return View("Create", viewModel);
            }


            var newAd = new Ads
            {
                UserId = User.Identity.GetUserId(),
                CategoryId = viewModel.Category,
                AdTitle = viewModel.AdTitle,
                AdDescription = viewModel.AdDescription,
                AdCeate = DateTime.Now,
                CodePostalId = _unitOfWork.Ads.CheckCpVilleIsMatch(viewModel),
                AdAdresse = viewModel.Adresse,
                Poubelle = false,

            };
            _unitOfWork.Ads.AddAds(newAd);
            _unitOfWork.Complete();


            foreach (string file in viewModel.Base64FileFormat)
            {
                var image = new Image
                {
                    AdId = newAd.Id,
                    Poubelle = false,
                    FileBase64 = file
                };
                _unitOfWork.Image.AddImage(image);
            }
            _unitOfWork.Complete();

            return RedirectToAction("UserAds", "Home");
        }

    }
}