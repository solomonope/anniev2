using BitworkSystem.Annie.BO;
using BitworkSystem.Annie.DAL.Contract;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace  BitworkSystem.Annie
{
	public class TankData:IRepository<Tank>,IDisposable
	{

		private Logger m_Logger;
		public TankData()
		{

			m_Logger = LogManager.GetCurrentClassLogger();
		}
	
		public IQueryable<Tank> All {
			get
			{
				string _Sql = "SELECT * FROM Tanks";
				MySqlDataReader _Reader = null;
				List<Tank> _Tanks = null;
				try
				{
					_Reader = MySqlHelper.ExecuteReader(AppConfig.ConnString,_Sql);

					if(_Reader != null){

						_Tanks = new List<Tank>();

						if(_Reader.HasRows)
						{
							while(_Reader.Read())
							{
								var _Tank = new Tank{
									TankId   = Guid.Parse(_Reader["TankId"].ToString()),
									TankName = _Reader["TankName"].ToString(),
									FluidId  = Guid.Parse(_Reader["FluidId"].ToString()),
									Serviceable = Convert.ToBoolean(_Reader["Serviceable"]),
									TankVolume  = Convert.ToDouble(_Reader["TankVolume"]),
									Fluid    = null,
									TankActivities = null,
									TankReadings   = null,
									TankVolumeLoggs = null

								};

								_Tanks.Add(_Tank);
							}

						}
					

					}
					return  _Tanks as IQueryable<Tank>;
				}
				catch(Exception Ew)
				{
					m_Logger.TraceException(Ew.Message, Ew);
					return null;
				}
				finally
				{
					if (_Reader != null) {
						if (!_Reader.IsClosed)
							_Reader.Close ();

					}
				}

			}
		}

		public bool Save(Tank _T)
		{
			string _Sql = "INSERT INTO Tank(TankId,TankName,FluidId,Serviceable,TankVolume) VALUES(@TankId,@TankName,@FluidId,@Serviceable,@TankVolume)";
			List<MySqlParameter> _Parameters = null;
			try
			{
				_Parameters = new List<MySqlParameter>
				{
					new MySqlParameter(){ParameterName="@TankId",MySqlDbType = MySqlDbType.VarChar, Value = _T.TankId.ToString()},
					new MySqlParameter(){ParameterName="@TankName",MySqlDbType = MySqlDbType.VarChar, Value = _T.TankName},
					new MySqlParameter(){ParameterName="@FluidId",MySqlDbType = MySqlDbType.VarChar, Value = _T.FluidId.ToString()},
					new MySqlParameter(){ParameterName="@Serviceable",MySqlDbType = MySqlDbType.Bit, Value = _T.Serviceable},
					new MySqlParameter(){ParameterName="@TankVolume",MySqlDbType = MySqlDbType.Double, Value = _T.TankVolume}

				};

				int _count = MySqlHelper.ExecuteNonQuery(AppConfig.ConnString,_Sql,_Parameters.ToArray());

				if(_count >0) return true;

				return false;

			}catch(Exception Ew){
				m_Logger.TraceException(Ew.Message, Ew);
				return false;
			}
		}


		public Tank GetById(string Id)
		{
			try
			{
				return this.All.Where(x=> x.FluidId.ToString() == Id).SingleOrDefault();

			}catch(Exception Ew)
			{
				m_Logger.TraceException(Ew.Message, Ew);
				return null;

			}

		}



		public IQueryable<Tank> Search(System.Linq.Expressions.Expression<Func<Tank, bool>> predicate)
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


		public bool Update(Tank _T)
		{
			string _Sql = " UPDATE Tank  SET TankName = @TankName , FluidId = @FluidId, Serviceable = @Serviceable ,TankVolume = @TankVolume WHERE TankId = @TankId";
			List<MySqlParameter> _Parameters = null;
			try
			{
				_Parameters = new List<MySqlParameter>
				{
					new MySqlParameter(){ParameterName="@TankId",MySqlDbType = MySqlDbType.VarChar, Value = _T.TankId.ToString()},
					new MySqlParameter(){ParameterName="@TankName",MySqlDbType = MySqlDbType.VarChar, Value = _T.TankName},
					new MySqlParameter(){ParameterName="@FluidId",MySqlDbType = MySqlDbType.VarChar, Value = _T.FluidId.ToString()},
					new MySqlParameter(){ParameterName="@Serviceable",MySqlDbType = MySqlDbType.Bit, Value = _T.Serviceable},
					new MySqlParameter(){ParameterName="@TankVolume",MySqlDbType = MySqlDbType.Double, Value = _T.TankVolume}

				};

				int _count = MySqlHelper.ExecuteNonQuery(AppConfig.ConnString,_Sql,_Parameters.ToArray());

				if(_count >0) return true;

				return false;

			}catch(Exception Ew){
				m_Logger.TraceException(Ew.Message, Ew);
				return false;
			}

		}
		public bool Delete(Tank _T)
		{
			string _Sql = "DELETE FROM Tanks WHERE TankId = @TankId";
			try
			{
				int _Count = MySqlHelper.ExecuteNonQuery(AppConfig.ConnString,_Sql,new MySqlParameter{ParameterName="@TankId",MySqlDbType = MySqlDbType.VarChar, Value = _T.TankId.ToString()});

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

