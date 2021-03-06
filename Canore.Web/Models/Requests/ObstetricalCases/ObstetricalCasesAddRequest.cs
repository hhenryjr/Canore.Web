﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Canore.Web.Models.ObstetricalCases
{
    public class ObstetricalCasesAddRequest
    {
        [Required]
        [MinLength(5)]
        public string PatientID { get; set; }

        [Required]
        [Range(13,89)]
        public int Age { get; set; }

        [Required]
        public int Gravity { get; set; }

        [Required]
        public int Parity { get; set; }

        [Required]
        public string AntepartumID { get; set; }

        [Required]
        public string PostpartumID { get; set; }

        [Required]
        public string Treatment { get; set; }

        [Required]
        [Range(500, 6000)]
        public int BirthWeight { get; set; }

        [Required]
        public string Death { get; set; }

        [Required]
        public int OneMinScore { get; set; }

        [Required]
        public int FiveMinScore { get; set; }

        [Required]
        public int HospitalID { get; set; }

        [Required]
        public int DaysInHospital { get; set; }

    }
}