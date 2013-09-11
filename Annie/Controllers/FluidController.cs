using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BitworkSystem.Annie.BLL;
using BitworkSystem.Annie.BLL.Contract;
using BitworkSystem.Annie.BO;
using NLog;


namespace Annie.Controllers
{
    public class FluidController : Controller
    {
		private IManager<Fluid> m_Manager =  null;
		private Logger m_Logger;

		public FluidController(IManager<Fluid> _Manager)
		{
			m_Manager = _Manager;

			m_Logger = LogManager.GetCurrentClassLogger();

		}
        public ActionResult Index()
        {
			ViewBag.All = (m_Manager as FluidManager).GetAll ();
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
			try
			{
				var _ValidationErrors = new List<ValidationError>();

				if((m_Manager as FluidManager).Save(Fluid,_ValidationErrors) )
				{
				return this.RedirectToAction("Index");
				}else
				{
					return null;
				}

			}
			catch(Exception Ew)
			{
				m_Logger.TraceException(Ew.Message, Ew);
				return null;
			}
		}
		[HttpGet]
		public ActionResult Edit(string Id)
		{
			try
			{
			var _Fluid = (m_Manager as FluidManager).GetById (Id);

			if (_Fluid != null) 
			{
				return View (_Fluid);
			} 
			else 
			{
				return null;
			}

			}catch(Exception Ew)
			{
				m_Logger.TraceException(Ew.Message, Ew);
				return null;
			}
		}

		[HttpPost]
		public ActionResult Edit(Fluid Fluid)
		{
			try
			{
				var _ValidationErrors = new List<ValidationError>();

				if ( (m_Manager as FluidManager).Update(Fluid , _ValidationErrors) ) 
				{
					return RedirectToAction("Index");
				} 
				else 
				{
					return null;
				}

			}catch(Exception Ew)
			{
				m_Logger.TraceException(Ew.Message, Ew);
				return null;
			}
		}
		public ActionResult Details(string Id)
		{
			try
			{
				var _Fluid =  (m_Manager as FluidManager).GetById(Id);
				return View(_Fluid);

			}catch(Exception Ew)
			{
				m_Logger.TraceException(Ew.Message, Ew);
				return null;
			}
		}


		public ActionResult Delete(string Id)
		{
			try
			{
				var _Fluid =  (m_Manager as FluidManager).GetById(Id);
				var _ValidationErrors = new List<ValidationError>();
				if((m_Manager as FluidManager).Delete(_Fluid,_ValidationErrors))
				{
					return RedirectToAction("Index");

				}else
				{
					return RedirectToAction("Index");

				}

			}catch(Exception Ew)
			{
				m_Logger.TraceException(Ew.Message, Ew);
				return null;
			}
		}

    }
}
