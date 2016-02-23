using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Canore.Web.Controllers
{
    public class HospitalsController : Controller
    {
        // GET: Hospitals
        public ActionResult Index()
        {
            return View();
        }
    }
}