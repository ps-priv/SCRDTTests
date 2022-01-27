// See https://aka.ms/new-console-template for more information
using ConsolePiSqlNetCore.Helpers;
using ConsolePiSqlNetCore.Tester;

Console.WriteLine("Start");

//Tworzymy connection stringa do bazy danych
var piConnectionString = new PIOLEDBConnectionStringBuilder()
    .AddDataSource("FakeServerIP")
    .AddUser("SA")
    .AddPassword("password")
    .AddPathToLogFile("dbtester.log")
    .Build();

Console.WriteLine($"Connection string: {piConnectionString.ToString()}");

var tester = new OleDbDatabaseTester(piConnectionString);
tester.GetData(SqlQueryHelper.EmptyQuery);

Console.WriteLine("Koniec");
Console.ReadKey();