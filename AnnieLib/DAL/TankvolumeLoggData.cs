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
				string _Sql = "SELECT *  FROM TankVolumeLogg";
				MySqlDataReader _Reader = null;
				List<TankVolumeLogg> _TankVolumeLoggs = null;
                try
                {
					_Reader = MySqlHelper.ExecuteReader(AppConfig.ConnString,_Sql);

					if(_Reader != null)
					{
						_TankVolumeLoggs = new List<TankVolumeLogg>();

						if(_Reader.HasRows)
						{
							while(_Reader.Read())
							{
								var _TankVolumeLogg = new TankVolumeLogg
								{
									TankVolumeLoggId  = Guid.Parse(_Reader["TankVolumeLoggId"].ToString()),
									TankId			  = Guid.Parse(_Reader["TankId"].ToString()),
									Volume			  = Convert.ToDouble(_Reader["Volume"]),
									SellingRate       = Convert.ToDouble(_Reader["SellingRate"]),
									BusinessDayId	  = Guid.Parse(_Reader["BusinessDayId"].ToString()),
									DateTimeOfLogg    = Convert.ToDateTime(_Reader["DateTimeOfLogg"]),
									Tank              = null,
									BusinessDay       = null

								};
							}

						}

					}
					return _TankVolumeLoggs as IQueryable<TankVolumeLogg>;
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

        public bool Save(TankVolumeLogg _T)
        {
			string _Sql = "INSERT INTO TankVolume(TankVolumeLoggId,TankId,Volume,SellingRate,BusinessDayId,DateTimeOfLogg)  VALUES(@TankVolumeLoggId,@TankId,@Volume,@SellingRate,@BusinessDayId,@DateTimeOfLogg)";
			List<MySqlParameter> _Parameters = null;
            try
            {
				_Parameters = new List<MySqlParameter>
				{
					new MySqlParameter{ParameterName="@TankVolumeLoggId",MySqlDbType = MySqlDbType.VarChar, Value = _T.TankVolumeLoggId.ToString()},
					new MySqlParameter{ParameterName="@TankId",MySqlDbType = MySqlDbType.VarChar, Value = _T.TankId.ToString()},
					new MySqlParameter{ParameterName="@Volume",MySqlDbType = MySqlDbType.Double, Value = _T.Volume},
					new MySqlParameter{ParameterName="@SellingRate",MySqlDbType = MySqlDbType.Double, Value = _T.SellingRate},
					new MySqlParameter{ParameterName="@BusinessDayId",MySqlDbType = MySqlDbType.VarChar, Value = _T.BusinessDayId.ToString()},
					new MySqlParameter{ParameterName="@DateTimeOfLogg",MySqlDbType = MySqlDbType.Datetime, Value = _T.DateTimeOfLogg},



				};

				int _Count =  MySqlHelper.ExecuteNonQuery(AppConfig.ConnString,_Sql,_Parameters.ToArray());
				if(_Count >0 ) return true;

                return false;
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
				return this.All.Where(x=>x.TankVolumeLoggId.ToString()  ==  Id).SingleOrDefault();
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
				return this.All.Where(predicate);


            }
            catch (Exception Ew)
            {

                m_Logger.TraceException(Ew.Message, Ew);
                return null;
            }
        }

        public bool Delete(TankVolumeLogg _T)
        {
			string _Sql = "DELETE FROM TankVolumeLogg where TankVolumeLoggId = @TankVolumeLoggId";
            try
            {
                
				int _Count = MySqlHelper.ExecuteNonQuery(AppConfig.ConnString,_Sql,new MySqlParameter{ParameterName="@TankVolumeLoggId",MySqlDbType = MySqlDbType.VarChar, Value = _T.TankVolumeLoggId.ToString()});

				if(_Count >0) return true;

				return false;
            }
            catch (Exception Ew)
            {
                m_Logger.TraceException(Ew.Message, Ew);
                return false;
            }
        }


		public bool Update(TankVolumeLogg _T){
			string _Sql = "UPDATE TankVolume SET TankId = @TankId,Volume = @Volume ,SellingRate = @SellingRate ,BusinessDayId = @BusinessDayId ,DateTimeOfLogg  = @DateTimeOfLogg WHERE TankVolumeLoggId = @TankVolumeLoggId";
			List<MySqlParameter> _Parameters = null;
			try
			{
				_Parameters = new List<MySqlParameter>
				{
					new MySqlParameter{ParameterName="@TankVolumeLoggId",MySqlDbType = MySqlDbType.VarChar, Value = _T.TankVolumeLoggId.ToString()},
					new MySqlParameter{ParameterName="@TankId",MySqlDbType = MySqlDbType.VarChar, Value = _T.TankId.ToString()},
					new MySqlParameter{ParameterName="@Volume",MySqlDbType = MySqlDbType.Double, Value = _T.Volume},
					new MySqlParameter{ParameterName="@SellingRate",MySqlDbType = MySqlDbType.Double, Value = _T.SellingRate},
					new MySqlParameter{ParameterName="@BusinessDayId",MySqlDbType = MySqlDbType.VarChar, Value = _T.BusinessDayId.ToString()},
					new MySqlParameter{ParameterName="@DateTimeOfLogg",MySqlDbType = MySqlDbType.Datetime, Value = _T.DateTimeOfLogg},



				};

				int _Count =  MySqlHelper.ExecuteNonQuery(AppConfig.ConnString,_Sql,_Parameters.ToArray());
				if(_Count >0 ) return true;

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
