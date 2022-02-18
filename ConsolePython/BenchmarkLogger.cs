using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePython
{
    public class BenchmarkLogger : IDisposable
    {
        private readonly Stopwatch _timer = new Stopwatch();
        private readonly string _benchmarkName;

        public BenchmarkLogger(string benchmarkName)
        {
            _benchmarkName = benchmarkName;
            _timer.Start();
        }

        public void Dispose()
        {
            _timer.Stop();

            var timerInfo = $"Czas realizacji {_benchmarkName}: {_timer.Elapsed.ToString()}";

            Console.WriteLine($"{_benchmarkName} => Czas realizacji: {_timer.Elapsed.ToString()}");
        }
    }
}