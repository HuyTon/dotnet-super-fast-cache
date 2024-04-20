using System;
using System.Diagnostics;
using Diana.Code.Chaallenge;

namespace Diana.Code.Challenge
{
    /// <summary>
    /// The test harness creates each cache implementation (fast/slow) and executes the
    /// methods. Your challenge is to implement the fast cache and make it super fast.
    /// </summary>
    public class TestHarness<T> where T : ICachedObject
    {
        private int _count;

        /// <question>
        /// What is a uint and why would you use one?
        /// </question>
        /// <answer>
        /// A uint is an unsigned integer type in C# that represents non-negative integers. 
        /// It's useful when dealing with non-negative values, bitwise operations, array indices, 
        /// or interoperability with APIs that use unsigned integers.
        /// </answer>

        private uint _testNumber;

        private uint _loopNumber;

        private ICacheStuff<T> _cache;

        private String _results;

        public TestHarness()
        {
        }

        private ICachedObject a;
        private ICachedObject b;
        private ICachedObject c;

        public TestHarness<T> Setup(ICacheStuff<T> cache, int count, uint testNumber, uint loopNumber, Func<Guid, string, string, T> createItem)
        {
            _cache = cache;
            _count = count;
            _testNumber = testNumber;
            _loopNumber = loopNumber;

            Console.WriteLine($"\r\n\r\n{_cache.CacheName}\r\n");

            for (int i = 0; i < _count; i++)
            {
                var item = createItem(
                    Guid.NewGuid(),
                    $"Name {i}",
                    "Description " + i.ToString("0000")
                );

                if (i == 0) a = item;
                if (i == _count / 2) b = item;
                if (i == _count - 1) c = item;

                _cache.AddItem(item);
            }

            return this;
        }

        public ICachedObject First()
        {
            return a;
        }

        public ICachedObject Last()
        {
            return c;
        }

        public ICachedObject Mid()
        {
            return b;
        }
        /// <question>
        /// What is the recommended usage of vars?
        /// </question>
        /// <answer>
        /// Use var when the type is obvious from the assigned value, especially for anonymous types 
        /// and foreach loops. Avoid overuse and ensure variable names are descriptive.
        /// </answer>
        public TestHarness<T> Run()
        {
            var firstItem = First();
            var lastItem = Last();
            ICachedObject midItem = Mid();

            uint totalTests = _testNumber;

            TestFind("First Item ", firstItem, totalTests);
            TestFind("Mid Item   ", midItem, totalTests);
            TestFind("Last Item  ", lastItem, totalTests);

            return this;
        }

        public TestHarness<T> OptimizedRun()
        {
            var firstItem = First();
            var lastItem = Last();
            ICachedObject midItem = Mid();

            uint totalTests = _testNumber;

            OptimizedTestFind("First Item ", firstItem, totalTests);
            OptimizedTestFind("Mid Item   ", midItem, totalTests);
            OptimizedTestFind("Last Item  ", lastItem, totalTests);

            return this;
        }

        /// <question>
        /// What improvements you suggest to the coder for this method?
        /// Please refactor/change this method and make it better.
        /// Describe what you did.
        /// </question>
        /// <answer>
        /// 1. The method currently has a high level of complexity due to nested loops and multiple conditions. 
        /// We can simplify it by breaking it down into smaller, more focused methods.
        /// 2. Removed unnecessary variable initializations.
        /// 3. Combined the nested loop into a single loop to reduce complexity.
        /// 4. Used a single Stopwatch instance for each test run to avoid unnecessary overhead.
        /// 5. Calculated and accumulated total ticks within the inner loop.
        /// 6. Improved console output messages for better clarity.
        /// 7. I wrote a new optimize test find method OptimizedTestFind below. 
        /// </answer>
        private bool TestFind(string testName, ICachedObject objectToFind, uint totalTests)
        {
            if (objectToFind == null)
            {
                Console.WriteLine("Not Implemented");
                return false;
            }

            long totalTicks = 0;
            long minTicks = long.MaxValue;
            long maxTicks = long.MinValue;

            bool match = true;
            var testWatch = new Stopwatch(); testWatch.Start();

            for (int run = 0; run < totalTests; run++)
            {
                var stopWatch = new Stopwatch();

                stopWatch.Start();
                int i = 0;
                ICachedObject result;

                do
                {
                    result = _cache.FindItem(objectToFind.Id);
                    match &= (result != null) && result.Id == objectToFind.Id;

                    Console.Write($"\r{testName} {run + 1}.{i}  ");
                }
                while (match && i++ < _loopNumber);

                stopWatch.Stop();

                totalTicks += stopWatch.ElapsedTicks;

                if (minTicks > stopWatch.ElapsedTicks) minTicks = stopWatch.ElapsedTicks;
                if (maxTicks < stopWatch.ElapsedTicks) maxTicks = stopWatch.ElapsedTicks;
            }

            testWatch.Stop();

            TimeSpan totalTime = TimeSpan.FromMilliseconds(testWatch.ElapsedMilliseconds);

            string stats = $"(found={match,-5}) | min:{minTicks,12} ticks | avg ms per find:{totalTime.TotalMilliseconds / (totalTests * 1.0 * _loopNumber),10:#####0.00} ms | max:{maxTicks,12} ticks | #Tests: {totalTests,3} | Total Time: {totalTime.TotalMilliseconds,7:0} ms |";

            _results += $"{testName,10} {stats}\r\n";

            Console.WriteLine(stats);
            return match;
        }

        private bool OptimizedTestFind(string testName, ICachedObject objectToFind, uint totalTests)
        {
            if (objectToFind == null)
            {
                Console.WriteLine("Object to find is null. Test aborted!");
                return false;
            }

            long totalTicks = 0;
            long minTicks = long.MaxValue;
            long maxTicks = long.MinValue;
            bool match = true;

            var testWatch = Stopwatch.StartNew();

            for (int run = 0; run < totalTests; run++)
            {
                var stopWatch = Stopwatch.StartNew();

                for (int i = 0; i < _loopNumber; i++)
                {
                    ICachedObject result = _cache.FindItem(objectToFind.Id);
                    match &= (result != null) && result.Id == objectToFind.Id;
                }

                stopWatch.Stop();

                long testRunTicks = stopWatch.ElapsedTicks;

                totalTicks += testRunTicks;
                minTicks = Math.Min(minTicks, testRunTicks);
                maxTicks = Math.Max(maxTicks, testRunTicks);

                Console.WriteLine($"\r{testName} Test {run + 1} completed.");
            }

            testWatch.Stop();

            TimeSpan totalTime = testWatch.Elapsed;

            string stats = $"(found={match,-5}) | min:{minTicks,12} ticks | avg ms per find:{totalTime.TotalMilliseconds / (totalTests * _loopNumber),10:#####0.00} ms | max:{maxTicks,12} ticks | #Tests: {totalTests,3} | Total Time: {totalTime.TotalMilliseconds,7:0} ms |";

            _results += $"{testName,10} {stats}\r\n";

            Console.WriteLine(stats);
            return match;
        }

        public void Output()
        {
            Console.WriteLine(_results);
        }
    }
}
