using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DomainDiploma_v1.Context;

namespace Diploma_v1.Controllers
{
	public partial class HomeController : Controller
    {
        //
        // GET: /Home/

		public virtual ActionResult Index()
        {
            var a = new DiplomaContext();
            var b = a.Alphabets.FirstOrDefault();
            return View();
        }

    }
}
