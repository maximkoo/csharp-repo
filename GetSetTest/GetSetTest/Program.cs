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
        //Самый традиционный способ создать методы доступа к private-переменной
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
        // C# позволяет создать так называемые "свойства", то есть как бы прокси-переменные. Такое свойство позволяет и читать и записывать значение
        // То есть, если это было бы Руби, то как будто под одним именем Х собраны методы #x и #x=
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
        // Еще более сокращенная запись, удобно, если в этих методах всё равно ничего умного не написано
        public String X
        {
            get => x;
            set => x = value;
        }
    }
    
    public class GetSetTest3 {
        // сверхкороткий вариант
        public String X { get; set; }
        // В этом случае истинное свойство (т.е. переменная, в которой хранится значение) скрыто и генерируется автоматически.
        // Обращение извне происходит через Х, т.е. вот так
        // GetSetTest3 gst3 = new GetSetTest3();
        // gst3.X = "100";
        // String a = gst3.X;
    }

    // Безотносительно вышенаписанного
    // Способы инициализации переменных при создании объекта
    public class BlockSet {
        public int x;
        public int y;
    }

    public class BlockSetCall {
        public void bsCall1()
        {
            BlockSet bs1 = new BlockSet();
            bs1.x = 100;
            bs1.y = 200;
        }

        public void bsCall2()
        { //Также возможен способ, напоминающий передачу блока в метод new в Руби
            BlockSet bs2 = new BlockSet
            {
                x = 100, // <-- запятая!
                y = 200
            };
        }
    }

}
