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
    public class FluidData:IRepository<Fluid>,IDisposable
    {

       
        private Logger m_Logger;
        public FluidData()
        {
            
            m_Logger = LogManager.GetCurrentClassLogger();
        }
        public IQueryable<Fluid> All
        {
            get 
            {
				string _SQL = "SELECT * FROM  Fluids";
				List<Fluid> _Fluids =  null;
				MySqlReader _Reader = null;
                try
                {
					_Reader =  MySqlHelper.ExecuteReader(AppConfig.ConnString,_SQL);
					if(_Reader != null)
					{
						if(_Reader.HasRows)
						{
							_Fluids = new List<Fluid>();

							while(_Reader.Read())
							{
								var _Fluid  =  new Fluid()
								{
									FluidId =  Convert.ToGuid(_Reader["FluidId"]),
									FluidName =  _Reader["FluidName"].ToString(),
									FluidCode  = _Reader["FluidCode"].ToString()
								};

								_Fluids.Add(_Fluid);

							}
						}
					}
                   return _Fluids;
                }
                catch (Exception Ew)
                {
                    m_Logger.TraceException(Ew.Message, Ew);
                    return null;
                }
            }
        }

        public bool Save(Fluid _T)
        {
            try
            {
				string _Sql = "INSERT INTO Fluid(FluidId,FluidName,FluidCode)  VALUES(@FluidId,@FluidName,@FluidCode)";

				var _Parameters = new  List<MySqlParameter>()
				{
					new MySqlParameter(){ParameterName="@FluidId",MySqlDbType = MySqlDbType.VarChar, Value = _T.ToString()},
					new MySqlParameter(){ParameterName="@FluidName",MySqlDbType = MySqlDbType.VarChar, Value = _T.ToString()},
					new MySqlParameter(){ParameterName="@FluidCode",MySqlDbType = MySqlDbType.VarChar, Value = _T.ToString()}
				};
                
                return true;
            }
            catch (Exception Ew)
            {
                m_Logger.TraceException(Ew.Message, Ew);
                return false;
            }
        }

        public Fluid GetById(string Id)
        {
            try
            {
                //return (from n in this.All where n.FluidId.ToString() == Id select n).SingleOrDefault();

				return this.All.Where(x => x.FluidId.ToString() == Id).SingleOrDefault();
            }
            catch (Exception Ew)
            {
                m_Logger.TraceException(Ew.Message, Ew);
                return null;
            }
        }

        public IQueryable<Fluid> Search(System.Linq.Expressions.Expression<Func<Fluid, bool>> predicate)
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

        public bool Delete(Fluid _T)
        {
            try
            {
				String _SQL = "DELETE FROM Fluids where FluidId = @FluidId";

				var _Count = MySqlHelper.ExecuteScalar(AppConfig.ConnString,_SQL,new MySqlParameter(){ParameterName="@FluidId",MySqlDbType = MySqlDbType.VarChar, Value = _T.FluidId.ToString()});

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
