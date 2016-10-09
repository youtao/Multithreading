using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _046_并发集合
{
    public class Using_ConcurrentQueue
    {
        public static void Run()
        {
            ConcurrentQueue<CustomTask> queue = new ConcurrentQueue<CustomTask>();
            CancellationTokenSource cts = new CancellationTokenSource();
            Task[] processors = new Task[4];
            for (int i = 0; i < processors.Length; i++)
            {
                string processorId = i.ToString();
                processors[i] = Task.Run(() =>
                {

                });
            }
        }
    }

    public class CustomTask
    {
        public int Id { get; set; }
    }
}
