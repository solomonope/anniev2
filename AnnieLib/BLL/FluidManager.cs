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
    public class FluidManager:IManager<Fluid>
    {
        IRepository<Fluid> m_Repository;
		private Logger m_Logger;
        public FluidManager(IRepository<Fluid> Repository)
        {
            m_Repository = Repository;
			m_Logger = LogManager.GetCurrentClassLogger();
        }

		public bool Save(Fluid Fluid ,List<ValidationError> _ValidationErrors)
		{
			try
			{

				if(_ValidationErrors == null)
				{
					_ValidationErrors = new List<ValidationError>();

				}
				if(Fluid == null)
				{
					_ValidationErrors.Add(new ValidationError{ErrorCode = ErrorCode.NullObject, ErrorMessage = " Fluid Object not Set" });
					return false;
				}
				if (this.Validate(_T:Fluid,_ValidationErrors:_ValidationErrors))
				{
					return false;
				}else
				{

					return m_Repository.Save(Fluid);

				}

			}
			catch (Exception Ew)
			{
				m_Logger.TraceException(Ew.Message, Ew);
				return false;
			}
		}

		public Fluid GetById(string Id)
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

		public IQueryable<Fluid> GetAll()
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

		public bool Update(Fluid Fluid,List<ValidationError> _ValidationErrors){

			try
			{

				if(_ValidationErrors == null)
				{
					_ValidationErrors = new List<ValidationError>();

				}
				if(Fluid == null)
				{
					_ValidationErrors.Add(new ValidationError{ErrorCode = ErrorCode.NullObject, ErrorMessage = " Fluid Object not Set" });
					return false;
				}
				if (this.Validate(_T:Fluid,_ValidationErrors:_ValidationErrors))
				{
					return false;
				}else
				{

					return m_Repository.Update(Fluid);

				}

			}
			catch (Exception Ew)
			{
				m_Logger.TraceException(Ew.Message, Ew);
				return false;
			}


		}

		public bool Delete(Fluid _T,List<ValidationError> _ValidationErrors)
		{

			try
			{

				if(_ValidationErrors == null)
				{
					_ValidationErrors = new List<ValidationError>();

				}
				if(_T == null)
				{
					_ValidationErrors.Add(new ValidationError{ErrorCode = ErrorCode.NullObject, ErrorMessage = " Fluid Object not Set" });
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

		public	bool Validate(List<ValidationError> _ValidationErrors, Fluid _T )
		{
			return true;
		}
    }
}
