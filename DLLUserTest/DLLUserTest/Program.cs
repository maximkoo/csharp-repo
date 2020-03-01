using System;
using GetSetTest;

namespace DLLUserTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            DLLUserTest u = new DLLUserTest();
        }  
    }

    class DLLUserTest {
        public DLLUserTest(){
            Console.WriteLine("Created new class");
            Console.WriteLine("Calling DLL");
            
            GetSetTest0 gst0 = new GetSetTest0();
            gst0.setX("abc");
            Console.WriteLine(gst0.getX());

            GetSetTest1 gst1 = new GetSetTest1();
            gst1.X = "abc";
            Console.WriteLine(gst1.X);

            GetSetTest2 gst2 = new GetSetTest2();
            gst2.X = "abc";
            Console.WriteLine(gst2.X);
            
            GetSetTest3 gst3 = new GetSetTest3();
            gst3.X = "abc";
            Console.WriteLine(gst3.X);

            Console.ReadLine();
        }
    }
}
