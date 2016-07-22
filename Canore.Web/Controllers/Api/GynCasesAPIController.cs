using Canore.Web.Domain;
using Canore.Web.Models.Requests.GynCases;
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
    [RoutePrefix("api/GynCaseForm")]
    public class GynCasesApiController : ApiController
    {
        //private IGynCasesService _obstetricalCasesService;

        //public GynCasesApiController(IGynCasesService obstetricalCasesService)
        //{
        //    _obstetricalCasesService = obstetricalCasesService;
        //}

        [Route, HttpPost]
        public HttpResponseMessage AddGynCase(GynCasesAddRequest model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            //string userId = HttpContext.Current.User.Identity.GetUserId();
            ItemResponse<int> response = new ItemResponse<int>();
            response.Item = GynCasesService.CreateGynCase(model);
            return Request.CreateResponse(response);
        }

        [Route("{id:int}"), HttpPut]
        public HttpResponseMessage ModifyGynCase(GynCasesUpdateRequest model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            SuccessResponse response = new SuccessResponse();
            GynCasesService.ModifyGynCase(model);
            return Request.CreateResponse(response);
        }

        [Route("{id:int}"), HttpGet]
        public HttpResponseMessage GetGynCase(int id)
        {
            ItemResponse<GynCases> response = new ItemResponse<GynCases>();
            response.Item = GynCasesService.GetGynCase(id);
            return Request.CreateResponse(response);
        }

        [Route("Hospital/{hospitalId:int}"), HttpGet]
        public HttpResponseMessage GetGynCaseByHospital(int hospitalId)
        {
            ItemsResponse<GynCases> response = new ItemsResponse<GynCases>();
            response.Items = GynCasesService.GetGynCaseByHospital(hospitalId);
            return Request.CreateResponse(response);
        }

        [Route, HttpGet]
        public HttpResponseMessage GetGynCaseList()
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            ItemsResponse<GynCases> response = new ItemsResponse<GynCases>();
            response.Items = GynCasesService.GetGynCaseList();
            return Request.CreateResponse(response);
        }

        [Route("{id:int}"), HttpDelete]
        public HttpResponseMessage DeleteGynCase(int id)
        {
            SuccessResponse response = new SuccessResponse();
            GynCasesService.DeleteGynCase(id);
            return Request.CreateResponse(response);
        }
    }
}
