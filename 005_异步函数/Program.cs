using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _005_异步函数
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task = AsyncSequential(); // 异步顺序执行
            task.Wait(); // 异步等待

            task = AsyncParallel(); // 异步并行执行
            task.Wait(); //             
            Console.WriteLine("主线程执行完成");
            Console.ReadKey();
        }

        /// <summary>
        /// 异步顺序执行
        /// </summary>        
        /// <returns></returns>
        static async Task AsyncSequential()
        {
            Func<string, Task<string>> lambda = async (name) =>
            {
                await Task.Delay(TimeSpan.FromSeconds(2));
                var str = string.Format("name:{0},id:{1}", name, Thread.CurrentThread.ManagedThreadId);
                return str;
            };
            string result = await lambda("async lambda 1");
            Console.WriteLine(result);
            result = await lambda("async lambda 2");
            Console.WriteLine(result);
        }

        /// <summary>
        /// 异步并行执行
        /// </summary>
        /// <returns></returns>
        static async Task AsyncParallel()
        {
            Func<string, Task<string>> lambda = async (name) =>
            {
                await Task.Delay(TimeSpan.FromSeconds(2));
                var str = string.Format("name:{0},id:{1}", name, Thread.CurrentThread.ManagedThreadId);
                return str;
            };
            var task1 = lambda("async lambda 3");
            var task2 = lambda("async lambda 4");

            var results = await Task.WhenAll(task1, task2);
            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }
    }
}
