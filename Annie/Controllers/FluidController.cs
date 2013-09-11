using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BitworkSystem.Annie.BLL;
using BitworkSystem.Annie.BLL.Contract;
using BitworkSystem.Annie.BO;


namespace Annie.Controllers
{
    public class FluidController : Controller
    {
		private IManager<Fluid> m_Manager =  null;
		public FluidController(IManager<Fluid> _Manager)
		{
			m_Manager = _Manager;

		}
        public ActionResult Index()
        {
            return View ();
        }

		[HttpGet]
		public ActionResult Create()
		{
			return View ();
		}

		[HttpPost]
		public ActionResult Create(Fluid Fluid)
		{
			try{

			}
			catch(Exception Ew)
			{

				return null
			}
		}
		[HttpGet]
		public ActionResult Edit(string Id)
		{

		}

		[HttpPost]
		public ActionResult Edit(Fluid Fluid)
		{

		}
		public ActionResult Details(string Id)
		{
			return View ();
		}

    }
}
