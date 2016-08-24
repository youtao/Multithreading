using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _004_任务并行库
{
    class Program
    {
        static void Main(string[] args)
        {
            //try
            //{
            //    Task<int> task = Task.Run(() => TaskMethod());

            //    var result = task.Result;
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.InnerException.Message);
            //}
            //Thread.Sleep(3000);

            var t1 = new Task<int>(TaskMethod);
            var t2 = new Task<int>(TaskMethod);
            var complexTask = Task.WhenAll(t1, t2);
            complexTask.ContinueWith(e =>
            {                
                Console.WriteLine("两个任务完成");
            }, TaskContinuationOptions.OnlyOnFaulted); // 有异常时才执行
            t1.Start();
            t2.Start();            

            Console.WriteLine("主线程运行完成");
            Console.ReadKey();
        }

        static int TaskMethod()
        {
            Console.WriteLine("线程Id{0},是否在线程池中:{1}",
                Thread.CurrentThread.ManagedThreadId,
                Thread.CurrentThread.IsThreadPoolThread);
            Thread.Sleep(2000);
            //throw new Exception("自己发生的异常");
            return 10;
        }
    }
}
