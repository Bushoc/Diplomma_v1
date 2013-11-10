using Diploma_v1.Models;
using DomainDiploma_v1.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Diploma_v1.Controllers
{
    public class SummController : Controller
    {
        //
        // GET: /Summ/

        public ActionResult Index()
        {
            var model = new FFFF();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(FFFF model)
        {
            model.Result = (new CodingSequence(model.Opp1) + new CodingSequence(model.Opp2)).ToString();

            return View(model);
        }

    }
}
