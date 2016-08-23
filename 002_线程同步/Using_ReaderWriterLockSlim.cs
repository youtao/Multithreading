using System;
using System.Collections.Generic;
using System.Threading;

namespace _002_线程同步
{
    /// <summary>
    /// 多线程读写
    /// </summary>
    public class Using_ReaderWriterLockSlim
    {
        public static ReaderWriterLockSlim Slim = new ReaderWriterLockSlim();

        public static Dictionary<int, int> Dic = new Dictionary<int, int>();

        public void Read()
        {
            Console.WriteLine("Reading contents of a dictionary");

            while (true)
            {
                try
                {
                    Slim.EnterReadLock();
                    foreach (KeyValuePair<int, int> item in Dic)
                    {
                        Thread.Sleep(100);
                    }
                }
                finally
                {
                    Slim.ExitReadLock();
                }
            }
        }

        public void Write(string threadName)
        {
            while (true)
            {
                try
                {
                    int key = new Random().Next(250);
                    Slim.EnterUpgradeableReadLock();
                    if (!Dic.ContainsKey(key))
                    {
                        try
                        {
                            Slim.EnterWriteLock();
                            Dic[key] = 1;
                            Console.WriteLine("New key {0} is added to a dictionary by a {1}", key, threadName);
                        }
                        finally
                        {
                            Slim.ExitWriteLock();
                        }
                    }
                    Thread.Sleep(100);
                }
                finally
                {
                    Slim.ExitUpgradeableReadLock();
                }
            }
        }

    }
}