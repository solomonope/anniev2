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
    public class TankManager : IManager<Tank>
    {
        IRepository<Tank> m_Repository;

        public TankManager(IRepository<Tank> Repository)
        {

            m_Repository = Repository;
        }



		public	bool Validate(List<ValidationError> _ValidationErrors,Tank _T )
		{
			return false;
		}
    }
}
