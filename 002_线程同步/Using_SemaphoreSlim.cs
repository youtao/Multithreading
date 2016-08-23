using System;
using System.Threading;

namespace _002_线程同步
{
    /// <summary>
    /// 限制线程并发数
    /// </summary>
    public class Using_SemaphoreSlim
    {
        private readonly SemaphoreSlim slim = new SemaphoreSlim(3);


        public void Run()
        {
            for (int i = 1; i <= 10; i++)
            {
                var i1 = i;
                ThreadPool.QueueUserWorkItem(e =>
                {
                    slim.Wait(); // 等待
                    Console.WriteLine("{0}线程正在使用资源", i1);
                    Thread.Sleep(2000 + 2000 * i1);
                    slim.Release(); //完成
                });
            }
        }

    }
}