using System;
using System.Web;
using System.Web.Mvc;
using BitworkSystem.Annie.BLL;
using BitworkSystem.Annie.BLL.Contract;
using BitworkSystem.Annie.BO;
using NLog;

namespace Annie
{
	public class AnnieControllerBase : Controller
	{
		IManager<BusinessDay> m_BusinessDayManager;
		BusinessDay m_BusinessDay =  null;
		protected BusinessDay BusinessDay
		{
			get
			{
				return m_BusinessDay;
			}

		}
		public AnnieControllerBase (IManager<BusinessDay> _BusinessDayManager)
		{
			m_BusinessDayManager = _BusinessDayManager; 
			GetTodaysBusinessDay();
		}

		private void GetTodaysBusinessDay()
		{

		}
	}
}

