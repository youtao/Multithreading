using System;
using System.Threading;

namespace _002_线程同步
{
    /// <summary>
    /// 从一个线程向另一个线程发送通知
    /// </summary>
    public class Using_AutoResetEvent
    {
        public static AutoResetEvent _workerEvent = new AutoResetEvent(false);
        public static AutoResetEvent _mainEvent = new AutoResetEvent(false);

        public void Run()
        {
            _workerEvent.Set();
            Console.WriteLine("准备就绪");
            _mainEvent.WaitOne();
            Console.WriteLine("接受事件");
            _workerEvent.Set();
            Console.WriteLine("准备就绪");
        }
    }
}