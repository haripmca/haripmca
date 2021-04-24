using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ConsolidatedBilling.DataAccess.Tests")]

namespace ConsolidatedBilling.DataAccess
{
    public class BaseRepository
    {
        readonly string ConnectionString;

        public BaseRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        /// <summary>
        /// Creates a mysql connection using the connecting string provided by the repository
        /// </summary>
        /// <returns>A MySqlConneciton object</returns>
        public IDbConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}