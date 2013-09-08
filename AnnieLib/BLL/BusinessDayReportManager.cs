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
    public class BusinessDayReportManager : IManager<BusinessDayReport>
    {
        IRepository<BusinessDayReport> m_Repository;
        public BusinessDayReportManager(IRepository<BusinessDayReport> Repository)
        {
            m_Repository = Repository;
        }


		bool Validate(List<ValidationError> _ValidationErrors)
		{
			return false;
		}
    }
}
