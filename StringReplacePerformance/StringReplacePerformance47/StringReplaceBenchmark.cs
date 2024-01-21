using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace StringReplacePerformance
{

    [SimpleJob(RuntimeMoniker.Net47)]
    //[SimpleJob(RuntimeMoniker.Net471)]
    //[SimpleJob(RuntimeMoniker.Net472)]
    //[SimpleJob(RuntimeMoniker.Net70)]
    public class StringReplaceBenchmark
    {
        private const int MinWordLength = 3;
        private const int MaxWordLength = 12;
        private const string ReplaceString = "Some Old Value";
        private const string NewValue = "New Value is bigger than the old one";

        private readonly string string1000x5 = CreateData(1000, ReplaceString, 5);
        private readonly string string2000x10 = CreateData(2000, ReplaceString, 10);
        private readonly string string5000x20 = CreateData(5000, ReplaceString, 20);
        private readonly string string10000x50 = CreateData(10000, ReplaceString, 50);
        private readonly string string20000x100 = CreateData(20000, ReplaceString, 100);
        private readonly string string50000x200 = CreateData(50000, ReplaceString, 200);
        private readonly string string100000x1000 = CreateData(100000, ReplaceString, 1000);

        private static readonly Random Random = new Random();

        [Benchmark]
        [ArgumentsSource(nameof(GetBenchmarkStrings))]
        public string StringReplace(string value) => value.Replace(ReplaceString, NewValue);

        [Benchmark]
        [ArgumentsSource(nameof(GetBenchmarkStrings))]
        public string StringBuilderReplace(string value) => new StringBuilder(value).Replace(ReplaceString, NewValue).ToString();

        public IEnumerable<string> GetBenchmarkStrings()
        {
            yield return string1000x5;
            yield return string2000x10;
            yield return string5000x20;
            yield return string10000x50;
            yield return string20000x100;
            yield return string50000x200;
            yield return string100000x1000;
        }

        static string CreateData(int dataLength, string replaceString, int replaceStringCount)
        {
            if (dataLength <= 0)
            {
                return string.Empty;
            }

            var data = new StringBuilder(dataLength);
            int replaceStringThreshold = GetReplaceStringThreshold(dataLength, replaceStringCount);
            int nextReplaceStringPosition = replaceStringThreshold;
            int remainReplaceStringCount = replaceStringCount;

            while (data.Length < dataLength)
            {
                if (remainReplaceStringCount > 0 && nextReplaceStringPosition < data.Length)
                {
                    data.Append(replaceString).Append(' ');
                    nextReplaceStringPosition += replaceStringThreshold;
                    remainReplaceStringCount--;
                }

                AddRandomWord(data, GetRandomWordLength(dataLength, data.Length));

                if (data.Length + 1 < dataLength)
                {
                    data.Append(' ');
                }
            }

            return data.ToString();
        }

        static int GetReplaceStringThreshold(int dataLength, int replaceStringCount)
        {
            return replaceStringCount > 0 ? dataLength / (replaceStringCount + 1) : 0;
        }

        static int GetRandomWordLength(int dataLength, int currentLength)
        {
            int remainingLength = dataLength - currentLength;
            return remainingLength > 0 ? Random.Next(Math.Min(MinWordLength, remainingLength), Math.Min(MaxWordLength, remainingLength)) : 0;
        }

        static void AddRandomWord(StringBuilder stringBulder, int wordLength)
        {
            for (int i = 0; i < wordLength; i++)
            {
                stringBulder.Append((char)('a' + Random.Next(0, 26)));
            }
        }
    }
}
