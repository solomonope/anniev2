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
   public  class TankActivityData :IRepository<TankActivity>,IDisposable
    {
       
        private Logger m_Logger;
        public TankActivityData()
        {
           
            m_Logger = LogManager.GetCurrentClassLogger();
        }
        public IQueryable<TankActivity> All
        {
            get 
            {
				string _Sql = "SELECT * FROM TankActivities";
				MySqlDataReader _Reader = null;
				List<TankActivity> _TankActivities = null;
                try
                {
					_Reader = MySqlHelper.ExecuteReader(AppConfig.ConnString,_Sql);

					if(_Reader != null)
					{
						if(_Reader.HasRows)
						{

							while(_Reader.Read())
							{
								var _TankActivity = new TankActivity
								{
									TankActivityId = Guid.Parse(_Reader["TankActivityId"].ToString()),
									ActivityType   = (ActivityType)Convert.ToInt32(_Reader["ActivityType"]),
									TotalVolume    = Convert.ToDouble(_Reader["TotalVolume"]),
									ActivityDate   = Convert.ToDateTime(_Reader["ActivityDate"]),
									TankId		   = Guid.Parse(_Reader["TankId"].ToString()),
									Tank		  = null,
									BusinessDayId = Guid.Parse(_Reader["BusinessDayId"].ToString()),
									BusinessDay  =  null

								};
								_TankActivities.Add(_TankActivity);
						}
					}

                }
					return _TankActivities as IQueryable<TankActivity>;
				}catch (Exception Ew)
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

        public bool Save(TankActivity _T)
        {
			string _Sql = "INSERT INTO TankActivities(TankActivityId,ActivityType,TotalVolume,ActivityDate,TankId,BusinessDayId) VALUES(@TankActivityId,@ActivityType,@TotalVolume,@ActivityDate,@TankId,@BusinessDayId)";
			List<MySqlParameter> _Parameters = null;
			try
            {
               _Parameters = new List<MySqlParameter>
				{
					new MySqlParameter(){ParameterName="@TankActivityId",MySqlDbType = MySqlDbType.VarChar, Value = _T.TankActivityId.ToString()},
					new MySqlParameter(){ParameterName="@ActivityType",MySqlDbType = MySqlDbType.Int16, Value = _T.ActivityType},
					new MySqlParameter(){ParameterName="@TotalVolume",MySqlDbType = MySqlDbType.Double, Value = _T.TotalVolume},
					new MySqlParameter(){ParameterName="@ActivityDate",MySqlDbType = MySqlDbType.Datetime, Value = _T.ActivityDate},
					new MySqlParameter(){ParameterName="@TankId",MySqlDbType = MySqlDbType.VarChar, Value = _T.TankId.ToString()},
					new MySqlParameter(){ParameterName="@BusinessDayId",MySqlDbType = MySqlDbType.VarChar, Value = _T.BusinessDayId.ToString()},


				};

				int _count =  MySqlHelper.ExecuteNonQuery(AppConfig.ConnString,_Sql,_Parameters.ToArray());
				if(_count >0) return true;

                return false;
            }
            catch (Exception Ew)
            {
                m_Logger.TraceException(Ew.Message, Ew);
                return false;
            }
        }

        public TankActivity GetById(string Id)
        {
            try
            {
                return this.All.Where(x=>x.TankActivityId.ToString() == Id).SingleOrDefault();
            }
            catch (Exception Ew)
            {
                m_Logger.TraceException(Ew.Message, Ew);
                return null;
            }
        }

        public IQueryable<TankActivity> Search(System.Linq.Expressions.Expression<Func<TankActivity, bool>> predicate)
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

        public bool Delete(TankActivity _T)
        {
			string _Sql = "DELETE FROM TankActivities WHERE TankId = @TankId";
            try
            {
				int _count = MySqlHelper.ExecuteNonQuery(AppConfig.ConnString,_Sql,new MySqlParameter{ParameterName="@TankId",MySqlDbType = MySqlDbType.VarChar, Value = _T.TankId.ToString()});

				if(_count > 0) return true;
                
                return false;
            }
            catch (Exception Ew)
            {
                m_Logger.TraceException(Ew.Message, Ew);
                return false;
            }
        }

		public bool Update(TankActivity _T){

			string _Sql = "INSERT INTO TankActivities SET  ActivityType = @ActivityType ,TotalVolume = @TotalVolume , ActivityDate =  @ActivityDate,TankId = @TankId , BusinessDayId = @BusinessDayId WHERE TankActivityId = @TankActivityId";
			List<MySqlParameter> _Parameters = null;
			try
			{
				_Parameters = new List<MySqlParameter>
				{
					new MySqlParameter(){ParameterName="@TankActivityId",MySqlDbType = MySqlDbType.VarChar, Value = _T.TankActivityId.ToString()},
					new MySqlParameter(){ParameterName="@ActivityType",MySqlDbType = MySqlDbType.Int16, Value = _T.ActivityType},
					new MySqlParameter(){ParameterName="@TotalVolume",MySqlDbType = MySqlDbType.Double, Value = _T.TotalVolume},
					new MySqlParameter(){ParameterName="@ActivityDate",MySqlDbType = MySqlDbType.Datetime, Value = _T.ActivityDate},
					new MySqlParameter(){ParameterName="@TankId",MySqlDbType = MySqlDbType.VarChar, Value = _T.TankId.ToString()},
					new MySqlParameter(){ParameterName="@BusinessDayId",MySqlDbType = MySqlDbType.VarChar, Value = _T.BusinessDayId.ToString()},


				};

				int _count =  MySqlHelper.ExecuteNonQuery(AppConfig.ConnString,_Sql,_Parameters.ToArray());
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
