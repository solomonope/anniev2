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
    public class TankVolumeLoggManager : IManager<TankVolumeLogg>
    {
		IRepository<TankVolumeLogg> m_Repository;
		private Logger m_Logger;
		public TankVolumeLoggManager(IRepository<TankVolumeLogg> Repository)
		{

			m_Repository = Repository;
			m_Logger = LogManager.GetCurrentClassLogger();
		}
		public bool Save(TankVolumeLogg TankVolumeLogg ,List<ValidationError> _ValidationErrors)
		{
			try
			{

				if(_ValidationErrors == null)
				{
					_ValidationErrors = new List<ValidationError>();

				}
				if(TankVolumeLogg == null)
				{
					_ValidationErrors.Add(new ValidationError{ErrorCode = ErrorCode.NullObject, ErrorMessage = " TankVolumeLogg Object not Set" });
					return false;
				}
				if (this.Validate(_T:TankVolumeLogg,_ValidationErrors:_ValidationErrors))
				{
					return false;
				}else
				{

					return m_Repository.Save(TankVolumeLogg);

				}

			}
			catch (Exception Ew)
			{
				m_Logger.TraceException(Ew.Message, Ew);
				return false;
			}
		}


		public IQueryable<TankVolumeLogg> GetAll()
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
		public TankVolumeLogg GetById(string Id)
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

		public bool Update(TankVolumeLogg TankVolumeLogg,List<ValidationError> _ValidationErrors){

			try
			{

				if(_ValidationErrors == null)
				{
					_ValidationErrors = new List<ValidationError>();

				}
				if(TankVolumeLogg == null)
				{
					_ValidationErrors.Add(new ValidationError{ErrorCode = ErrorCode.NullObject, ErrorMessage = " TankVolumeLogg Object not Set" });
					return false;
				}
				if (this.Validate(_T:TankVolumeLogg,_ValidationErrors:_ValidationErrors))
				{
					return false;
				}else
				{

					return m_Repository.Update(TankVolumeLogg);

				}

			}
			catch (Exception Ew)
			{
				m_Logger.TraceException(Ew.Message, Ew);
				return false;
			}


		}

		public bool Delete(TankVolumeLogg _T,List<ValidationError> _ValidationErrors)
		{

			try
			{

				if(_ValidationErrors == null)
				{
					_ValidationErrors = new List<ValidationError>();

				}
				if(_T == null)
				{
					_ValidationErrors.Add(new ValidationError{ErrorCode = ErrorCode.NullObject, ErrorMessage = " TankVolumeLogg Object not Set" });
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



		public	bool Validate(List<ValidationError> _ValidationErrors,TankVolumeLogg _T )
		{
			return false;
		}
    }
}
