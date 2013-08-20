using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Annie.Controllers
{
    public class TestController : Controller
    {
        public ActionResult Index()
        {
			ViewBag.Me = "Eniola on my Mind";
            return View ();
        }
    }
}
