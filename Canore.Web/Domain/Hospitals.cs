using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Canore.Web.Domain
{
    public class Hospitals
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Abbrev { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public int ZipCode { get; set; }

        public int GynExams { get; set; }

        public int ObExams { get; set; }

        public int Deliveries { get; set; }
    }
}