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
    public class TankVolumeLoggController : Controller
    {
		private IManager<TankVolumeLogg> m_Manager =  null;
		private Logger m_Logger;


		public TankVolumeLoggController(IManager<TankVolumeLogg> _Manager)
		{
			m_Manager = _Manager;

			m_Logger = LogManager.GetCurrentClassLogger();

		}

		public ActionResult Index()
		{
			ViewBag.All = (m_Manager as TankVolumeLoggManager).GetAll ();
			return View ();
		}

		[HttpGet]
		public ActionResult Create()
		{
			return View ();
		}

		[HttpPost]
		public ActionResult Create(TankVolumeLogg TankVolumeLogg)
		{
			try
			{
				var _ValidationErrors = new List<ValidationError>();

				if((m_Manager as TankVolumeLoggManager).Save(TankVolumeLogg,_ValidationErrors) )
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
				var _TankVolumeLogg = (m_Manager as TankVolumeLoggManager).GetById (Id);

				if (_TankVolumeLogg != null) 
				{
					return View (_TankVolumeLogg);
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
		public ActionResult Edit(TankVolumeLogg TankVolumeLogg)
		{
			try
			{
				var _ValidationErrors = new List<ValidationError>();

				if ( (m_Manager as TankVolumeLoggManager).Update(TankVolumeLogg , _ValidationErrors) ) 
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
				var _TankVolumeLogg =  (m_Manager as TankVolumeLoggManager).GetById(Id);
				return View(_TankVolumeLogg);

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
				var _TankVolumeLogg =  (m_Manager as TankVolumeLoggManager).GetById(Id);
				var _ValidationErrors = new List<ValidationError>();
				if( (m_Manager as TankVolumeLoggManager).Delete(_TankVolumeLogg , _ValidationErrors) )
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