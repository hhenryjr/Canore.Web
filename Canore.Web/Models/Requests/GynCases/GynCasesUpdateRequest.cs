using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Canore.Web.Models.Requests.GynCases
{
    public class GynCasesUpdateRequest : GynCasesAddRequest
    {
        [Required]
        public int Id { get; set; }
    }
}