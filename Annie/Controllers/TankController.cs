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
    public class TankController : Controller
    {
		private IManager<Tank> m_Manager =  null;
		private Logger m_Logger;


		public TankController(IManager<Tank> _Manager)
		{
			m_Manager = _Manager;

			m_Logger = LogManager.GetCurrentClassLogger();

		}

		public ActionResult Index()
		{
			ViewBag.All = (m_Manager as TankManager).GetAll ();
			return View ();
		}

		[HttpGet]
		public ActionResult Create()
		{
			return View ();
		}

		[HttpPost]
		public ActionResult Create(Tank Tank)
		{
			try
			{
				var _ValidationErrors = new List<ValidationError>();

				if((m_Manager as TankManager).Save(Tank,_ValidationErrors) )
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
				var _Tank = (m_Manager as TankManager).GetById (Id);

				if (_Tank != null) 
				{
					return View (_Tank);
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
		public ActionResult Edit(Tank Tank)
		{
			try
			{
				var _ValidationErrors = new List<ValidationError>();

				if ( (m_Manager as TankManager).Update(Tank , _ValidationErrors) ) 
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
				var _Tank =  (m_Manager as TankActivityManager).GetById(Id);
				return View(_Tank);

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
				var _Tank =  (m_Manager as TankManager).GetById(Id);
				var _ValidationErrors = new List<ValidationError>();
				if((m_Manager as TankManager).Delete(_Tank,_ValidationErrors))
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