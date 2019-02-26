using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Web.ITroc.Core;
using Web.ITroc.Core.Dtos;
using Web.ITroc.Core.Models;

namespace Web.ITroc.Controllers.api
{
    public class CodepostalController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;


        public CodepostalController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<PostalCodeDto> GetCodepostal(string query = "")
        {
            var postalcode = _unitOfWork.CodepostalApi.GetCpOrVilleByQuery(query);
            //var result = postalcode.Select(x => new PostalCodeDto
            //{
            //    Cp = x.Cp,
            //    Ville = x.Ville
            //});
            return postalcode.Select(Mapper.Map<Codepostal, PostalCodeDto>);
        }


        public IEnumerable<AdsDto> GetAddInfoToModal(int id)
        {

            var singleAd = _unitOfWork.CodepostalApi.GetOneAdFromDb(id);

            return singleAd;
        }


    }
}
