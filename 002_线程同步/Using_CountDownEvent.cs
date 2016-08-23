using System;
using System.Threading;

namespace _002_线程同步
{
    /// <summary>
    /// 当指定数量的线程数执行完成后再执行某操作
    /// </summary>
    public class Using_CountDownEvent
    {
        public static CountdownEvent Countdown = new CountdownEvent(2);

        public static void Run()
        {
            Console.WriteLine("程序开始");
            Countdown.Signal();
            Countdown.Wait();
            Console.WriteLine("Count减为0啦");
        }
    }
}