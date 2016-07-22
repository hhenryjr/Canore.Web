using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Canore.Web.Models.Requests
{
    public class UncomplicatedCasesAddRequest
    {
        [Required]
        public int HospitalID { get; set; }  
    }
}