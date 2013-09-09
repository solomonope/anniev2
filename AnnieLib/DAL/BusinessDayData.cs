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
    public class BusinessDayData: IRepository<BusinessDay>,IDisposable
    {
       
        private Logger m_Logger;
        public BusinessDayData()
        {
            
            m_Logger = LogManager.GetCurrentClassLogger();
        }
        public IQueryable<BusinessDay> All
        {
            get
            {
				string _Sql = "SELECT * FROM BusinessDayData";
				List<BusinessDay> _BusinessDays = null;
				MySqlDataReader _Reader = null;
                try
                {
					_Reader =  MySqlHelper.ExecuteReader(AppConfig.ConnString,_Sql);

					if(_Reader != null)
					{
						_BusinessDays = new List<BusinessDay>();

						if(_Reader.HasRows)
						{
							while(_Reader.Read())
							{
								var _BusinessDay = new BusinessDay
								{
									BusinessDayId = Guid.Parse(_Reader["BusinessDayId"].ToString()),
									StartTime	  = Convert.ToDateTime(_Reader["StartTime"]),
									EndTime		=  Convert.ToDateTime(_Reader["EndTime"]),
									BusinessDayDate = Convert.ToDateTime(_Reader["BusinessDayDate"])

								};

								_BusinessDays.Add(_BusinessDay);
							}

						}

					}
					return _BusinessDays as IQueryable<BusinessDay>;
                }
                catch (Exception Ew)
                {
                   
                    m_Logger.TraceException(Ew.Message, Ew);
                    return null;
                }finally{

					if(_Reader != null){

						if(!_Reader.IsClosed) _Reader.Close();

					}
				}
            }
        }

        public bool Save(BusinessDay _T)
        {
			string _Sql = "INSERT INTO BusinessDay(BusinessDayId,StartTime,EndTime,BusinessDayDate) VALUES(@BusinessDayId,@StartTime,@EndTime,@BusinessDayDate)";
			List<MySqlParameter> _Parameters = null;
            try
            {
				_Parameters = new List<MySqlParameter>
				{
					new MySqlParameter(){ParameterName="@BusinessDayId",MySqlDbType = MySqlDbType.VarChar, Value = _T.BusinessDayId.ToString()},
					new MySqlParameter(){ParameterName="@StartTime",MySqlDbType = MySqlDbType.Datetime, Value = _T.StartTime},
					new MySqlParameter(){ParameterName="@EndTime",MySqlDbType = MySqlDbType.Datetime, Value = _T.EndTime},
					new MySqlParameter(){ParameterName="@BusinessDayDate",MySqlDbType = MySqlDbType.Datetime, Value = _T.BusinessDayDate}

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

        public BusinessDay GetById(string Id)
        {
            try
            {
                return Search(x => x.BusinessDayId.ToString() == Id).SingleOrDefault<BusinessDay>();
            }
            catch (Exception Ew)
            {
                m_Logger.TraceException(Ew.Message, Ew);
                return null;
            }
        }

        public IQueryable<BusinessDay> Search(System.Linq.Expressions.Expression<Func<BusinessDay, bool>> predicate)
        {
            try
            {
				return  this.All.Where (predicate);
            }
            catch(Exception Ew)
            {
                m_Logger.TraceException(Ew.Message, Ew);
                return null;
            }
        }

        public bool Delete(BusinessDay _T)
        {

			string _SQL = "DELETE FROM BusinessDay WHERE BusinessDayId = @BusinessDayId";

			try
			{
				int _Count = (int)MySqlHelper.ExecuteNonQuery(AppConfig.ConnString,_SQL,new MySqlParameter(){ParameterName="@BusinessDayId",MySqlDbType = MySqlDbType.VarChar, Value = _T.BusinessDayId.ToString()});

				if(_Count > 0) return true;
				return false;
			}
			catch (Exception Ew)
			{
				m_Logger.TraceException(Ew.Message, Ew);
				return false;
			}
        }

		public bool Update(BusinessDay _T){

			string _Sql = "UPDATE BusinessDay SET  StartTime = @StartTime,EndTime = @EndTime ,BusinessDayDate = @BusinessDayDate WHERE BusinessDayId = @BusinessDayId";
			List<MySqlParameter> _Parameters = null;
			try
			{
				_Parameters = new List<MySqlParameter>
				{
					new MySqlParameter(){ParameterName="@BusinessDayId",MySqlDbType = MySqlDbType.VarChar, Value = _T.BusinessDayId.ToString()},
					new MySqlParameter(){ParameterName="@StartTime",MySqlDbType = MySqlDbType.Datetime, Value = _T.StartTime},
					new MySqlParameter(){ParameterName="@EndTime",MySqlDbType = MySqlDbType.Datetime, Value = _T.EndTime},
					new MySqlParameter(){ParameterName="@BusinessDayDate",MySqlDbType = MySqlDbType.Datetime, Value = _T.BusinessDayDate}

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
