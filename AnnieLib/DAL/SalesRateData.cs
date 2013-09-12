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
    public class SalesRateData :IRepository<SalesRate>,IDisposable
    {
       
        private Logger m_Logger;
        public SalesRateData()
        {
            
            m_Logger = LogManager.GetCurrentClassLogger();
        }
        public IQueryable<SalesRate> All
		{
			get {
				string _Sql = "SELECT * FROM SalesRates";
				MySqlDataReader _Reader = null;
				List<SalesRate> _SaleRates =  null;
				try {
					_Reader = MySqlHelper.ExecuteReader (AppConfig.ConnString, _Sql);
					if (_Reader != null) {
						_SaleRates = new List<SalesRate>();

						if (_Reader.HasRows) 
						{
							while (_Reader.Read()) 
							{
								var _SalesRate = new SalesRate () 
								{
									SalesRateId =  Guid.Parse(_Reader["SalesRateId"].ToString()),
									Rate =   Convert.ToDouble(_Reader["Rate"]),
									FluidId =  Guid.Parse(_Reader["FluidId"].ToString()),
									Fluid =  null

								};

								_SaleRates.Add (_SalesRate);
							}
						}
					}
					return _SaleRates as IQueryable<SalesRate>;
				} catch (Exception Ew) {
					m_Logger.TraceException (Ew.Message, Ew);
					return null;
				} finally {

					if (_Reader != null) {

						if (!_Reader.IsClosed)
							_Reader.Close ();
					}

				}
			}
		}

        public bool Save(SalesRate _T)
        {
				string _Sql = "INSERT INTO SaleRates(SalesRateId,Rate,FluidId) VALUES(@SalesRateId,@Rate,@FluidId)";
				List<MySqlParameter> _Parameters = null;
            try
            {
              _Parameters = new List<MySqlParameter>()
				{
					new MySqlParameter(){ParameterName="@SalesRateId",MySqlDbType = MySqlDbType.VarChar, Value = _T.SalesRateId},
					new MySqlParameter(){ParameterName="@Rate",MySqlDbType = MySqlDbType.Double, Value = _T.Rate},
					new MySqlParameter(){ParameterName="@FluidId",MySqlDbType = MySqlDbType.VarChar, Value = _T.FluidId.ToString()}

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

        public SalesRate GetById(string Id)
        {
            try
            {
				return this.All.Where(x => x.FluidId.ToString() == Id).SingleOrDefault();
            }
            catch (Exception Ew)
            {
                m_Logger.TraceException(Ew.Message, Ew);
                return null;
            }
        }

        public IQueryable<SalesRate> Search(System.Linq.Expressions.Expression<Func<SalesRate, bool>> predicate)
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

        public bool Delete(SalesRate _T)
        {
			string _Sql = "DELETE FROM SalesRates where SalesRateId = @SalesRateId";
            try
            {

				int _count = MySqlHelper.ExecuteNonQuery(AppConfig.ConnString,_Sql, new MySqlParameter(){ParameterName="@SalesRateId",MySqlDbType = MySqlDbType.VarChar, Value = _T.SalesRateId.ToString()} );  
                
				if(_count > 0) return true;

				return false;
            }
            catch (Exception Ew)
            {
                m_Logger.TraceException(Ew.Message, Ew);
                return false;
            }
        }


		public bool Update(SalesRate _T)
		{

			string _Sql = "UPDATE SaleRates  SET Rate =  @Rate, FluidId  =  @FluidId WHERE SalesRateId = @SalesRateId";
			List<MySqlParameter> _Parameters = null;
			try
			{
				_Parameters = new List<MySqlParameter>()
				{
					new MySqlParameter(){ParameterName="@SalesRateId",MySqlDbType = MySqlDbType.VarChar, Value = _T.SalesRateId},
					new MySqlParameter(){ParameterName="@Rate",MySqlDbType = MySqlDbType.Double, Value = _T.Rate},
					new MySqlParameter(){ParameterName="@FluidId",MySqlDbType = MySqlDbType.VarChar, Value = _T.FluidId.ToString()}

				};
				 
				int _Count  =  MySqlHelper.ExecuteNonQuery(AppConfig.ConnString,_Sql,_Parameters.ToArray());

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
