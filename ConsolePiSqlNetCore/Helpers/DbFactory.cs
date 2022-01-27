using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePiSqlNetCore.Helpers
{
    internal class DbFactory
    {
        public OleDbConnection CreateOleDbConnection(string connectionString)
        {
            var connection = new OleDbConnection(connectionString);

            return connection;
        }
    }
}