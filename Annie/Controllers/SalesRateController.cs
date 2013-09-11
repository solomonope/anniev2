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
    public class SalesRateController : Controller
    {
		private IManager<SalesRate> m_Manager =  null;
		private Logger m_Logger;


		public SalesRateController(IManager<SalesRate> _Manager)
		{
			m_Manager = _Manager;

			m_Logger = LogManager.GetCurrentClassLogger();

		}

		public ActionResult Index()
		{
			ViewBag.All = (m_Manager as SalesRateManager).GetAll ();
			return View ();
		}

		[HttpGet]
		public ActionResult Create()
		{
			return View ();
		}

		[HttpPost]
		public ActionResult Create(SalesRate SalesRate)
		{
			try
			{
				var _ValidationErrors = new List<ValidationError>();

				if((m_Manager as SalesRateManager).Save(SalesRate,_ValidationErrors) )
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
				var _SalesRate = (m_Manager as SalesRateManager).GetById (Id);

				if (_SalesRate != null) 
				{
					return View (_SalesRate);
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
		public ActionResult Edit(SalesRate SalesRate)
		{
			try
			{
				var _ValidationErrors = new List<ValidationError>();

				if ( (m_Manager as SalesRateManager).Update(SalesRate , _ValidationErrors) ) 
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
				var _SalesRate =  (m_Manager as SalesRateManager).GetById(Id);
				return View(_SalesRate);

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
				var _SalesRate =  (m_Manager as SalesRateManager).GetById(Id);
				var _ValidationErrors = new List<ValidationError>();
				if((m_Manager as SalesRateManager).Delete(_SalesRate,_ValidationErrors))
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