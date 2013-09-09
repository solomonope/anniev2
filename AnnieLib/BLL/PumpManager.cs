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
    public class PumpManager : IManager<Pump>
    {
        IRepository<Pump> m_Repository;
        public PumpManager(IRepository<Pump> Repository)
        {
            m_Repository = Repository; ; ; ; ; ; ; ;
        }


		public	bool Validate(List<ValidationError> _ValidationErrors,Pump _T )
		{
			return false;
		}
    }
}
