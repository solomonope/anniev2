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
    public class PumpReadingManager:IManager<PumpReading>
    {
        IRepository<PumpReading> m_Repository;

        public PumpReadingManager(IRepository<PumpReading> Repository)
        {

            m_Repository = Repository;
        }


		public	bool Validate(List<ValidationError> _ValidationErrors,PumpReading _T )
		{
			return false;
		}
    }
}
