using MyProject.DAL.Constants;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.DAL.Repositories
{
   public class BaseRepository
    {
        private string _connectionString;
        private SqlQueryExecutor _queryExecutor;

        public SqlQueryExecutor QueryExecutor { get { return _queryExecutor; } }
        public string ConnectionString
        {
            get
            {
                return _connectionString;
            }
            set
            {
                _connectionString = ConfigurationManager.ConnectionStrings[value].ToString();
                _queryExecutor = new SqlQueryExecutor(_connectionString);
            }
        }

        public BaseRepository()
        {
            ConnectionString = DbConnectionString.ProjectDB;
        }
    }

    public class BaseOracleRepository : BaseRepository
    {
        public BaseOracleRepository()
        {
            ConnectionString = DbConnectionString.OracleDB;
        }
    }
}
