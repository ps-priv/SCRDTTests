using IronPython.Compiler.Ast;

using Python.Runtime;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePython
{
    internal class PythonNetWrapper
    {
        private readonly string _script;

        public PythonNetWrapper(string script)
        {
            _script = script;
        }

        public void Start()
        {
            //Runtime.PythonDLL = @"C:\Python38\python38.dll";
            Runtime.PythonDLL = @"C:\Python39\python39.dll";

            using (Py.GIL())
            {
                //PyObject p = PythonEngine.Compile("", _script, RunFlagType.File);

                PythonEngine.Initialize();
                using (var scope = Py.CreateScope())
                {
                    //var scriptCompiled = PythonEngine.Compile("", _script, RunFlagType.File);
                    string code = File.ReadAllText(_script);
                    var scriptCompiled = PythonEngine.Compile(code);

                    scope.Execute(scriptCompiled);

                    var testPobrania = scope.TryGet("Przyklad", out dynamic FunkcjaPrzyklad);

                    if (testPobrania)
                    {
                        Console.WriteLine("Funkcja znaleziona");
                        var result = FunkcjaPrzyklad(4);
                        Console.WriteLine($"Wynik pythona: {result}");
                    }
                }
            }
        }

        public void StartBenchmarkOdpalenia()
        {
            //Runtime.PythonDLL = @"C:\Python38\python38.dll";
            //Runtime.PythonDLL = @"C:\Python39\python39.dll";
            var random = new Random();

            using (Py.GIL())
            {
                //PyObject p = PythonEngine.Compile("", _script, RunFlagType.File);

                PythonEngine.Initialize();
                using (var scope = Py.CreateScope())
                {
                    //var scriptCompiled = PythonEngine.Compile("", _script, RunFlagType.File);
                    string code = File.ReadAllText(_script);
                    var scriptCompiled = PythonEngine.Compile(code);

                    scope.Execute(scriptCompiled);

                    var testPobrania = scope.TryGet("Przyklad", out dynamic FunkcjaPrzyklad);

                    if (!testPobrania) throw new Exception("Brak funkcji Python");

                    for (int i = 1; i <= 10; i++)
                    {
                        var rndValue = random.Next(1, 101);

                        using (var bl = new BenchmarkLogger($"PythonNetWrapper próba: {i}"))
                        {
                            var result = FunkcjaPrzyklad(rndValue);
                            Console.WriteLine($"Wynik pythona: {result}");
                        }
                    }
                }
            }
        }
    }
}