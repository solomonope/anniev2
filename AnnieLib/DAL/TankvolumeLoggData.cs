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
    public class TankvolumeLoggData :IRepository<TankVolumeLogg>,IDisposable
    {
       
        private Logger m_Logger;
        public TankvolumeLoggData()
        {
           
            m_Logger = LogManager.GetCurrentClassLogger();
        }
        public IQueryable<TankVolumeLogg> All
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

        public bool Save(TankVolumeLogg _T)
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

        public TankVolumeLogg GetById(string Id)
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

        public IQueryable<TankVolumeLogg> Search(System.Linq.Expressions.Expression<Func<TankVolumeLogg, bool>> predicate)
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

        public bool Delete(TankVolumeLogg _T)
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
