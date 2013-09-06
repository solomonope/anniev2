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
   public class PumpData:IRepository<Pump> ,IDisposable
   {

       
        private Logger m_Logger;
        public PumpData()
        {
            
            m_Logger = LogManager.GetCurrentClassLogger();
        }
        public IQueryable<Pump> All
        {
            get 
            {
				string _SQL = "SELECT * FROM Pumps";
				MySqlDataReader _Reader = null;
				List<Pump> _Pumps = null;
                try
                {
					_Reader =  MySqlHelper.ExecuteReader(AppConfig.ConnString,_SQL);
					if(_Reader != null)
					{
						if(_Reader.HasRows)
						{
							while(_Reader.Read())
							{
								var _Pump = new Pump()
								{
									PumpId 			= 	Guid.Parse (_Reader["PumpId"].ToString()),
									PumpName	    =  	_Reader["PumpName"].ToString(),
									PumpReadings  	= 	null,
									PumpSales 		=  	null,
									FluidId 		=   Guid.Empty,
									Fluid 			=	null,
									Serviceable 	=   Convert.ToBoolean(_Reader["Serviceable"]) 

								};

								_Pumps.Add(_Pump);
							}
						}
					}
					return _Pumps as IQueryable<Pump>;
                }
                catch (Exception Ew)
                {
                    m_Logger.TraceException(Ew.Message, Ew);
                    return null;
                }finally{
				if (_Reader != null) 
					{
						if (!_Reader.IsClosed) _Reader.Close ();
					}
				}
            }
        }

        public bool Save(Pump _T)
        {
			string _SQL = "INSERT INTO Pumps(PumpId,PumpName,Serviceable) VALUES(@PumpId,@PumpName,@Serviceable)";
			List<MySqlParameter> _Parameters = null;
            try
            {
                _Parameters =  new List<MySqlParameter>()
				{
					new MySqlParameter(){ParameterName="@PumpId",MySqlDbType = MySqlDbType.VarChar, Value = _T.PumpId.ToString()},
					new MySqlParameter(){ParameterName="@PumpName",MySqlDbType = MySqlDbType.VarChar, Value = _T.PumpName.ToString()},
					new MySqlParameter(){ParameterName="@Serviceable",MySqlDbType = MySqlDbType.Bit, Value = _T.Serviceable.ToString()}
				};
				MySqlHelper.ExecuteNonQuery(AppConfig.ConnString,_SQL,_Parameters.ToArray());
                return true;
            }
            catch (Exception Ew)
            {
                m_Logger.TraceException(Ew.Message, Ew);
                return false;
            }
        }

        public Pump GetById(string Id)
        {
            try
            {
                return this.All.Where(x=> x.Fluid.ToString() == Id).SingleOrDefault();
            }
            catch (Exception Ew)
            {

                m_Logger.TraceException(Ew.Message, Ew);
                return null;
            }
        }

        public IQueryable<Pump> Search(System.Linq.Expressions.Expression<Func<Pump, bool>> predicate)
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

        public bool Delete(Pump _T)
        {
			string _SQL = "DELETE FROM Pump WHERE PumpId = @PumpId ";

            try
            {
				int _Count = (int)MySqlHelper.ExecuteNonQuery(AppConfig.ConnString,_SQL,new MySqlParameter(){ParameterName="@PumpId",MySqlDbType = MySqlDbType.VarChar, Value = _T.PumpId.ToString()});

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
