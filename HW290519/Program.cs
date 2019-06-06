using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HW290519
{
    class Program
    {
        static void Main(string[] args)
        {
            int result = GetRandom();
            //Thread t = new Thread(() =>
            //{
            //    for (int i = 5; i >= 0; i--)
            //    {
            //        Console.WriteLine(i);
            //        Thread.Sleep(1000);
            //    }
            //    Console.WriteLine("Time Over!");           
            //});
            Thread t = new Thread(count);            
            GiveAnswer(result , t);            
        }

        private static void count()
        {
            for (int i = 5; i >= 0; i--)
            {
                Console.WriteLine(i);
                Thread.Sleep(1000);
            }
            Console.WriteLine("time over!");
        }

        private static void GiveAnswer(int result, Thread t)
        {
            t.Start();
            int answer = Convert.ToInt32(Console.ReadLine());
            if (answer == result && t.ThreadState != ThreadState.Stopped)
            {
                
                Console.WriteLine("You are Great!");
            }
            else
            {
                Console.WriteLine("Try again");
                GiveAnswer(result, new Thread(count));
            }
            t.Abort();

        }
        private static int GetRandom()
        {
            Random r = new Random();
            int a = r.Next(10);
            int b = r.Next(10);
            Console.Write($"{a} * {b}");
            Console.WriteLine();
            Console.WriteLine("What The Answer?");
            int result = a * b;
            return result;
        }
    }
}
