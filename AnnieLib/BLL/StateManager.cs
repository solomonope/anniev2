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
    public class StateManager : IManager<State>
    {
        IRepository<State> m_Repository;

        public StateManager(IRepository<State> Repository)
        {

            m_Repository = Repository;
        }
    }
}
