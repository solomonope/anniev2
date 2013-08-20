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
    public class TankReadingManager :IManager<TankReading>
    {
        IRepository<TankReading> m_Repository;

        public TankReadingManager(IRepository<TankReading> Repository)
        {

            m_Repository = Repository;
        }
    }
}
