using BitworkSystem.Annie.BO;
using BitworkSystem.Annie.DAL.Contract;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace BitworkSystem.Annie.DAL
{
    public class PumpSaleData :IRepository<PumpSale>,IDisposable
    {
       
        private Logger m_Logger;
        public PumpSaleData()
        {
          
            m_Logger = LogManager.GetCurrentClassLogger();
        }
        public IQueryable<PumpSale> All
        {
            get
            {
				string _Sql = "SELECT * FROM PumpSales";
				MySqlDataReader _Reader = null;
				List<PumpSale> _PumpSales = null;

                try
                {
					_Reader =  MySqlHelper.ExecuteReader(AppConfig.ConnString,_Sql);
					if(_Reader != null){

					}
					return _PumpSales as IQueryable<PumpSale>;
                }
                catch (Exception Ew)
                {
                    m_Logger.TraceException(Ew.Message, Ew);
                    return null;
                }
            }
        }

        public bool Save(PumpSale _T)
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

        public PumpSale GetById(string Id)
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

        public IQueryable<PumpSale> Search(System.Linq.Expressions.Expression<Func<PumpSale, bool>> predicate)
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

        public bool Delete(PumpSale _T)
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
