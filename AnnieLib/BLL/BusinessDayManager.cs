using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text;
using System.Text.RegularExpressions;
using BitworkSystem.Annie.BLL.Contract;
using BitworkSystem.Annie.BO;
using BitworkSystem.Annie.DAL.Contract;

namespace BitworkSystem.Annie.BLL
{
   public class BusinessDayManager :IManager<BusinessDay>
    {
       private IRepository<BusinessDay> m_Repository;
       public BusinessDayManager(IRepository<BusinessDay> Repository)
       {
           m_Repository = Repository;
       }
		public bool Upsert(BusinessDay BusinessDay,List<ValidationError> _ValidationErrors)
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
				return false;
           }
           catch (Exception Ew)
           {
				return false;
           }
       }

		public bool Validate(List<ValidationError> _ValidationErrors,BusinessDay _T )
		{
			bool _State = true;
			string _RegexId = @"^[A-Za-z0-9]{8}-[A-Za-z0-9]{4}-[A-Za-z0-9]{4}-[A-Za-z0-9]{4}-[A-Za-z0-9]{12}$";
			string _RegexDate = @"^\d{1,2}\/\d{1,2}\/\d{4}$";

			if (!Regex.IsMatch (_T.BusinessDayId.ToString (), _RegexId))
				_State = false;

			if (!Regex.IsMatch ("", ""))
				_State = false;

			return _State;
		}
    }
}
