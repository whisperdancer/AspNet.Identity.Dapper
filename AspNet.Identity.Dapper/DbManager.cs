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
    public class DbManager : IDisposable
    {
        private IDbConnection _conn { get; set; }
        public IDbConnection Connection
        {
            get
            {
                if (_conn.State == ConnectionState.Closed)
                    _conn.Open();

                return _conn;
            }
        }

        public DbManager(string connString)
        {
            // Use first?
            if (connString == "")
                connString = ConfigurationManager.ConnectionStrings[0].Name;

            _conn = new SqlConnection(connString);
        }

        /// <summary>
        /// Provides access to the currently open shared connection (or null if none)
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
