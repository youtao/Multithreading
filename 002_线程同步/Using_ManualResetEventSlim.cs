using System;
using System.Threading;

namespace _002_线程同步
{
    /// <summary>
    /// 向多个线程发送信号
    /// </summary>
    public class Using_ManualResetEventSlim
    {
        public static ManualResetEventSlim slim = new ManualResetEventSlim(false);

        private void Run()
        {
            Console.WriteLine("程序运行");
            slim.Wait();
            Console.WriteLine("收到通知");
            slim.Set(); //开启大门
            slim.Reset(); // 关上大门
        }
    }
}