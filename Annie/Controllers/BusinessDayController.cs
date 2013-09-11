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
    public class BusinessDayController : Controller
    {
		IManager<BusinessDay> m_Manager = null;
		private Logger m_Logger;
		public BusinessDayController(IManager<BusinessDay> _Manager)
		{
			m_Manager = _Manager;
			m_Logger = LogManager.GetCurrentClassLogger();
		}
        public ActionResult Index()
        {
			try
			{
			var _BusinessDays = (m_Manager as BusinessDayManager).GetAll ();

			return View (_BusinessDays);

			}catch(Exception Ew)
			{
				m_Logger.TraceException(Ew.Message, Ew);
				return null;
			}
        }

		public ActionResult Start()
		{
			try
			{
				var _BusinessDay = new BusinessDay
				{
					BusinessDayId = Guid.NewGuid(),
					StartTime =  DateTime.Now,
					EndTime =  null,
					BusinessDayDate = DateTime.Now.Date,

				};

				var _ValidationErrors = new List<ValidationError>();
				if ((m_Manager as BusinessDayManager).Save(_BusinessDay,_ValidationErrors) )
				{
					return null;
				}
				else
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


		public ActionResult Stop(string Id)
		{
			
			try
			{
				var _BusinessDay = (m_Manager as BusinessDayManager).GetById(Id);

				_BusinessDay.EndTime = DateTime.Now;

				if(_BusinessDay != null)
				{


				var _ValidationErrors = new List<ValidationError>();
				if ((m_Manager as BusinessDayManager).Update(_BusinessDay,_ValidationErrors) )
				{
					return null;
				}
				else
				{
					return null;
				}

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
         public ActionResult Delete(string Id)
		{
			try
			{
				var _ValidationErrors = new List<ValidationError>();

				var _BusinessDay = (m_Manager as BusinessDayManager).GetById(Id);
				if(_BusinessDay == null)
				{
					return null;
				}

				if ( (m_Manager as BusinessDayManager).Delete(_BusinessDay,_ValidationErrors) )
				{
					return null;
				}else
				{
					return null;
				}


			}
			catch(Exception Ew)
			{
				return null;
			}
		}
    }
}