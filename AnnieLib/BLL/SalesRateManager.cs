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
    public class SalesRateManager :IManager<SalesRate>
    {
        IRepository<SalesRate> m_Repository;

        public SalesRateManager(IRepository<SalesRate> Repository)
        {

            m_Repository = Repository;
        }


		bool Validate(List<ValidationError> _ValidationErrors)
		{
			return false;
		}
    }
}
