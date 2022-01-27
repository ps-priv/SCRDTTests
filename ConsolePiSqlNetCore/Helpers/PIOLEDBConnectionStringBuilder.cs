using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePiSqlNetCore.Helpers
{
    /// <summary>
    /// Tworzy connection string zgodny z dokumentacją PI SQL Ado.Net
    ///         OleDbConPI = New OleDbConnection("Provider = PIOLEDB; " _
    //& "Data Source = " _
    //& strServer.Text _
    //& " ; User ID = " _
    //& strUser.Text _
    //& "; Password = " _
    //& strPassword.Text _
    //& "; Log File = c:\temp\Tutorial3.log" _
    //& ";")
    /// </summary>
    internal class PIOLEDBConnectionStringBuilder
    {
        private string _connectionString;

        public PIOLEDBConnectionStringBuilder()
        {
            _connectionString = "Provider = PIOLEDB; ";
        }

        public string Build()
        {
            if (!_connectionString.EndsWith(";"))
                _connectionString += ";";

            return _connectionString;
        }

        public PIOLEDBConnectionStringBuilder AddDataSource(string server)
        {
            _connectionString += $"Data Source = {server}";
            return this;
        }

        public PIOLEDBConnectionStringBuilder AddUser(string user)
        {
            _connectionString += $" ; User ID = {user}";
            return this;
        }

        public PIOLEDBConnectionStringBuilder AddPassword(string pass)
        {
            _connectionString += $"; Password = {pass}";
            return this;
        }

        public PIOLEDBConnectionStringBuilder AddPathToLogFile(string path)
        {
            _connectionString += $"; Log File = {path}";
            return this;
        }
    }
}