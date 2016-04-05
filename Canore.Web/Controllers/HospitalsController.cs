using Canore.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Canore.Web.Controllers
{
    [RoutePrefix("Hospitals")]
    public class HospitalsController : Controller
    {
        // GET: Hospitals
        [Route("Add")]
        [Route("{id:int}")]
        public ActionResult HospitalForm(int id = 0)
        {
            ItemViewModel<int> model = new ItemViewModel<int>();
            model.Item = id;
            return View(model);
        }

        [Route]
        public ActionResult HospitalList()
        {
            return View();
        }

    }
}