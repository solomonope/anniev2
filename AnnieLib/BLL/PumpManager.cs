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
    public class PumpManager : IManager<Pump>
    {
        IRepository<Pump> m_Repository;
		private Logger m_Logger;
        public PumpManager(IRepository<Pump> Repository)
        {
            m_Repository = Repository;
			m_Logger = LogManager.GetCurrentClassLogger();
        }

		public bool Save(Pump Pump ,List<ValidationError> _ValidationErrors)
		{
			try
			{

				if(_ValidationErrors == null)
				{
					_ValidationErrors = new List<ValidationError>();

				}
				if(Pump == null)
				{
					_ValidationErrors.Add(new ValidationError{ErrorCode = ErrorCode.NullObject, ErrorMessage = " Pump Object not Set" });
					return false;
				}
				if (this.Validate(_T:Pump,_ValidationErrors:_ValidationErrors))
				{
					return false;
				}else
				{

					return m_Repository.Save(Pump);

				}

			}
			catch (Exception Ew)
			{
				m_Logger.TraceException(Ew.Message, Ew);
				return false;
			}
		}


		public IQueryable<Pump> GetAll()
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
		public Pump GetById(string Id)
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

		public bool Update(Pump Pump,List<ValidationError> _ValidationErrors){

			try
			{

				if(_ValidationErrors == null)
				{
					_ValidationErrors = new List<ValidationError>();

				}
				if(Pump == null)
				{
					_ValidationErrors.Add(new ValidationError{ErrorCode = ErrorCode.NullObject, ErrorMessage = " Pump Object not Set" });
					return false;
				}
				if (this.Validate(_T:Pump,_ValidationErrors:_ValidationErrors))
				{
					return false;
				}else
				{

					return m_Repository.Update(Pump);

				}

			}
			catch (Exception Ew)
			{
				m_Logger.TraceException(Ew.Message, Ew);
				return false;
			}


		}

		public bool Delete(Pump _T,List<ValidationError> _ValidationErrors)
		{

			try
			{

				if(_ValidationErrors == null)
				{
					_ValidationErrors = new List<ValidationError>();

				}
				if(_T == null)
				{
					_ValidationErrors.Add(new ValidationError{ErrorCode = ErrorCode.NullObject, ErrorMessage = " Pump Object not Set" });
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

		public	bool Validate(List<ValidationError> _ValidationErrors,Pump _T )
		{
			return false;
		}
    }
}
