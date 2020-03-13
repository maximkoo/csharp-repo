using System;

namespace EventApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            C1 c1 = new C1();
            C2 c2 = new C2();
            c1.e1 += c2.m1;
            c1.e1 += c2.m2;

            c1.Click();

            c1.e1 -= c2.m2;

            c1.Click();
        }
    }

    public class C1 {
        public delegate void D1();
        public event D1 e1;
        public void Click() {
            e1();
        }
    }

    public class C2 {
        public void m1() {
            Console.WriteLine("This is m1");
        }

        public void m2()
        {
            Console.WriteLine("This is m2");
        }       
    }
}
