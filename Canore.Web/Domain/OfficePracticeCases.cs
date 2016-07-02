using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Canore.Web.Domain
{
    public class OfficePracticeCases
    {
        public int Id { get; set; }

        public string PatientID { get; set; }

        public int Age { get; set; }

        public int Gravity { get; set; }

        public int Parity { get; set; }

        public int Visits { get; set; }

        public string Problem { get; set; }

        public string DiagnosticProc { get; set; }

        public OfficeCategories Complication { get; set; }

        public string Treatment { get; set; }

        public string Result { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime DateModified { get; set; }
    }
}
