using Canore.Web.Domain;
using Canore.Web.Models.Requests.OfficePracticeCases;
using Canore.Web.Models.Responses;
using Canore.Web.Services;
using Canore.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Canore.Web.Controllers.Api
{
    [RoutePrefix("api/OfficePracticeCaseForm")]
    public class OfficePracticeCasesApiController : ApiController
    {
        //private IOfficePracticeCasesService _obstetricalCasesService;

        //public OfficePracticeCasesApiController(IOfficePracticeCasesService obstetricalCasesService)
        //{
        //    _obstetricalCasesService = obstetricalCasesService;
        //}

        [Route, HttpPost]
        public HttpResponseMessage AddOfficePracticeCase(OfficePracticeCasesAddRequest model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            //string userId = HttpContext.Current.User.Identity.GetUserId();
            ItemResponse<int> response = new ItemResponse<int>();
            response.Item = OfficePracticeCasesService.CreateOfficePracticeCase(model);
            return Request.CreateResponse(response);
        }

        [Route("{id:int}"), HttpPut]
        public HttpResponseMessage ModifyOfficePracticeCase(OfficePracticeCasesUpdateRequest model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            SuccessResponse response = new SuccessResponse();
            OfficePracticeCasesService.ModifyOfficePracticeCase(model);
            return Request.CreateResponse(response);
        }

        [Route("{id:int}"), HttpGet]
        public HttpResponseMessage GetOfficePracticeCase(int id)
        {
            ItemResponse<OfficePracticeCases> response = new ItemResponse<OfficePracticeCases>();
            response.Item = OfficePracticeCasesService.GetOfficePracticeCase(id);
            return Request.CreateResponse(response);
        }

        [Route, HttpGet]
        public HttpResponseMessage GetOfficePracticeCaseList()
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            ItemsResponse<OfficePracticeCases> response = new ItemsResponse<OfficePracticeCases>();
            response.Items = OfficePracticeCasesService.GetOfficePracticeCaseList();
            return Request.CreateResponse(response);
        }

        [Route("{id:int}"), HttpDelete]
        public HttpResponseMessage DeleteOfficePracticeCase(int id)
        {
            SuccessResponse response = new SuccessResponse();
            OfficePracticeCasesService.DeleteOfficePracticeCase(id);
            return Request.CreateResponse(response);
        }
    }
}
