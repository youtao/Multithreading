using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _046_并发集合
{
    public class Using_ConcurrentDictionary
    {
        public static void Run()
        {
            var value = "value";
            Task[] tasks = new Task[5];
            ConcurrentDictionary<int, string> concurrentDictionary = new ConcurrentDictionary<int, string>();


            Stopwatch stopwatch = Stopwatch.StartNew();
            //for (int i = 0; i < 1000000; i++)
            //{
            //    concurrentDictionary[i] = value;
            //}

            for (int i = 0; i < 5; i++)
            {
                var iLocal = i;
                var valueLocal = value;
                Task task = Task.Run(() =>
                {
                    for (int j = 200000 * iLocal; j < 200000 * (iLocal + 1); j++)
                    {
                        concurrentDictionary[j] = valueLocal;
                    }
                });
                tasks[i] = task;
            }
            Task.WhenAll(tasks).Wait();
            stopwatch.Stop();
            Console.WriteLine("ConcurrentDictionary写:{0}毫秒", stopwatch.ElapsedMilliseconds);

            stopwatch.Restart();
            for (int i = 0; i < 1000000; i++)
            {
                value = concurrentDictionary[i];
            }
            stopwatch.Stop();
            Console.WriteLine("ConcurrentDictionary读:{0}毫秒", stopwatch.ElapsedMilliseconds);



            Dictionary<int, string> dictionary = new Dictionary<int, string>();

            stopwatch.Restart();
            //for (int i = 0; i < 1000000; i++)
            //{
            //    lock (dictionary)
            //    {
            //        dictionary[i] = value;
            //    }
            //}


            for (int i = 0; i < 5; i++)
            {
                var iLocal = i;
                var valueLocal = value;
                Task task = Task.Run(() =>
                {
                    for (int j = 200000 * iLocal; j < 200000 * (iLocal + 1); j++)
                    {
                        lock (dictionary)
                        {
                            dictionary[j] = valueLocal;
                        }
                    }
                });
                tasks[i] = task;
            }
            Task.WhenAll(tasks).Wait();

            stopwatch.Stop();
            Console.WriteLine("Dictionary写:{0}毫秒", stopwatch.ElapsedMilliseconds);


            stopwatch.Restart();
            for (int i = 0; i < 1000000; i++)
            {
                lock (dictionary)
                {
                    value = dictionary[i];
                }
            }
            stopwatch.Stop();
            Console.WriteLine("Dictionary读:{0}毫秒", stopwatch.ElapsedMilliseconds);
        }
    }
}
