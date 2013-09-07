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
    public class TankReadingData :IRepository<TankReading>,IDisposable
    {
         
        private Logger m_Logger;
        public TankReadingData()
        {
           
            m_Logger = LogManager.GetCurrentClassLogger();
        }
        public IQueryable<TankReading> All
        {
            get
            {
				string _Sql = "SELECT * FROM ";
				MySqlDataReader _Reader = null;
				List<TankReading> _TankReadings = null;

                try
                {
					_Reader = MySqlHelper.ExecuteReader(AppConfig.ConnString,_Sql);

					if(_Reader  != null)
					{
						_TankReadings =  new List<TankReading>();

						if(_Reader.HasRows)
						{
							while(_Reader.Read())
							{
								var _TankReading = new TankReading
								{
									TankReadingId  = Guid.Parse(_Reader["TankReadingId"].ToString()),
									ReadingDate    =  Convert.ToDateTime(_Reader["ReadingDate"]),
									SalesRate	   =  Convert.ToDouble(_Reader["SalesRate"]),
									StartOfBusiness =  Convert.ToDouble(_Reader["StartOfBusiness"]),
									CloseOfBusiness =  Convert.ToDouble(_Reader["CloseOfBusiness"]),
									TotalVolumeSold = Convert.ToDouble(_Reader["TotalVolumeSold"]),
									TankId          =  Guid.Parse(_Reader["TankId"].ToString()),
									BusinessDayId   =  Guid.Parse(_Reader["BusinessDayId"].ToString()),
									Tank            =  null,
									BusinessDay     = null
								};

								_TankReadings.Add(_TankReading);


							}

						}

					}
					return _TankReadings as IQueryable<TankReading>;
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

        public bool Save(TankReading _T)
        {
			string _Sql = "INSERT INTO TankReading(TankReadingId,ReadingDate,SalesRate,StartOfBusiness,CloseOfBusiness,TotalVolumeSold,TankId,BusinessDayId) VALUES(@TankReadingId,@ReadingDate,@SalesRate,@StartOfBusiness,@CloseOfBusiness,@TotalVolumeSold,@TankId,@BusinessDayId)";
			List<MySqlParameter> _Parameters = null;
			try
            {
                _Parameters =  new List<MySqlParameter>
				{
					new MySqlParameter{ParameterName="@TankReadingId",MySqlDbType = MySqlDbType.VarChar, Value = _T.TankReadingId.ToString()},
					new MySqlParameter{ParameterName="@ReadingDate",MySqlDbType = MySqlDbType.Datetime, Value = _T.ReadingDate},
					new MySqlParameter{ParameterName="@StartOfBusiness",MySqlDbType = MySqlDbType.Double, Value = _T.StartOfBusiness},
					new MySqlParameter{ParameterName="@CloseOfBusiness",MySqlDbType = MySqlDbType.Double, Value = _T.CloseOfBusiness},
					new MySqlParameter{ParameterName="@TotalVolumeSold",MySqlDbType = MySqlDbType.Double, Value = _T.TotalVolumeSold},
					new MySqlParameter{ParameterName="@TankId",MySqlDbType = MySqlDbType.VarChar, Value = _T.TankId.ToString()},
					new MySqlParameter{ParameterName="@BusinessDayId",MySqlDbType = MySqlDbType.VarChar, Value = _T.BusinessDayId.ToString()},
					new MySqlParameter{ParameterName="@SalesRate",MySqlDbType = MySqlDbType.Double, Value = _T.SalesRate}

				};

				int _Count = MySqlHelper.ExecuteNonQuery(AppConfig.ConnString,_Sql,_Parameters.ToArray());

				if(_Count >0) return true;

                return false;
            }
            catch (Exception Ew)
            {
                m_Logger.TraceException(Ew.Message, Ew);
                return false;

            }
        }

        public TankReading GetById(string Id)
        {
            try
            {
               return  this.All.Where(x => x.TankReadingId.ToString() == Id).SingleOrDefault();
            }
            catch (Exception Ew)
            {
                m_Logger.TraceException(Ew.Message, Ew);
                return null;
            }
        }

        public IQueryable<TankReading> Search(System.Linq.Expressions.Expression<Func<TankReading, bool>> predicate)
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

        public bool Delete(TankReading _T)
        {
			string _Sql = "DELETE FROM TankReading WHERE TankReadingId = @TankReadingId";
            try
            {
				int _Count = MySqlHelper.ExecuteNonQuery(AppConfig.ConnString,_Sql,new MySqlParameter{ParameterName="@TankReadingId",MySqlDbType = MySqlDbType.VarChar, Value = _T.TankReadingId.ToString()});

				if(_Count >0) return true;
               
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
