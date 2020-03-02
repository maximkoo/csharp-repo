using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            

            for (int i = 0; i < args.Length; i++) {
                Console.WriteLine(args[i]);
            }

            foreach (string qqq in args)
            {
                Console.WriteLine(qqq);
            }

            Console.ReadLine();
        }
    }
}
