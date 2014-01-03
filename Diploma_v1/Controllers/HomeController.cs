using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DomainDiploma_v1.Context;
using MMPAlphabetGenerator;
using DomainDiploma_v1.Basic;

namespace Diploma_v1.Controllers
{
	public partial class HomeController : Controller
    {
        //
        // GET: /Home/

		public virtual ActionResult Index()
        {
            var counOfLetters = 64;
            var minimalCodingDistance = 6;
            var codeLength = 16;
            var generator = new GenerateManager(codeLength, counOfLetters, minimalCodingDistance);
            generator.WorkOnLevel0();
            var letters = new List<CodingSequence>();
            if (generator.ResultOfGenerating)
            {
                letters = generator.Result.alfavit.ToList();
            }
            return View();
        }

    }
}
