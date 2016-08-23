using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _001_线程基础
{
    class Program
    {
        static void Main(string[] args)
        {
            Resource resource = new Resource();
            for (int i = 0; i < 10; i++)
            {
                ThreadPool.QueueUserWorkItem(e => // 竞争条件
                {
                    for (int j = 0; j < 1000000; j++)
                    {
                        resource.Count++;
                        resource.Count--;
                    }
                });
            }            

            Thread.Sleep(2000);
            Console.WriteLine(resource.Count);
            Console.ReadKey();
        }
    }

    public class Resource
    {
        public int Count { get; set; }
    }
}
