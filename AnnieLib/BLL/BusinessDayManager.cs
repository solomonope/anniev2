using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using BitworkSystem.Annie.BLL.Contract;
using BitworkSystem.Annie.BO;
using BitworkSystem.Annie.DAL.Contract;
using NLog;
namespace BitworkSystem.Annie.BLL
{
   public class BusinessDayManager :IManager<BusinessDay>
    {
       private IRepository<BusinessDay> m_Repository;
		private Logger m_Logger;
       public BusinessDayManager(IRepository<BusinessDay> Repository)
       {
           m_Repository = Repository;
			m_Logger = LogManager.GetCurrentClassLogger();
       }
		public bool Save(BusinessDay BusinessDay,List<ValidationError> _ValidationErrors)
       {
           try
           {

				if(_ValidationErrors == null)
				{
					_ValidationErrors = new List<ValidationError>();
					
				}
				if(BusinessDay == null)
				{
					_ValidationErrors.Add(new ValidationError{ErrorCode = ErrorCode.NullObject, ErrorMessage = " Business Object not Set" });
					return false;
				}
				if (this.Validate(_T:BusinessDay,_ValidationErrors:_ValidationErrors))
				{
					return false;
				}else
				{

				return m_Repository.Save(BusinessDay);

				}

           }
           catch (Exception Ew)
           {
				m_Logger.TraceException(Ew.Message, Ew);
				return false;
           }
       }

		public BusinessDay GetById(string Id)
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

		public IQueryable<BusinessDay> GetAll()
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

		public bool Update(BusinessDay BusinessDay,List<ValidationError> _ValidationErrors){

			try
			{

				if(_ValidationErrors == null)
				{
					_ValidationErrors = new List<ValidationError>();

				}
				if(BusinessDay == null)
				{
					_ValidationErrors.Add(new ValidationError{ErrorCode = ErrorCode.NullObject, ErrorMessage = " Business Object not Set" });
					return false;
				}
				if (this.Validate(_T:BusinessDay,_ValidationErrors:_ValidationErrors))
				{
					return false;
				}else
				{

					return m_Repository.Update(BusinessDay);

				}

			}
			catch (Exception Ew)
			{
				m_Logger.TraceException(Ew.Message, Ew);
				return false;
			}


		}


		public bool Delete(BusinessDay _T,List<ValidationError> _ValidationErrors)
		{

			try
			{

				if(_ValidationErrors == null)
				{
					_ValidationErrors = new List<ValidationError>();

				}
				if(_T == null)
				{
					_ValidationErrors.Add(new ValidationError{ErrorCode = ErrorCode.NullObject, ErrorMessage = " Business Object not Set" });
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
		public bool Validate(List<ValidationError> _ValidationErrors,BusinessDay _T )
		{
			bool _State = true;
			string _RegexId = @"^[A-Za-z0-9]{8}-[A-Za-z0-9]{4}-[A-Za-z0-9]{4}-[A-Za-z0-9]{4}-[A-Za-z0-9]{12}$";
			string _RegexDate = @"^\d{1,2}\/\d{1,2}\/\d{4}$";

			if (_T.BusinessDayId == null) {
				_State = false;
				_ValidationErrors.Add(new ValidationError{ErrorCode = ErrorCode.NullObject, ErrorMessage = "BussinessDayId is NULL" });

			}
			if (_T.StartTime == null) {
				_State = false;
				_ValidationErrors.Add(new ValidationError{ErrorCode = ErrorCode.NullObject, ErrorMessage = "StartTime is NULL" });

			}

			if (_T.EndTime != null) {
				//_State = false;
				//_ValidationErrors.Add(new ValidationError{ErrorCode = ErrorCode.NullObject, ErrorMessage = "EndTime is NULL" });

				if (_T.EndTime.TimeOfDay < _T.StartTime.TimeOfDay) {
					_State = false;
					_ValidationErrors.Add(new ValidationError{ErrorCode = ErrorCode.NullObject, ErrorMessage = "EndTime Less than Start Time" });

				}


			}

			if (_T.StartTime.Date != DateTime.Now.Date) {

				_State = false;
				_ValidationErrors.Add(new ValidationError{ErrorCode = ErrorCode.NullObject, ErrorMessage = "StartTime is not today" });

			}


			return _State;
		}
    }
}
