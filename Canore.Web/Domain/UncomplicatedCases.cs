using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Canore.Web.Domain
{
    public class UncomplicatedCases
    {
        public int Id { get; set; }

        public Hospitals Hospital { get; set; }

        public DateTime DateAdded { get; set; }
    }
}