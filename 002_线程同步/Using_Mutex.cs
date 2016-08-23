using System;
using System.Threading;

namespace _002_线程同步
{
    /// <summary>
    /// 线程独享资源
    /// </summary>
    public class Using_Mutex
    {
        public void Run()
        {
            const string MutexName = "MutexName";
            using (var mutex = new Mutex(false, MutexName))
            {
                if (!mutex.WaitOne(TimeSpan.FromSeconds(5), false))
                {
                    Console.WriteLine("第二个实例正在运行");
                }
                else
                {
                    Console.WriteLine("运行中");
                    Console.ReadKey();
                    mutex.ReleaseMutex();
                }
            }
        }
    }
}