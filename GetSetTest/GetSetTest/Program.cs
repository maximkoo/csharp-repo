using System;

namespace GetSetTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing setter and getter methods");
        }
    }

    public class GetSetTest0
    {
        private String x;
        public String getX(){ 
            return x;
        }

        public void setX(String value) {
            x = value;
        }
    }
    public class GetSetTest1 {
        private String x;

        public String X {
            get{ 
                return x;
            }

        set{
                x = value;
            }
        }
    }

    public class GetSetTest2 {
        private String x;
        public String X
        {
            get => x;
            set => x = value;
        }
    }
    
    public class GetSetTest3 {
        public String X { get; set; }            
    }
}
