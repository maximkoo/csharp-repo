using System;

namespace Delegate1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            /*
D1 d1 = new D1();
d1.run();
*/
            //D2 d2 = new D2();
            //d2.run();

            D3 d3 = new D3();
            // _ = new D3(); // Если экземпляр класса не используется, то можно писать вот так, с анонимным экземпляром
            int a = d3.fun1(1, 2);
            int b = d3.fun1(1, 2);
            int c = d3.fun1(1, 2);
        }
    }

    class D1 {
        // Объявляем delegate.
        delegate int Oper(int x, int y); // Как бы шаблон для методов (произвольного содержания, но обязательно с параметрами (int x, int y) и возвращающий int),         
        private Oper oper1; // каждый из которых будет положен в переменную oper1, oper2 ...
        private Oper oper2; 
        private Oper oper3; 
        private Oper oper4; // надо объявить, как поле класса
        public D1() {
            oper1 = (x, y) => x + y; // иначе это будет переменная метода (
            oper2 = (x, y) => x - y; // Если здесь всего одна команда, то скобки {} ставить нельзя
            oper3 = (x, y) => x * y; // Обратите внимание, у каждой лямбды сигнатура совпадает с шаблоном Oper
            oper4 = (x, y) => x / y; // =0. Чтобы нормально разделить, нужно написать (double)x/y, но у нас шаблон Oper прямо указывает, что ожидается результат int.
            Console.WriteLine("Operations assigned");
        }

        public void run() { // Запускаем методы-объекты по очереди
            Console.WriteLine(oper1(1,2).ToString()); //=> 3
            Console.WriteLine(oper2(1,2).ToString()); //=> -1
            Console.WriteLine(oper3(1,2).ToString()); //=> 2
            Console.WriteLine(oper4(1,2).ToString()); //=> 0
            Console.ReadLine();
        }
    }

    class D2 {
        // Объявляем Action
        Action<int, int>       act1; // То есть это переменные, в которые будет положены анонимные процедуры,
        Action<String, int>    act2; // т.е. методы, возвращающие void
        Action<String, String> act3; // А сигнатуры этих методов должны совпадать с указанными здесь

        public void PrintSumOfTwoNumbers(int a, int b) { // Обычный метод с сигнатурой int, int, как у переменной act1
            Console.WriteLine((a+b).ToString());
        }

        public D2()
        {
            // Можно сделать вот так:
            act1 = PrintSumOfTwoNumbers; // Прямо кладём обычный метод в переменную
            act1(1, 2); //#=> Выводит 3

            // Можно положить в переменную одну строчку, тогда скобки {} ставить нельзя
            act2 = (string s, int x)=>Console.WriteLine(s + x.ToString());
            act2("abc", 123); //#=> Выводит abc123

            // Либо же многострочный код, тогда ставятся скобки {}, а потом обязательно точка с запятой;
            act3 = (string s1, string s2) =>
            {
                Console.WriteLine($"Первая строка {s1}");
                Console.WriteLine($"Вторая строка {s2}");
                Console.WriteLine($"Сумма строк {s1 + s2}");
            };
            act3("abc", "def");//#=> выводит abcdef
            Console.ReadLine();

            // Также надо отметить, что если засовываемый в переменную метод не имеет параметров, то ставятся пустые скобки
            // act = () => Console.WriteLine("Trololo");
        }
    }

    class D3 {
        public Func<int, int, int> fun1; // это переменная, в которую будет положена произвольная функция
        public Func<int, int, int> fun2; // при этом первые два int - это параметры, а последний - всегда возвращаемый тип
        public Func<int, int, int> fun3; // То есть если бы было <int, int, int, string, double, int, string>, то первые шесть - параметры, а возвращается string
        
        public int UsualMethod(int x, int y)
        {
            return x + y;
        }
        public D3() {
            fun1 = UsualMethod; // Кладем в переменную обычный метод с совпадающей сигнатурой - два входных параметра int и один исходящий int
        
            fun2 = (int x, int y) =>(x + y); // кладём в переменную одно выражение

            fun3 = (int a, int b) => // кладём в переменную многострочный код
            {
                int c;
                c = a + b;
                Console.WriteLine($"Сумма параметров {c}");
                return c;
            };
        }
        
    }
}
