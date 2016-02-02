using Canore.Web.Models.ObstetricalCases;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Canore.Web.Models.Requests.ObstetricalCases
{
    public class ObstetricalCasesUpdateRequest : ObstetricalCasesAddRequest
    {
        [Required]
        public int Id { get; set; }
    }
}