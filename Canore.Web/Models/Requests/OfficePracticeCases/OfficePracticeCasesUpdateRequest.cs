using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Canore.Web.Models.Requests.OfficePracticeCases
{
    public class OfficePracticeCasesUpdateRequest : OfficePracticeCasesAddRequest
    {
        [Required]
        public int Id { get; set; }
    }
}