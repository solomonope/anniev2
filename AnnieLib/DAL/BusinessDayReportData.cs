using BitworkSystem.Annie.BO;
using BitworkSystem.Annie.DAL.Contract;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace BitworkSystem.Annie.DAL
{
    public class BusinessDayReportData:IRepository<BusinessDayReport>,IDisposable
    {
        
        private Logger m_Logger;

        public BusinessDayReportData()
        {
           
            m_Logger = LogManager.GetCurrentClassLogger();
        }
        public IQueryable<BusinessDayReport> All
        {
            
           get
            {
				string _Sql = "SELECT * FROM businessdayreports";
				List<BusinessDayReport> _BusinessDayReports = null;
				MySqlDataReader _Reader = null;
                try
                {
					 _Reader = MySqlHelper.ExecuteReader(AppConfig.ConnString,_Sql);
					if(_Reader != null)
					{
						if(_Reader.HasRows)
						{

							_BusinessDayReports = new List<BusinessDayReport>();
							while(_Reader.Read())
							{
								var _BusinessDayReport = new  BusinessDayReport();
								//_BusinessDayReport.

								_BusinessDayReports.Add(_BusinessDayReport);
							}
							return _BusinessDayReports as IQueryable<BusinessDayReport>;
						}else{
							return null;
						}

					}else
					{
					return null;
					}
                }
                catch (Exception Ew)
                {
                   
                    m_Logger.TraceException(Ew.Message, Ew);
                    return null;
                }
				finally
				{
					if (_Reader != null && !(_Reader.IsClosed)) 
					{
						_Reader.Close ();

					}
				}

						
           
            }
        }

        public bool Save(BusinessDayReport _T)
        {
            try
            {
				string _Sql = "INSERT INTO businessdayreport() VALUES(@Id,?)";

				var _Parameters =  new List<MySqlParameter>()
				{
					new MySqlParameter(){ParameterName="",MySqlDbType = MySqlDbType.VarChar, Value = _T.ToString()}
				};

				MySqlHelper.ExecuteNonQuery(AppConfig.ConnString,_Sql,_Parameters.ToArray());
				
               
                return true;
            }
            catch (Exception Ew)
            {
                m_Logger.TraceException(Ew.Message, Ew);
                return false;
            }
        }

        public BusinessDayReport GetById(string Id)
        {
            try
            {
                return this.Search(x => x.ToString() == Id).SingleOrDefault();
            }
            catch (Exception Ew)
            {
                m_Logger.TraceException(Ew.Message, Ew);
                return null; 
            }
        }

        public IQueryable<BusinessDayReport> Search(System.Linq.Expressions.Expression<Func<BusinessDayReport, bool>> predicate)
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

        public bool Delete(BusinessDayReport _T)
        {
            try
            {
				string _Sql = "DELETE from businessdayreport WHERE Id = @Id";

				var _Parameter =  new MySqlParameter(){ParameterName="@Id",MySqlDbType = MySqlDbType.VarChar, Value = _T.ToString()};
				int _Count = (int)MySqlHelper.ExecuteNonQuery(AppConfig.ConnString,_Sql,_Parameter);
				if(_Count<0) return false;
                return true;
            }
            catch (Exception Ew)
            {
                m_Logger.TraceException(Ew.Message, Ew);
                return false;
            }
        }


		public bool Update(BusinessDayReport _T){

			try
			{
				string _Sql = "INSERT INTO businessdayreport() VALUES(@Id,?)";

				var _Parameters =  new List<MySqlParameter>()
				{
					new MySqlParameter(){ParameterName="",MySqlDbType = MySqlDbType.VarChar, Value = _T.ToString()}
				};

				MySqlHelper.ExecuteNonQuery(AppConfig.ConnString,_Sql,_Parameters.ToArray());


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
