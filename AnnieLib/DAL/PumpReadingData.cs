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
    public class PumpReadingData :IRepository<PumpReading>,IDisposable
    {
       
        private Logger m_Logger;
        public PumpReadingData()
        {
            
            m_Logger = LogManager.GetCurrentClassLogger();
        }
        public IQueryable<PumpReading> All
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

        public bool Save(PumpReading _T)
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

        public PumpReading GetById(string Id)
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

        public IQueryable<PumpReading> Search(System.Linq.Expressions.Expression<Func<PumpReading, bool>> predicate)
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

        public bool Delete(PumpReading _T)
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
