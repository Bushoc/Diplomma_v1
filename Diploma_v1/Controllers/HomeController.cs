using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Diploma_v1.Controllers
{
	public partial class HomeController : Controller
    {
        //
        // GET: /Home/

		public virtual ActionResult Index()
        {
            return View();
        }

    }
}
