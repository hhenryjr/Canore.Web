using Canore.Web.Models.ObstetricalCases;
using Canore.Web.Models.Responses;
using Canore.Web.Services;
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
        
        [Route("Add"), HttpPost]
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
    }
}
