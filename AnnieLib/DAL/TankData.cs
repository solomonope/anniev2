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
	public class TankData:IRepository<TankActivity>,IDisposable
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
				try
				{

				}
				catch(Exception Ew)
				{
					m_Logger.TraceException(Ew.Message, Ew);
					return false;
				}
				finally
				{

				}

			}
		}

		public bool Save(Tank _T)
		{
			try
			{
				return true;

			}catch(Exception Ew){
				return false;
			}
		}


		public Tank GetById(string Id)
		{
			try
			{
				return null;

			}catch(Exception Ew)
			{
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
	}
}

