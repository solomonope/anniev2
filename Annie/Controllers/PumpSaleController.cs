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
    public class PumpSaleController : Controller
    {
		private IManager<PumpSale> m_Manager =  null;
		private Logger m_Logger;


		public PumpSaleController(IManager<PumpSale> _Manager)
		{
			m_Manager = _Manager;

			m_Logger = LogManager.GetCurrentClassLogger();

		}

		public ActionResult Index()
		{
			ViewBag.All = (m_Manager as PumpSaleManager).GetAll ();
			return View ();
		}

		[HttpGet]
		public ActionResult Create()
		{
			return View ();
		}

		[HttpPost]
		public ActionResult Create(PumpSale PumpSale)
		{
			try
			{
				var _ValidationErrors = new List<ValidationError>();

				if((m_Manager as PumpSaleManager).Save(PumpSale,_ValidationErrors) )
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
				var _PumpSale = (m_Manager as PumpSaleManager).GetById (Id);

				if (_PumpSale != null) 
				{
					return View (_PumpSale);
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
		public ActionResult Edit(PumpSale PumpSale)
		{
			try
			{
				var _ValidationErrors = new List<ValidationError>();

				if ( (m_Manager as PumpSaleManager).Update(PumpSale , _ValidationErrors) ) 
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
				var _PumpSale =  (m_Manager as PumpSaleManager).GetById(Id);
				return View(_PumpSale);

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
				var _PumpSale =  (m_Manager as PumpSaleManager).GetById(Id);
				var _ValidationErrors = new List<ValidationError>();
				if((m_Manager as PumpSaleManager).Delete(_PumpSale,_ValidationErrors))
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
