using Canore.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Canore.Web.Controllers
{
    [RoutePrefix("OfficeCases")]
    public class OfficeCasesController : Controller
    {
        // GET: OfficeCases
        [Route("Add")]
        [Route("{id:int}")]
        public ActionResult OfficeCaseForm(int id = 0)
        {
            ItemViewModel<int> model = new ItemViewModel<int>();
            model.Item = id;
            return View(model);
        }

        [Route("Questions")]
        public ActionResult Questions()
        {
            return View();
        }

        [Route]
        public ActionResult OfficeCaseList()
        {
            return View();
        }
    }
}