using System;
using System.Threading;

namespace _002_线程同步
{
    /// <summary>
    /// 组织多个线程在即时在某个时刻碰面
    /// </summary>
    public class Using_Barrier
    {
        public static Barrier Barrier = new Barrier(2, e =>
        {
            Console.WriteLine("End of phase {0}", e.CurrentPhaseNumber + 1);
        });

        public static void Run()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("运行任务");
                Barrier.SignalAndWait();                
            }
        }
    }
}