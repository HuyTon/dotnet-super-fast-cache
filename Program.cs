using System;
using System.Diagnostics;
using System.Linq;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using Diana.Code.Chaallenge;

/// <summary>
/// Please see the readme.md for details and information.
/// </summary>
namespace Diana.Code.Challenge
{
    /// <question>
    /// Please review the program below and refactor/change as required.
    /// </question>
    /// <answer>
    /// Fix code below.
    /// </answer>
    class Program
    {
        private static string _azureServiceKey = "";

        private static string azureSecret = "";

        private static readonly int _cacheSize = 999_999;

        private static readonly uint _testNumber = 3;

        private static readonly uint _testLoopNumber = 100;

        static void Main(string[] args)
        {
            ConnectToAzure(_azureServiceKey, azureSecret);

            var caches = new ICacheStuff<Employee>[]{
                new SlowCache<Employee>(),
                new SuperFastCache<Employee>() // <-- Need to make this really FAST!
            };

            var companyCaches = new ICacheStuff<Company>[]
            {
                new SlowCache<Company>(),
                new SuperFastCache<Company>()
            };

            Console.WriteLine("TestCache for Employee Model");
            foreach (var cache in caches)
            {
                TestCache(cache);
            }

            Console.WriteLine("\n");
            Console.WriteLine("TestCache for Company Model");
            foreach (var cache in companyCaches)
            {
                TestCache(cache);
            }

            Console.WriteLine("\n");
            Console.WriteLine("OptimizedTestCache for Company Model");
            foreach (var cache in companyCaches)
            {
                OptimizedTestCache(cache);
            }
        }

        /// <summary>
        /// Connect to azure for storing results
        /// </summary>
        /// <param name="serviceKey">The service key to connect to.</param>
        /// <param name="secret">The secret to use.</param>
        private static void ConnectToAzure(string serviceKey, string secret)
        {
            // Connect to azure
            // ConnectToAzure(serviceKey, secret);
        }

        private static void TestCache<T>(ICacheStuff<T> cache) where T : ICachedObject, new()
        {
            new TestHarness<T>()
                .Setup(cache: cache,
                        count: _cacheSize,
                        testNumber: _testNumber,
                        loopNumber: _testLoopNumber,
                        /// <question>
                        /// What is this code doing?
                        /// Why do you think that the coder used this approach?
                        /// <question>
                        /// <answer>
                        /// 1) The code defines a method TestCache<T> that accepts an ICacheStuff<T> instance 
                        /// as a parameter. This method is generic, with the type parameter T constrained to implement 
                        /// the ICachedObject interface and have a parameterless constructor (new() constraint).
                        /// 
                        /// 2) The coder likely used this approach to provide flexibility in testing different types of caches 
                        /// (ex: caches of Employee objects, caches of Company objects) while allowing customization of the test setup for each type.
                        /// </answer>
                        (System.Guid id, string name, string description) => new T()
                        {
                            Id = id,
                            Name = name,
                            Description = description
                        })
                .Run();
        }

        private static void OptimizedTestCache<T>(ICacheStuff<T> cache) where T : ICachedObject, new()
        {
            new TestHarness<T>()
                .Setup(cache: cache,
                        count: _cacheSize,
                        testNumber: _testNumber,
                        loopNumber: _testLoopNumber,
                        (System.Guid id, string name, string description) => new T()
                        {
                            Id = id,
                            Name = name,
                            Description = description
                        })
                .OptimizedRun();
        }
    }
}
