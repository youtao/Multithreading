using System;
using System.Threading;

namespace _002_线程同步
{
    public class Using_SpinWait
    {
        public static volatile bool IsCompleted = false;

        public void UserModeWait()
        {
            while (!IsCompleted)
            {
                Console.Write(".");
            }
            Console.WriteLine();
            Console.WriteLine("Waiting is complete");
        }

        public void HybridSpinWait()
        {
            SpinWait spinWait = new SpinWait();
            while (!IsCompleted)
            {
                spinWait.SpinOnce();
                Console.WriteLine(spinWait.NextSpinWillYield);
            }
            Console.WriteLine("Waiting is complete");
        }
    }
}