using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Mono.Data.Sqlite;
using System.Data.SQLite;
using System.Configuration;

namespace ConnectionUtils
{
	public class SqliteConnectionFactory : ConnectionFactory
	{
		public override IDbConnection createConnection()
		{
			// Mono Sqlite Connection
			// String connectionString = "URI=file:C:\\Users\\HP\\Desktop\\Database\\flightcompanyC#.db,Version=3";

			// Windows Sqlite Connection
			  String connectionString = "DataSource=C:\\Users\\HP\\Desktop\\Database\\flightcompanyC#.db;Version=3;";
			// String connectionString = ConfigurationManager.ConnectionStrings["databaseConfigure"].ConnectionString;

			return new SQLiteConnection(connectionString);

		}
	}
}
