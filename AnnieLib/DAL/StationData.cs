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
    public class StationData :IRepository<Station>,IDisposable
    {
        
        private Logger m_Logger;
        public StationData()
        {
         
            m_Logger = LogManager.GetCurrentClassLogger();
        }
        public IQueryable<Station> All
        {
            get 
            {
				string _Sql = "SELECT * FROM Stations";
				MySqlDataReader _Reader = null;
				List<Station> _Stations = null;

                try
                {
					_Reader =  MySqlHelper.ExecuteReader(AppConfig.ConnString,_Sql);
					if(_Reader != null){
						_Stations =  new List<Station>();
						if(_Reader.HasRows){

							var _Station = new Station
							{
								StationId = Guid.Parse(_Reader["StationId"].ToString()),
								StationUniqueKey = _Reader["StationUniqueKey"].ToString(),
								StationName = _Reader["StationName"].ToString(),
								StationAdressLineOne = _Reader["StationAdressLineOne"].ToString(),
								StationAdressLineTwo = _Reader["StationAdressLineTwo"].ToString(),
								City = _Reader["City"].ToString(),
								State = _Reader["State"].ToString()
							};

							_Stations.Add(_Station);
						}

					}
					return _Stations as IQueryable<Station>;
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

        public bool Save(Station _T)
        {
			string _Sql = "INSERT INTO Stations(StationId,StationUniqueKey,StationName,StationAdressLineOne,StationAdressLineTwo,City,State) VALUES(@StationId,@StationUniqueKey,@StationName,@StationAdressLineOne,@StationAdressLineTwo,@City,@State)";
			List<MySqlParameter> _Parameters = null;
            try
            {
				_Parameters  = new List<MySqlParameter>
				{
					new MySqlParameter(){ParameterName="@StationId",MySqlDbType = MySqlDbType.VarChar, Value = _T.StationId.ToString()},
					new MySqlParameter(){ParameterName="@StationUniqueKey",MySqlDbType = MySqlDbType.VarChar, Value = _T.StationUniqueKey},
					new MySqlParameter(){ParameterName="@StationName",MySqlDbType = MySqlDbType.VarChar, Value = _T.StationName},
					new MySqlParameter(){ParameterName="@StationAdressLineOne",MySqlDbType = MySqlDbType.VarChar, Value = _T.StationAdressLineOne},
					new MySqlParameter(){ParameterName="@StationAdressLineTwo",MySqlDbType = MySqlDbType.VarChar, Value = _T.StationAdressLineTwo},
					new MySqlParameter(){ParameterName="@City",MySqlDbType = MySqlDbType.VarChar, Value = _T.City},
					new MySqlParameter(){ParameterName="@State",MySqlDbType = MySqlDbType.VarChar, Value = _T.State},
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

        public Station GetById(string Id)
        {
            try
            {
                return  this.All.Where(x=>x.StationId.ToString() == Id).SingleOrDefault();
            }
            catch (Exception Ew)
            {
                m_Logger.TraceException(Ew.Message, Ew);
                return null;
            }
        }

        public IQueryable<Station> Search(System.Linq.Expressions.Expression<Func<Station, bool>> predicate)
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

        public bool Delete(Station _T)
        {
			string _Sql = "DELETE FROM Stations WHERE StationId =  @StationId";
            try
            {
				int _count = MySqlHelper.ExecuteNonQuery(AppConfig.ConnString,_Sql,new MySqlParameter{ParameterName="@StationId",MySqlDbType = MySqlDbType.VarChar, Value = _T.StationId.ToString()});
                
				if(_count > 0) return true;


                return false;
            }
            catch (Exception Ew)
            {
                m_Logger.TraceException(Ew.Message, Ew);
                return false;
            }
        }

		public bool Update(Station _T){


			string _Sql = "UPDATE  Stations  SET StationUniqueKey = @StationUniqueKey , StationName = @StationName ,StationAdressLineOne = @StationAdressLineOne , StationAdressLineTwo = @StationAdressLineTwo,City = @City,State = @State WHERE StationId = @StationId";
			List<MySqlParameter> _Parameters = null;
			try
			{
				_Parameters  = new List<MySqlParameter>
				{
					new MySqlParameter(){ParameterName="@StationId",MySqlDbType = MySqlDbType.VarChar, Value = _T.StationId.ToString()},
					new MySqlParameter(){ParameterName="@StationUniqueKey",MySqlDbType = MySqlDbType.VarChar, Value = _T.StationUniqueKey},
					new MySqlParameter(){ParameterName="@StationName",MySqlDbType = MySqlDbType.VarChar, Value = _T.StationName},
					new MySqlParameter(){ParameterName="@StationAdressLineOne",MySqlDbType = MySqlDbType.VarChar, Value = _T.StationAdressLineOne},
					new MySqlParameter(){ParameterName="@StationAdressLineTwo",MySqlDbType = MySqlDbType.VarChar, Value = _T.StationAdressLineTwo},
					new MySqlParameter(){ParameterName="@City",MySqlDbType = MySqlDbType.VarChar, Value = _T.City},
					new MySqlParameter(){ParameterName="@State",MySqlDbType = MySqlDbType.VarChar, Value = _T.State},
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
