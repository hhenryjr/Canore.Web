using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Canore.Web.Models.Responses
{
    public class SuccessResponse : BaseResponse
    {
        public SuccessResponse()
        {
            IsSuccessFull = true;
        }
    }
}