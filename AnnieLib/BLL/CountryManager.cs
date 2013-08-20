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
    public class CountryManager: IManager<Country>
    {
        IRepository<Country> m_Repository;
        public CountryManager(IRepository<Country> Repository)
        {
            m_Repository = Repository;
        }
    }
}
