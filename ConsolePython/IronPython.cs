using IronPython.Hosting;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PythonIron = IronPython.Hosting.Python;

namespace ConsolePython
{
    internal class IronPythonWrapper
    {
        private readonly string _script;

        public IronPythonWrapper(string script)
        {
            _script = script;
        }

        public void Start()
        {
            var engine = PythonIron.CreateEngine();
            var source = engine.CreateScriptSourceFromFile(_script);

            var pythonArgs = new List<int>();
            pythonArgs.Add(5);

            engine.GetSysModule().SetVariable("argv", pythonArgs);

            var eIO = engine.Runtime.IO;

            var errors = new MemoryStream();
            eIO.SetErrorOutput(errors, Encoding.Default);

            var result = new MemoryStream();
            eIO.SetOutput(result, Encoding.Default);

            var scope = engine.CreateScope();
            source.Execute(scope);

            Console.WriteLine($"Errors: {Encoding.Default.GetString(errors.ToArray())}");
            Console.WriteLine($"Result: {Encoding.Default.GetString(result.ToArray())}");
        }

        public void StartBenchmarkOdpalenia()
        {
            var random = new Random();
            var engine = PythonIron.CreateEngine();
            var source = engine.CreateScriptSourceFromFile(_script);

            for (int i = 1; i <= 10; i++)
            {
                var rndValue = random.Next(1, 101);

                using (var bl = new BenchmarkLogger($"IronPythonWrapper próba: {i}"))
                {
                    var pythonArgs = new List<int>();
                    pythonArgs.Add(rndValue);

                    engine.GetSysModule().SetVariable("argv", pythonArgs);

                    var eIO = engine.Runtime.IO;

                    var errors = new MemoryStream();
                    eIO.SetErrorOutput(errors, Encoding.Default);

                    var result = new MemoryStream();
                    eIO.SetOutput(result, Encoding.Default);

                    var scope = engine.CreateScope();
                    source.Execute(scope);

                    Console.WriteLine($"Errors: {Encoding.Default.GetString(errors.ToArray())}");
                    Console.WriteLine($"Result: {Encoding.Default.GetString(result.ToArray())}");
                }
            }
        }
    }
}