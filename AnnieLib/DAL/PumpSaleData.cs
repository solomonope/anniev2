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

						_PumpSales = new List<PumpSale>();
						if(_Reader.HasRows){

							var _PumpSale = new PumpSale(){
								PumpSaleId = Guid.Parse(_Reader["PumpSaleId"].ToString()),
								PumpId     =  Guid.Parse(_Reader["PumpId"].ToString()),
								Pump	 =  null,
								SoldVolume = Convert.ToDouble(_Reader["SoldVolume"]),
								SalesRate = Convert.ToDouble(_Reader["SalesRate"]),
								DateTimeOfSale = Convert.ToDateTime(_Reader["DateTimeOfSale"])
							};

							_PumpSales.Add(_PumpSale);

						}

					}
					return _PumpSales as IQueryable<PumpSale>;
                }
                catch (Exception Ew)
                {
                    m_Logger.TraceException(Ew.Message, Ew);
                    return null;
                }finally{
					if (_Reader != null) {

						if (!_Reader.IsClosed)
							_Reader.Close ();

					}
				}
            }
        }

        public bool Save(PumpSale _T)
        {
			string _Sql = "INSERT INTO PumpSales(PumpSaleId,PumpId,SoldVolume,SalesRate,DateTimeOfSale) VALUES(@PumpSaleId,@PumpId,@SoldVolume,@SalesRate,@DateTimeOfSale)";
			List<MySqlParameter> _Parameters = null;
            try
            {
                _Parameters = new List<MySqlParameter>()
				{
					new MySqlParameter(){ParameterName="@PumpSaleId",MySqlDbType = MySqlDbType.VarChar, Value = _T.PumpSaleId.ToString()},
					new MySqlParameter(){ParameterName="@PumpId",MySqlDbType = MySqlDbType.VarChar, Value = _T.PumpId.ToString()},
					new MySqlParameter(){ParameterName="@SoldVolume",MySqlDbType = MySqlDbType.Double, Value = _T.SoldVolume},
					new MySqlParameter(){ParameterName="@SalesRate",MySqlDbType = MySqlDbType.Double, Value = _T.SalesRate},
					new MySqlParameter(){ParameterName="@DateTimeOfSale",MySqlDbType = MySqlDbType.Datetime, Value = _T.DateTimeOfSale}

				};

				int _Count = MySqlHelper.ExecuteNonQuery(AppConfig.ConnString,_Sql,_Parameters.ToArray());

				if(_Count > 0) return true;
                return false;
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

				return this.All.Where(x => x.PumpSaleId.ToString() ==Id).SingleOrDefault();
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
                return this.All.Where(predicate);
            }
            catch (Exception Ew)
            {
                m_Logger.TraceException(Ew.Message, Ew);
                return null;
            }
        }

        public bool Delete(PumpSale _T)
        {
			string _Sql = "DELETE FROM  PumpSales WHERE PumpSaleId =  @PumpSaleId";
            try
            {
				int _count = MySqlHelper.ExecuteNonQuery(AppConfig.ConnString,_Sql,new MySqlParameter(){ParameterName="@PumpSaleId",MySqlDbType = MySqlDbType.VarChar, Value = _T.PumpSaleId.ToString()});

				if(_count >0) return true;
                
                return false;
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
