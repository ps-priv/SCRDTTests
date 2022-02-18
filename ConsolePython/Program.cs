// See https://aka.ms/new-console-template for more information

using System.Text;

using ConsolePython;

Console.WriteLine("Start");

//var scriptFile = @".\PyScripts\Przyklad.py"; //wersja iron
var scriptFile = @".\PyScripts\Przyklad2.py";

if (!File.Exists(scriptFile))
{
    Console.WriteLine("Brak pliku");
    Console.ReadLine();
    return;
}

try
{
    using (var bl = new BenchmarkLogger("PythonNetWrapper"))
    {
        new PythonNetWrapper(@".\PyScripts\Przyklad2.py").Start();
    }

    using (var bl = new BenchmarkLogger("IronPythonWrapper"))
    {
        new IronPythonWrapper(@".\PyScripts\Przyklad.py").Start();
    }

    new PythonNetWrapper(@".\PyScripts\Przyklad2.py").StartBenchmarkOdpalenia();

    new IronPythonWrapper(@".\PyScripts\Przyklad.py").StartBenchmarkOdpalenia();
}
catch (Exception e)
{
    Console.WriteLine($"Exception: {e.ToString()}");
}

Console.WriteLine("Koniec");
Console.ReadKey();