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
            response.Item = ObstetricalCasesService.CreateObCase(model);
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
            ObstetricalCasesService.ModifyObCase(model);
            return Request.CreateResponse(response);
        }

        [Route("{id:int}"), HttpGet]
        public HttpResponseMessage GetObCase(int id)
        {
            ItemResponse<ObstetricalCases> response = new ItemResponse<ObstetricalCases>();
            response.Item = ObstetricalCasesService.GetObCase(id);
            return Request.CreateResponse(response);
        }

        [Route, HttpGet]
        public HttpResponseMessage GetObCaseList()
        {
            if(!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            ItemsResponse<ObstetricalCases> response = new ItemsResponse<ObstetricalCases>();
            response.Items = ObstetricalCasesService.GetObCaseList();
            return Request.CreateResponse(response);
        }

        [Route("{id:int}"), HttpDelete]
        public HttpResponseMessage DeleteObCase(int id)
        {
            SuccessResponse response = new SuccessResponse();
            ObstetricalCasesService.DeleteObCase(id);
            return Request.CreateResponse(response);
        }
    }
}
