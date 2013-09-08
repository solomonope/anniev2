using BitworkSystem.Annie.BLL.Contract;
using BitworkSystem.Annie.BO;
using BitworkSystem.Annie.DAL.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitworkSystem.Annie.BLL
{
   public class BusinessDayManager :IManager<BusinessDay>
    {
       private IRepository<BusinessDay> m_Repository;
       public BusinessDayManager(IRepository<BusinessDay> Repository)
       {
           m_Repository = Repository;
       }
       public int Upsert(BusinessDay BusinessDay)
       {
           try
           {
               return (int)ResponseCodes.Failed;
           }
           catch (Exception Ew)
           {
               return (int)ResponseCodes.Failed;
           }
       }

		public bool Validate(List<ValidationError> _ValidationErrors)
		{
			return false;
		}
    }
}
