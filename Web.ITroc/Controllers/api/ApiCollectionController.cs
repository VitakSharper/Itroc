using AutoMapper;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Web.ITroc.Core;
using Web.ITroc.Core.Dtos;
using Web.ITroc.Core.Models;
using Web.ITroc.Core.ViewModels;

namespace Web.ITroc.Controllers.api
{
	public class ApiCollectionController : ApiController
	{
		private readonly IUnitOfWork _unitOfWork;


		public ApiCollectionController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public IEnumerable<PostalCodeDto> GetCodepostal(string query = "")
		{
			var postalcode = _unitOfWork.ApiCollection.GetCpOrVilleByQuery(query);
			return postalcode.Select(Mapper.Map<Codepostal, PostalCodeDto>);
		}


		public async Task<IEnumerable<AdsDto>> GetAdInfoToModal(int id)
		{
			var singleAd = await _unitOfWork.ApiCollection.GetOneAdFromDb(id);
			return singleAd;
		}

		public async Task<IEnumerable<AdsToIndexViewModel>> GetAllAds()
		{
			return await _unitOfWork.Home.GetAllAdsToIndex();
		}


		[HttpDelete]
		public async Task<IHttpActionResult> RemoveAd(int id)
		{
			var result = await _unitOfWork.ApiCollection.GetAdFromDbByCurentUser(id, User.Identity.GetUserId());

			if (result == null)
				return NotFound();

			await _unitOfWork.AsyncComplete();

			return Ok(id);
		}

	}
}
