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
				string _Sql = "SELECT * FROM PumpReadings";
				MySqlDataReader _Reader = null;
				List<PumpReading> _PumpReadings = null;
                try
                {
					_Reader =  MySqlHelper.ExecuteReader(AppConfig.ConnString,_Sql);

					if(_Reader != null){
						_PumpReadings =  new List<PumpReading>();

						if(_Reader.HasRows)
						{
							while(_Reader.Read())
							{
								var _PumpReading = new PumpReading()
								{
									PumpReadingId 	= 	Guid.Parse(_Reader["PumpReadingId"].ToString()),
									PumpId 			=  	Guid.Parse(_Reader["PumpId"].ToString()),
									Pump 			=	null,
									ReadingDate		=  Convert.ToDateTime(_Reader["ReadingDate"]),
									SalesRate       = Convert.ToDouble(_Reader["SalesRate"]),
									StartOfBusiness = Convert.ToDouble(_Reader["StartOfBusiness"]),
									CloseOfBusiness =  Convert.ToDouble(_Reader["CloseOfBusiness"]),
									TotalVolumeSold =  Convert.ToDouble(_Reader["TotalVolumeSold"]),
									BusinessDayId   = Guid.Parse(_Reader["BusinessDayId"].ToString()),
									BusinessDay =  null

								};

								_PumpReadings.Add(_PumpReading);

							}
						}
					}

					return _PumpReadings as IQueryable<PumpReading>;
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

        public bool Save(PumpReading _T)
        {
			string _Sql = "INSERT INTO PumpReadings(PumpReadingId,PumpId,SalesRate,ReadingDate,StartOfBusiness,CloseOfBusiness,TotalVolumeSold,BusinessDayId) VALUES(@PumpReadingId,@PumpId,@SalesRate,@ReadingDate,@StartOfBusiness,@CloseOfBusiness,@TotalVolumeSold,@BusinessDayId)";
			List<MySqlParameter> _Parameters = null;
            try
            {
				_Parameters = new List<MySqlParameter>()
				{
					new MySqlParameter(){ParameterName="@PumpReadingId",MySqlDbType = MySqlDbType.VarChar, Value = _T.PumpReadingId.ToString()},
					new MySqlParameter(){ParameterName="@PumpId",MySqlDbType = MySqlDbType.VarChar, Value = _T.PumpId.ToString()},
					new MySqlParameter(){ParameterName="@SalesRate",MySqlDbType = MySqlDbType.Double, Value = _T.SalesRate},
					new MySqlParameter(){ParameterName="@ReadingDate",MySqlDbType = MySqlDbType.Datetime, Value = _T.ReadingDate},
					new MySqlParameter(){ParameterName="@StartOfBusiness",MySqlDbType = MySqlDbType.Double, Value = _T.StartOfBusiness},
					new MySqlParameter(){ParameterName="@CloseOfBusiness",MySqlDbType = MySqlDbType.Double, Value = _T.CloseOfBusiness},
					new MySqlParameter(){ParameterName="@TotalVolumeSold",MySqlDbType = MySqlDbType.Double, Value = _T.TotalVolumeSold},
					new MySqlParameter(){ParameterName="@BusinessDayId",MySqlDbType = MySqlDbType.VarChar, Value = _T.BusinessDayId}

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

        public PumpReading GetById(string Id)
        {
            try
            {
				return this.All.Where(x => x.PumpReadingId.ToString() ==Id).SingleOrDefault();
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
				return this.All.Where(predicate);
            }
            catch (Exception Ew)
            {
                m_Logger.TraceException(Ew.Message, Ew);
                return null;
            }
        }

        public bool Delete(PumpReading _T)
        {
			string _Sql = "DELETE FROM PumpReading WHERE PumpReadingId = @PumpReadingId";
            try
            {
				int _Count = MySqlHelper.ExecuteNonQuery(AppConfig.ConnString,_Sql,new MySqlParameter(){ParameterName="@PumpReadingId",MySqlDbType = MySqlDbType.VarChar, Value = _T.PumpReadingId});
				if(_Count >0) return true;
                return false;
            }
            catch (Exception Ew)
            {
                m_Logger.TraceException(Ew.Message, Ew);
                return false;
            }
        }

		public bool Update(PumpReading _T)
		{
			string _Sql = "UPDATE PumpReadings SET PumpId = @PumpId,SalesRate = @SalesRate,ReadingDate = @ReadingDate,StartOfBusiness = @StartOfBusiness,CloseOfBusiness = @CloseOfBusiness,TotalVolumeSold = @TotalVolumeSold,BusinessDayId  = @BusinessDayId WHERE PumpReadingId = @PumpReadingId";
			List<MySqlParameter> _Parameters = null;
			try
			{
				_Parameters = new List<MySqlParameter>()
				{
					new MySqlParameter(){ParameterName="@PumpReadingId",MySqlDbType = MySqlDbType.VarChar, Value = _T.PumpReadingId.ToString()},
					new MySqlParameter(){ParameterName="@PumpId",MySqlDbType = MySqlDbType.VarChar, Value = _T.PumpId.ToString()},
					new MySqlParameter(){ParameterName="@SalesRate",MySqlDbType = MySqlDbType.Double, Value = _T.SalesRate},
					new MySqlParameter(){ParameterName="@ReadingDate",MySqlDbType = MySqlDbType.Datetime, Value = _T.ReadingDate},
					new MySqlParameter(){ParameterName="@StartOfBusiness",MySqlDbType = MySqlDbType.Double, Value = _T.StartOfBusiness},
					new MySqlParameter(){ParameterName="@CloseOfBusiness",MySqlDbType = MySqlDbType.Double, Value = _T.CloseOfBusiness},
					new MySqlParameter(){ParameterName="@TotalVolumeSold",MySqlDbType = MySqlDbType.Double, Value = _T.TotalVolumeSold},
					new MySqlParameter(){ParameterName="@BusinessDayId",MySqlDbType = MySqlDbType.VarChar, Value = _T.BusinessDayId}

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
