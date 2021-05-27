using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Model;
using Mono.Data.Sqlite;

namespace Persistence.database
{
	public static class DbUtils
	{
		private static IDbConnection instance = null;

		public static IDbConnection getConnection()
		{
			if (instance == null || instance.State == System.Data.ConnectionState.Closed)
			{
				instance = getNewConnection();
				instance.Open();
			}
			return instance;
		}

		private static IDbConnection getNewConnection()
		{
			return ConnectionFactory.getInstance().createConnection();

		}
	}

	public abstract class ConnectionFactory
	{
		protected ConnectionFactory()
		{
		}

		private static ConnectionFactory instance;

		public static ConnectionFactory getInstance()
		{
			if (instance == null)
			{

				Assembly assem = Assembly.GetExecutingAssembly();
				Type[] types = assem.GetTypes();
				foreach (var type in types)
				{
					if (type.IsSubclassOf(typeof(ConnectionFactory)))
						instance = (ConnectionFactory)Activator.CreateInstance(type);
				}
			}
			return instance;
		}

		public abstract IDbConnection createConnection();
	}

	public class SqliteConnectionFactory : ConnectionFactory
	{
		public override IDbConnection createConnection()
		{
			Console.WriteLine("Creating sqlite connection");
			String connectionString = "DataSource=C:\\Users\\HP\\Desktop\\Database\\flightcompanyC#.db;Version=3;";

			return new SqliteConnection(connectionString);
		}
	}
}
