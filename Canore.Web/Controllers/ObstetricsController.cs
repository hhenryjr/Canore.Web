﻿using Canore.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Canore.Web.Controllers
{
    [RoutePrefix("Obstetrics")]
    public class ObstetricsController : Controller
    {
        // GET: Obstetrics
        [Route("Add")]
        [Route("{id:int}/edit")]
        public ActionResult ObCaseForm(int id = 0)
        {
            ItemViewModel<int> model = new ItemViewModel<int>();
            model.Item = id;
            return View(model);
        }

        [Route]
        public ActionResult Questionnaire()
        {
            return View();
        }

        [Route]
        public ActionResult ObCaseFormJQ()
        {
            return View();
        }
    }
}