using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace Annie.Controllers
{
	public class HomeController : Controller
	{
		[HttpGet]
		public ActionResult Index ()
		{
			ViewData ["Message"] = "Welcome to ASP.NET MVC on Mono!";
			return View ();
		}
	}
}

