using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _046_并发集合
{
    class Program
    {
        static void Main(string[] args)
        {
            Using_ConcurrentDictionary.Run();

            Console.WriteLine("ok");
            Console.ReadKey();
        }
    }
}
