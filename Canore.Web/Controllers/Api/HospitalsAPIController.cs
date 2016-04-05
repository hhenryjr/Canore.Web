using Canore.Web.Domain;
using Canore.Web.Models.Requests.Hospitals;
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
    [RoutePrefix("api/Hospitals")]
    public class HospitalsAPIController : ApiController
    {
        [Route, HttpPost]
        public HttpResponseMessage AddHospital(HospitalsAddRequest model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            ItemResponse<int> response = new ItemResponse<int>();
            response.Item = HospitalsService.AddHospital(model);
            return Request.CreateResponse(response);
        }

        [Route("{id:int}"), HttpPut]
        public HttpResponseMessage UpdateHospital(HospitalsUpdateRequest model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            SuccessResponse response = new SuccessResponse();
            HospitalsService.UpdateHopsital(model);
            return Request.CreateResponse(response);
        }

        [Route("{id:int}"), HttpGet]
        public HttpResponseMessage GetHospital(int id)
        {
            ItemResponse<Hospitals> response = new ItemResponse<Hospitals>();
            response.Item = HospitalsService.GetHospital(id);
            return Request.CreateResponse(response);
        }

        [Route, HttpGet]
        public HttpResponseMessage GetHospitalList()
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            ItemsResponse<Hospitals> response = new ItemsResponse<Hospitals>();
            response.Items = HospitalsService.GetHospitalList();
            return Request.CreateResponse(response);
        }

        [Route("{id:int}"), HttpDelete]
        public HttpResponseMessage DeleteHospital(int id)
        {
            SuccessResponse response = new SuccessResponse();
            HospitalsService.DeleteHospital(id);
            return Request.CreateResponse(response);
        }

    }
}
