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
    public class TankReadingController : Controller
    {
		private IManager<TankReading> m_Manager =  null;
		private Logger m_Logger;


		public TankReadingController(IManager<TankReading> _Manager)
		{
			m_Manager = _Manager;

			m_Logger = LogManager.GetCurrentClassLogger();

		}

		public ActionResult Index()
		{
			ViewBag.All = (m_Manager as TankReadingManager).GetAll ();
			return View ();
		}

		[HttpGet]
		public ActionResult Create()
		{
			return View ();
		}

		[HttpPost]
		public ActionResult Create(TankReading TankReading)
		{
			try
			{
				var _ValidationErrors = new List<ValidationError>();

				if((m_Manager as TankReadingManager).Save(TankReading,_ValidationErrors) )
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
				var _TankReading = (m_Manager as TankReadingManager).GetById (Id);

				if (_TankReading != null) 
				{
					return View (_TankReading);
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
		public ActionResult Edit(TankReading TankReading)
		{
			try
			{
				var _ValidationErrors = new List<ValidationError>();

				if ( (m_Manager as TankReadingManager).Update(TankReading , _ValidationErrors) ) 
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
				var _TankReading =  (m_Manager as TankReadingManager).GetById(Id);
				return View(_TankReading);

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
				var _TankReading =  (m_Manager as TankReadingManager).GetById(Id);
				var _ValidationErrors = new List<ValidationError>();
				if((m_Manager as TankReadingManager).Delete(_TankReading,_ValidationErrors))
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