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
    public class StationController : Controller
    {
		private IManager<Station> m_Manager =  null;
		private Logger m_Logger;


		public StationController(IManager<Station> _Manager)
		{
			m_Manager = _Manager;

			m_Logger = LogManager.GetCurrentClassLogger();

		}

		public ActionResult Index()
		{
			ViewBag.All = (m_Manager as StationManager).GetAll ();
			return View ();
		}

		[HttpGet]
		public ActionResult Create()
		{
			return View ();
		}

		[HttpPost]
		public ActionResult Create(Station Station)
		{
			try
			{
				var _ValidationErrors = new List<ValidationError>();

				if((m_Manager as StationManager).Save(Station,_ValidationErrors) )
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
				var _Station = (m_Manager as StationManager).GetById (Id);

				if (_Station != null) 
				{
					return View (_Station);
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
		public ActionResult Edit(Station Station)
		{
			try
			{
				var _ValidationErrors = new List<ValidationError>();

				if ( (m_Manager as StationManager).Update(Station , _ValidationErrors) ) 
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
				var _Station =  (m_Manager as StationManager).GetById(Id);
				return View(_Station);

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
				var _Station =  (m_Manager as StationManager).GetById(Id);
				var _ValidationErrors = new List<ValidationError>();
				if((m_Manager as StationManager).Delete(_Station,_ValidationErrors))
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
