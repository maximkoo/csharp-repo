using System;
using System.Collections.Generic;
using System.Text;

namespace EventApp2
{
    class CD1
    {
        public delegate void D1();
        public D1 q1;
        public D1 q2;
        public D1 q3;
        public D1 q4;
        public D1 q5;

        // public delegate void D2() = delegate {Console.WriteLine("D2")};
        public CD1()
        {
            q1 = delegate { };
            q2 = delegate { Console.WriteLine("q2"); };
            q3 = delegate {     
                            Console.WriteLine("Multiline");
                            Console.WriteLine("Output");
                          };
            q4 = delegate { M1(); };

            q5 = () => Console.WriteLine("q5 works too");
            
            //

            q5+= delegate { Console.WriteLine("Adding more to q5"); };
            q5 += q4;
        }

        public void M1() {
            Console.WriteLine("m1");
        }

        public void InvokeQ5()
        {
            q5();
        }

        public void InvokeAllQ5() {
            int a = q5.GetInvocationList().Length;
            Console.WriteLine($">>>> Length of q5 is {a}");
            for (int i = 0; i < a; i++) {
                q5.GetInvocationList()[i].DynamicInvoke();
                Console.WriteLine($"Type of this item is {q5.GetInvocationList()[i].GetType().ToString()}"); //Type of this item is EventApp2.CD1+D1 
            }
            Console.WriteLine($"Type of q5 is {q5.GetType().ToString()}"); //Type of q5 is EventApp2.CD1+D1 То есть q5 - это делегат типа D1 из класса CD1 в решении EventApp2
        }
    }
}
