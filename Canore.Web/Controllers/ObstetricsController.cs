﻿using System;
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
        [Route]
        public ActionResult ObCaseForm()
        {
            return View();
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