using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Web.ITroc.Core;
using Web.ITroc.Core.Dtos;
using Web.ITroc.Core.Models;

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
            //var result = postalcode.Select(x => new PostalCodeDto
            //{
            //    Cp = x.Cp,
            //    Ville = x.Ville
            //});
            return postalcode.Select(Mapper.Map<Codepostal, PostalCodeDto>);
        }


        public async Task<IEnumerable<AdsDto>> GetAdInfoToModal(int id)
        {

            var singleAd = await _unitOfWork.ApiCollection.GetOneAdFromDb(id);

            return singleAd;
        }


    }
}
