using Canore.Web.Domain;
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
    [RoutePrefix("api/Categories")]
    public class CategoriesAPIController : ApiController
    {
        //OBSTETRICAL
        [Route("ObCategory/{id:int}"), HttpGet]
        public HttpResponseMessage GetObCategory(int id)
        {
            ItemResponse<ObCategories> response = new ItemResponse<ObCategories>();
            response.Item = CategoriesService.GetObCategory(id);
            return Request.CreateResponse(response);
        }

        [Route("ObCategories"), HttpGet]
        public HttpResponseMessage GetObCategoryList()
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            ItemsResponse<ObCategories> response = new ItemsResponse<ObCategories>();
            response.Items = CategoriesService.GetObCategoryList();
            return Request.CreateResponse(response);
        }

        //GYNECOLOGICAL
        [Route("GynCategory/{id:int}"), HttpGet]
        public HttpResponseMessage GetGynCategory(int id)
        {
            ItemResponse<GynCategories> response = new ItemResponse<GynCategories>();
            response.Item = CategoriesService.GetGynCategory(id);
            return Request.CreateResponse(response);
        }

        [Route("GynCategories"), HttpGet]
        public HttpResponseMessage GetGynCategoryList()
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            ItemsResponse<GynCategories> response = new ItemsResponse<GynCategories>();
            response.Items = CategoriesService.GetGynCategoryList();
            return Request.CreateResponse(response);
        }
    }
}
