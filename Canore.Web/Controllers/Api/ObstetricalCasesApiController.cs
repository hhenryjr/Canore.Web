using Canore.Web.Domain;
using Canore.Web.Models.ObstetricalCases;
using Canore.Web.Models.Requests.ObstetricalCases;
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
    [RoutePrefix("api/ObCaseForm")]
    public class ObstetricalCasesApiController : ApiController
    {
        //private IObstetricalCasesService _obstetricalCasesService;

        //public ObstetricalCasesApiController(IObstetricalCasesService obstetricalCasesService)
        //{
        //    _obstetricalCasesService = obstetricalCasesService;
        //}

        [Route, HttpPost]
        public HttpResponseMessage AddObstetricalCase(ObstetricalCasesAddRequest model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            //string userId = HttpContext.Current.User.Identity.GetUserId();
            ItemResponse<int> response = new ItemResponse<int>();
            response.Item = ObCasesService.CreateObCase(model);
            return Request.CreateResponse(response);
        }

        [Route("{id:int}"), HttpPut]
        public HttpResponseMessage ModifyObCase(ObstetricalCasesUpdateRequest model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            SuccessResponse response = new SuccessResponse();
            ObCasesService.ModifyObCase(model);
            return Request.CreateResponse(response);
        }

        [Route("{id:int}"), HttpGet]
        public HttpResponseMessage GetObCase(int id)
        {
            ItemResponse<ObCases> response = new ItemResponse<ObCases>();
            response.Item = ObCasesService.GetObCase(id);
            return Request.CreateResponse(response);
        }

        [Route("Hospital/{hospitalId:int}"), HttpGet]
        public HttpResponseMessage GetObCaseByHospital(int hospitalId)
        {
            ItemsResponse<ObCases> response = new ItemsResponse<ObCases>();
            response.Items = ObCasesService.GetObCaseByHospital(hospitalId);
            return Request.CreateResponse(response);
        }

        [Route, HttpGet]
        public HttpResponseMessage GetObCaseList()
        {
            if(!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            ItemsResponse<ObCases> response = new ItemsResponse<ObCases>();
            response.Items = ObCasesService.GetObCaseList();
            return Request.CreateResponse(response);
        }

        [Route("{id:int}"), HttpDelete]
        public HttpResponseMessage DeleteObCase(int id)
        {
            SuccessResponse response = new SuccessResponse();
            ObCasesService.DeleteObCase(id);
            return Request.CreateResponse(response);
        }
    }
}
