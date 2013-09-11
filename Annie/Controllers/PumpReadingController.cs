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
    public class PumpReadingController : Controller
    {
		private IManager<PumpReading> m_Manager =  null;
		private Logger m_Logger;


		public PumpReadingController(IManager<PumpReading> _Manager)
		{
			m_Manager = _Manager;

			m_Logger = LogManager.GetCurrentClassLogger();

		}

		public ActionResult Index()
		{
			ViewBag.All = (m_Manager as PumpReadingManager).GetAll ();
			return View ();
		}

		[HttpGet]
		public ActionResult Create()
		{
			return View ();
		}

		[HttpPost]
		public ActionResult Create(PumpReading PumpReading)
		{
			try
			{
				var _ValidationErrors = new List<ValidationError>();

				if((m_Manager as PumpReadingManager).Save(PumpReading,_ValidationErrors) )
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
				var _PumpReading = (m_Manager as PumpReadingManager).GetById (Id);

				if (_PumpReading != null) 
				{
					return View (_PumpReading);
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
		public ActionResult Edit(PumpReading PumpReading)
		{
			try
			{
				var _ValidationErrors = new List<ValidationError>();

				if ( (m_Manager as PumpReadingManager).Update(PumpReading , _ValidationErrors) ) 
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
				var _PumpReading =  (m_Manager as PumpReadingManager).GetById(Id);
				return View(_PumpReading);

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
				var _PumpReading =  (m_Manager as PumpReadingManager).GetById(Id);
				var _ValidationErrors = new List<ValidationError>();
				if((m_Manager as PumpReadingManager).Delete(_PumpReading,_ValidationErrors))
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
