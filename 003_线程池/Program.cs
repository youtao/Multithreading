using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _003_线程池
{
    class Program
    {        
        static void Main(string[] args)
        {
            using (var cts =new CancellationTokenSource())
            {
                CancellationToken token = cts.Token;
                ThreadPool.QueueUserWorkItem(e =>CancelOperational(token));
                Thread.Sleep(5000);
                cts.Cancel();
            }
            Thread.Sleep(20000);
            
           var bw = new BackgroundWorker();            
        }

        /// <summary>
        /// 取消任务
        /// </summary>
        /// <param name="token"></param>
        static void CancelOperational(CancellationToken token)
        {
            bool cancellationFlag = false;
            token.Register(() => cancellationFlag = true);
            for (int i = 0; i < 10; i++)
            {
                if (cancellationFlag)
                {
                    Console.WriteLine("已经被取消");
                    return;
                }
                Console.Write(".");
                Thread.Sleep(1000);
            }
            Console.WriteLine("任务完成");
        }
    }
}
