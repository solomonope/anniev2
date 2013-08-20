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
    public class SalesRateData :IRepository<SalesRate>,IDisposable
    {
       
        private Logger m_Logger;
        public SalesRateData()
        {
            
            m_Logger = LogManager.GetCurrentClassLogger();
        }
        public IQueryable<SalesRate> All
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

        public bool Save(SalesRate _T)
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

        public SalesRate GetById(string Id)
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

        public IQueryable<SalesRate> Search(System.Linq.Expressions.Expression<Func<SalesRate, bool>> predicate)
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

        public bool Delete(SalesRate _T)
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
