using BenchmarkDotNet.Running;
using StringReplacePerformance;

namespace StringReplacePerformance472
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<StringReplaceBenchmark>();
        }
    }
}
