using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNet.Identity.Dapper
{
    /// <summary>
    /// A simple database connection manager
    /// </summary>
    public class DbManager : IDisposable
    {
        private IDbConnection _conn { get; set; }
        
        /// <summary>
        /// Return open connection
        /// </summary>
        public IDbConnection Connection
        {
            get
            {
                if (_conn.State == ConnectionState.Closed)
                    _conn.Open();

                return _conn;
            }
        }

        /// <summary>
        /// Create a new Sql database connection
        /// </summary>
        /// <param name="connString">The name of the connection string</param>
        public DbManager(string connString)
        {
            // Use first?
            if (connString == "")
                connString = ConfigurationManager.ConnectionStrings[0].Name;

            _conn = new SqlConnection(connString);
        }

        /// <summary>
        /// Close and dispose of the database connection
        /// </summary>
        public void Dispose()
        {
            if (_conn != null)
            {
                if (_conn.State == ConnectionState.Open)
                {
                    _conn.Close();
                    _conn.Dispose();
                }
                _conn = null;
            }
        }
    }

}
