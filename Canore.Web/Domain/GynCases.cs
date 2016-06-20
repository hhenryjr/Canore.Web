using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Canore.Web.Domain
{
    public class GynCases
    {
        public int Id { get; set; }

        public string PatientID { get; set; }

        public int Age { get; set; }

        public int Gravity { get; set; }

        public int Parity { get; set; }

        public string Admission { get; set; }

        public string Treatment { get; set; }

        public string SurgicalPath { get; set; }

        public int DaysInHospital { get; set; }

        public GynCategories Complication { get; set; }

        public Hospitals Hospital { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime DateModified { get; set; }
    }
}