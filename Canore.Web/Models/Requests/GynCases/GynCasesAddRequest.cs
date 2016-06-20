using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Canore.Web.Models.Requests.GynCases
{
    public class GynCasesAddRequest
    {
        [Required]
        public string PatientID { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public int Gravity { get; set; }

        [Required]
        public int Parity { get; set; }

        [Required]
        public string Admission { get; set; }

        [Required]
        public string Treatment { get; set; }

        [Required]
        public string SurgicalPath { get; set; }

        [Required]
        public int ComplicationsID { get; set; }

        [Required]
        public int DaysInHospital { get; set; }

        [Required]
        public int HospitalID { get; set; }
    }
}