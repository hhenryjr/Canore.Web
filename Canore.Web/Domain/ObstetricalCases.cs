using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Canore.Web.Domain
{
    public class ObstetricalCases
    {
        public int Id { get; set; }

        public string PatientId { get; set; }

        public int Age { get; set; }

        public int Gravity { get; set; }

        public int Parity { get; set; }

        public string Antepartum { get; set; }

        public string Postpartum { get; set; }

        public string Treatment { get; set; }

        public int BirthWeight { get; set; }

        public string Death { get; set; }

        public int OneMinScore { get; set; }

        public int FiveMinScore { get; set; }

        public int DaysInHospital { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime DateModified { get; set; }
    }
}