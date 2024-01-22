Benchmark test for string.Replace(...) and StringBuilder.Replace(...) functions

// * Summary *

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3078/23H2/2023Update/SunValley3)
Intel Core i7-8700 CPU 3.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK 7.0.306
  [Host]             : .NET 7.0.9 (7.0.923.32018), X64 RyuJIT AVX2
  .NET Framework 4.7 : .NET Framework 4.8.1 (4.8.9181.0), X64 RyuJIT VectorSize=256

Job=.NET Framework 4.7  Runtime=.NET Framework 4.7

| Method               | value                | Mean       | Error      | StdDev     |
|--------------------- |--------------------- |-----------:|-----------:|-----------:|
| StringReplace        | qsrt(...) wgo [1000] |   2.069 us |  0.0399 us |  0.0475 us |
| StringBuilderReplace | uerw(...)ggxv [1000] |   4.340 us |  0.0906 us |  0.2657 us |
| StringReplace        | smsx(...)pppc [2000] |   4.174 us |  0.0756 us |  0.0776 us |
| StringBuilderReplace | dwod(...)b ts [2000] |   7.719 us |  0.1429 us |  0.1267 us |
| StringReplace        | pjtv(...)xl c [5000] |  10.230 us |  0.1998 us |  0.2137 us |
| StringBuilderReplace | ihgf(...)kdvt [5000] |  20.162 us |  0.3931 us |  0.5248 us |
| StringReplace        | zix(...)pfo [10000]  |  20.847 us |  0.4112 us |  0.4895 us |
| StringBuilderReplace | bjc(...)x k [10000]  |  38.841 us |  0.7555 us |  1.0085 us |
| StringReplace        | yhl(...)emy [20000]  |  39.750 us |  0.7867 us |  0.9662 us |
| StringBuilderReplace | ptk(...) gq [20000]  |  78.364 us |  1.5217 us |  2.3237 us |
| StringReplace        | bqt(...)kwe [50000]  | 136.417 us |  2.6070 us |  3.0023 us |
| StringBuilderReplace | bae(...)bxh [50000]  | 241.452 us |  4.8090 us |  7.3438 us |
| StringReplace        | khm(...)vnr [100000] | 303.394 us |  6.0452 us |  9.7619 us |
| StringBuilderReplace | auk(...) tf [100000] | 518.021 us | 10.3384 us | 21.8072 us |
