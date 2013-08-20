using BitworkSystem.Annie.BO;
using BitworkSystem.Annie.DAL.Contract;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitworkSystem.Annie.DAL
{
    public class CityData:IRepository<City>,IDisposable
    {
        
        private Logger m_Logger;
        public CityData()
        {
           
            m_Logger = LogManager.GetCurrentClassLogger();
        }
        public IQueryable<City> All
        {
            get
            {
                try
                {
                    return null;
                }
                catch (Exception Ew)
                {

                    m_Logger.TraceException(Ew.Message, Ew);
                    return null;
                }
            }
        }

        public bool Save(City _T)
        {
            try
            {
                
                return true;
            }
            catch (Exception Ew)
            {
                m_Logger.TraceException(Ew.Message, Ew);
                return false;
            }
        }

        public City GetById(string Id)
        {
            try
            {
                return null;
            }
            catch (Exception Ew)
            {
                m_Logger.TraceException(Ew.Message, Ew);
                return null;
            }
        }

        public IQueryable<City> Search(System.Linq.Expressions.Expression<Func<City, bool>> predicate)
        {
            try
            {
                return null;
            }
            catch (Exception Ew)
            {
                m_Logger.TraceException(Ew.Message, Ew);
                return null;
            }
        }

        public bool Delete(City _T)
        {
            try
            {
                
                return true;
            }
            catch (Exception Ew)
            {
                m_Logger.TraceException(Ew.Message, Ew);
                return false;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            
        }
    }
}
