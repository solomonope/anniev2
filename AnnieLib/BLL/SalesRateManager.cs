using BitworkSystem.Annie.BLL.Contract;
using BitworkSystem.Annie.BO;
using BitworkSystem.Annie.DAL.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace BitworkSystem.Annie.BLL
{
    public class SalesRateManager :IManager<SalesRate>
    {
		IRepository<SalesRate> m_Repository;
		private Logger m_Logger;
		public SalesRateManager(IRepository<SalesRate> Repository)
		{

			m_Repository = Repository;
			m_Logger = LogManager.GetCurrentClassLogger();
		}
		public bool Save(SalesRate SalesRate ,List<ValidationError> _ValidationErrors)
		{
			try
			{

				if(_ValidationErrors == null)
				{
					_ValidationErrors = new List<ValidationError>();

				}
				if(SalesRate == null)
				{
					_ValidationErrors.Add(new ValidationError{ErrorCode = ErrorCode.NullObject, ErrorMessage = " SalesRate Object not Set" });
					return false;
				}
				if (this.Validate(_T:SalesRate,_ValidationErrors:_ValidationErrors))
				{
					return false;
				}else
				{

					return m_Repository.Save(SalesRate);

				}

			}
			catch (Exception Ew)
			{
				m_Logger.TraceException(Ew.Message, Ew);
				return false;
			}
		}


		public IQueryable<SalesRate> GetAll()
		{
			try
			{
				return m_Repository.All;
			}
			catch(Exception Ew)
			{
				m_Logger.TraceException(Ew.Message, Ew);
				return null;

			}

		}
		public SalesRate GetById(string Id)
		{
			try
			{
				return m_Repository.GetById(Id);
			}
			catch(Exception Ew)
			{
				m_Logger.TraceException(Ew.Message, Ew);
				return null;
			}

		}

		public bool Update(SalesRate SalesRate,List<ValidationError> _ValidationErrors){

			try
			{

				if(_ValidationErrors == null)
				{
					_ValidationErrors = new List<ValidationError>();

				}
				if(SalesRate == null)
				{
					_ValidationErrors.Add(new ValidationError{ErrorCode = ErrorCode.NullObject, ErrorMessage = " SalesRate Object not Set" });
					return false;
				}
				if (this.Validate(_T:SalesRate,_ValidationErrors:_ValidationErrors))
				{
					return false;
				}else
				{

					return m_Repository.Update(SalesRate);

				}

			}
			catch (Exception Ew)
			{
				m_Logger.TraceException(Ew.Message, Ew);
				return false;
			}


		}

		public bool Delete(SalesRate _T,List<ValidationError> _ValidationErrors)
		{

			try
			{

				if(_ValidationErrors == null)
				{
					_ValidationErrors = new List<ValidationError>();

				}
				if(_T == null)
				{
					_ValidationErrors.Add(new ValidationError{ErrorCode = ErrorCode.NullObject, ErrorMessage = " SalesRate Object not Set" });
					return false;
				}
				if (this.Validate(_T:_T,_ValidationErrors:_ValidationErrors))
				{
					return false;
				}else
				{

					return m_Repository.Delete(_T);

				}

			}
			catch (Exception Ew)
			{
				m_Logger.TraceException(Ew.Message, Ew);
				return false;
			}
		}

		public	bool Validate(List<ValidationError> _ValidationErrors,SalesRate _T )
		{
			return false;
		}
    }
}
