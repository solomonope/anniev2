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
    public class PumpController : Controller
    {
		private IManager<Pump> m_Manager =  null;
		private Logger m_Logger;


		public PumpController(IManager<Pump> _Manager)
		{
			m_Manager = _Manager;

			m_Logger = LogManager.GetCurrentClassLogger();

		}

        public ActionResult Index()
        {
			ViewBag.All = (m_Manager as PumpManager).GetAll ();
            return View ();
        }

		[HttpGet]
		public ActionResult Create()
		{
			return View ();
		}

		[HttpPost]
		public ActionResult Create(Pump Pump)
		{
			try
			{
				var _ValidationErrors = new List<ValidationError>();

				if((m_Manager as PumpManager).Save(Pump,_ValidationErrors) )
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
				var _Pump = (m_Manager as PumpManager).GetById (Id);

				if (_Pump != null) 
				{
					return View (_Pump);
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
		public ActionResult Edit(Pump Pump)
		{
			try
			{
				var _ValidationErrors = new List<ValidationError>();

				if ( (m_Manager as PumpManager).Update(Pump , _ValidationErrors) ) 
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
				var _Pump =  (m_Manager as PumpManager).GetById(Id);
				return View(_Pump);

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
				var _Pump =  (m_Manager as PumpManager).GetById(Id);
				var _ValidationErrors = new List<ValidationError>();
				if((m_Manager as PumpManager).Delete(_Pump,_ValidationErrors))
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
