using System;
using System.Diagnostics;
using System.Globalization;

namespace ParsingBenchmark
{
    class Program
    {
        private const int Iterations = 1000000;
        private const string Input = "1:10,5:20,10:30,50:40,100:50,500:60;1000:70,2000:80,5000:90,10000:100";

        static void Main(string[] args)
        {
            Console.WriteLine("Starting Benchmark...");
            Console.WriteLine($"Iterations: {Iterations:N0}");
            Console.WriteLine($"Input: {Input}");
            Console.WriteLine("--------------------------------------------------");

            // Warm up
            ParseOld(Input);
            ParseNew(Input);

            // Benchmark Old
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            var startAllocatedOld = GC.GetAllocatedBytesForCurrentThread();
            var sw = Stopwatch.StartNew();
            for (int i = 0; i < Iterations; i++)
            {
                ParseOld(Input);
            }
            sw.Stop();
            var endAllocatedOld = GC.GetAllocatedBytesForCurrentThread();
            var timeOld = sw.ElapsedMilliseconds;
            var allocOld = (endAllocatedOld - startAllocatedOld);

            Console.WriteLine($"Old Logic (string.Split):");
            Console.WriteLine($"  Time: {timeOld} ms");
            Console.WriteLine($"  Allocated: {allocOld:N0} bytes");

            // Benchmark New
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            var startAllocatedNew = GC.GetAllocatedBytesForCurrentThread();
            sw.Restart();
            for (int i = 0; i < Iterations; i++)
            {
                ParseNew(Input);
            }
            sw.Stop();
            var endAllocatedNew = GC.GetAllocatedBytesForCurrentThread();
            var timeNew = sw.ElapsedMilliseconds;
            var allocNew = (endAllocatedNew - startAllocatedNew);

            Console.WriteLine($"New Logic (ReadOnlySpan):");
            Console.WriteLine($"  Time: {timeNew} ms");
            Console.WriteLine($"  Allocated: {allocNew:N0} bytes");
            Console.WriteLine("--------------------------------------------------");

            var speedup = (double)timeOld / timeNew;
            var allocDiff = allocOld - allocNew;
            var savings = allocOld > 0 ? (double)allocDiff / allocOld * 100 : 0;

            Console.WriteLine($"Speedup: {speedup:F2}x faster");
            Console.WriteLine($"Memory Savings: {savings:F2}% less allocation");
        }

        static void ParseOld(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return;
            var sections = input.Split(';');
            for (int i = 0; i < sections.Length; i++)
            {
                if (i >= 2) break;
                var section = sections[i];
                if (string.IsNullOrWhiteSpace(section)) continue;
                var items = section.Split(',');
                foreach (var item in items)
                {
                    var trimmed = item.Trim();
                    if (string.IsNullOrEmpty(trimmed)) continue;
                    var parts = trimmed.Split(':');
                    if (parts.Length == 2)
                    {
                        decimal.TryParse(parts[0], NumberStyles.Any, CultureInfo.InvariantCulture, out _);
                        int.TryParse(parts[1], NumberStyles.Integer, CultureInfo.InvariantCulture, out _);
                    }
                }
            }
        }

        static void ParseNew(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return;
            ReadOnlySpan<char> span = input.AsSpan();
            int sectionIndex = 0;
            foreach (var sectionRange in span.Split(';'))
            {
                if (sectionIndex >= 2) break;
                var section = span[sectionRange];
                if (section.IsWhiteSpace()) { sectionIndex++; continue; }
                foreach (var itemRange in section.Split(','))
                {
                    var item = section[itemRange];
                    var trimmed = item.Trim();
                    if (trimmed.IsEmpty) continue;
                    int colonIndex = trimmed.IndexOf(':');
                    if (colonIndex >= 0)
                    {
                        var face = trimmed[..colonIndex].Trim();
                        var count = trimmed[(colonIndex + 1)..].Trim();
                        decimal.TryParse(face, NumberStyles.Any, CultureInfo.InvariantCulture, out _);
                        int.TryParse(count, NumberStyles.Integer, CultureInfo.InvariantCulture, out _);
                    }
                }
                sectionIndex++;
            }
        }
    }
}
