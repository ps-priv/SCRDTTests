using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.OleDb;
using ConsolePiSqlNetCore.Helpers;

namespace ConsolePiSqlNetCore.Tester
{
    internal class OleDbDatabaseTester
    {
        private string _connectionString;

        public OleDbDatabaseTester(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void GetData(string sqlQuery)
        {
            using (var dbConnection = new DbFactory().CreateOleDbConnection(_connectionString))
            {
                try
                {
                    dbConnection.Open();

                    dbConnection.Close();
                }
                catch (OleDbException oleEx)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("OleDbException: " + oleEx.Message);
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Exception: " + ex.Message);
                }
                finally
                {
                    if (dbConnection != null)
                        if (dbConnection.State != System.Data.ConnectionState.Closed)
                            dbConnection.Close();
                }
            }
        }
    }
}