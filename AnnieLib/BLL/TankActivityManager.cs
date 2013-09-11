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
    public class TankActivityManager : IManager<TankActivity>
    {
		IRepository<TankActivity> m_Repository;
		private Logger m_Logger;
		public TankActivityManager(IRepository<TankActivity> Repository)
		{

			m_Repository = Repository;
			m_Logger = LogManager.GetCurrentClassLogger();
		}
		public bool Save(TankActivity TankActivity ,List<ValidationError> _ValidationErrors)
		{
			try
			{

				if(_ValidationErrors == null)
				{
					_ValidationErrors = new List<ValidationError>();

				}
				if(TankActivity == null)
				{
					_ValidationErrors.Add(new ValidationError{ErrorCode = ErrorCode.NullObject, ErrorMessage = " TankActivity Object not Set" });
					return false;
				}
				if (this.Validate(_T:TankActivity,_ValidationErrors:_ValidationErrors))
				{
					return false;
				}else
				{

					return m_Repository.Save(TankActivity);

				}

			}
			catch (Exception Ew)
			{
				m_Logger.TraceException(Ew.Message, Ew);
				return false;
			}
		}


		public IQueryable<TankActivity> GetAll()
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
		public TankActivity GetById(string Id)
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

		public bool Update(TankActivity TankActivity,List<ValidationError> _ValidationErrors){

			try
			{

				if(_ValidationErrors == null)
				{
					_ValidationErrors = new List<ValidationError>();

				}
				if(TankActivity == null)
				{
					_ValidationErrors.Add(new ValidationError{ErrorCode = ErrorCode.NullObject, ErrorMessage = " TankActivity Object not Set" });
					return false;
				}
				if (this.Validate(_T:TankActivity,_ValidationErrors:_ValidationErrors))
				{
					return false;
				}else
				{

					return m_Repository.Update(TankActivity);

				}

			}
			catch (Exception Ew)
			{
				m_Logger.TraceException(Ew.Message, Ew);
				return false;
			}


		}

		public bool Delete(TankActivity _T,List<ValidationError> _ValidationErrors)
		{

			try
			{

				if(_ValidationErrors == null)
				{
					_ValidationErrors = new List<ValidationError>();

				}
				if(_T == null)
				{
					_ValidationErrors.Add(new ValidationError{ErrorCode = ErrorCode.NullObject, ErrorMessage = " TankActivity Object not Set" });
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



		public	bool Validate(List<ValidationError> _ValidationErrors,TankActivity _T )
		{
			return false;
		}

    }
}
