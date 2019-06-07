using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace HW290519_2
{
    class Program
    {
        public static int [] numbers = new int[1000000]; 
        public static int [] numbers2 = new int[1000000]; 

        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            List<Thread> threads = new List<Thread>();
            for (int i = 0; i < 10000; i++)
            {                
                threads.Add(new Thread(new ParameterizedThreadStart(Set100ItemsInArray)));
                
            }
            for (int i = 0; i < threads.Count; i++)
            {
                threads[i].Start(i * 100);
                threads[i].Join();
            }
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i]);
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            Console.WriteLine(ts);
            Stopwatch stopWatch2 = new Stopwatch();
            Thread.Sleep(1000);
            stopWatch2.Start();
            for (int i = 0; i < 100000; i++)
            {
                numbers2[i] = 1;
                Console.WriteLine(numbers2[i]);
            }
            stopWatch2.Stop();
            ts = stopWatch2.Elapsed;
            Console.WriteLine(ts);
        }
        public static void Set100ItemsInArray(Object o)
        {
            int index = (int)o;
            
            for (int i = index; i < index + 100; i++)
            {
                numbers[i] = 1;
            }           
        }


    }
}
