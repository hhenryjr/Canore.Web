using Canore.Web.Domain;
using Canore.Web.Models.Requests;
using Canore.Web.Models.Responses;
using Canore.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Canore.Web.Controllers.Api
{
    [RoutePrefix("api/UncompCaseForm")]
    public class UncomplicatedCasesAPIController : ApiController
    {
        //private IGynCasesService _obstetricalCasesService;

        //public GynCasesApiController(IGynCasesService obstetricalCasesService)
        //{
        //    _obstetricalCasesService = obstetricalCasesService;
        //}

        [Route, HttpPost]
        public HttpResponseMessage AddUncompCase(UncomplicatedCasesAddRequest model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            //string userId = HttpContext.Current.User.Identity.GetUserId();
            ItemResponse<int> response = new ItemResponse<int>();
            response.Item = UncomplicatedCasesService.CreateUncomplicatedCase(model);
            return Request.CreateResponse(response);
        }

        [Route("Hospital/{hospitalId:int}"), HttpGet]
        public HttpResponseMessage GetCaseByHospital(int hospitalId)
        {
            ItemsResponse<UncomplicatedCases> response = new ItemsResponse<UncomplicatedCases>();
            response.Items = UncomplicatedCasesService.GetCaseByHospital(hospitalId);
            return Request.CreateResponse(response);
        }

    }
}
