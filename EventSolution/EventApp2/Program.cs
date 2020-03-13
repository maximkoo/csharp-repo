﻿using System;

// событие в C# - особый объект, содержащий в себе список методов. При запуске события все методы запускаются. Методы могут добавляться и удаляться динамически.
// Объект-событие имеет параметры, описанные с помощью делегата. Все методы, содержащиеся в событии имеют одинаковый список параметров.
// То есть можно представить, что делегат - это описание полей некой воображаемой таблицы, событие - сама таблица, а методы - записи в таблице.

namespace EventApp2
{
    public class C1 { // Это класс, содержащий объект-событие e1
        public delegate void D1(int x, int y); // "шаблон" для всех методов, которые могут соответствовать событию. ("Описание полей таблицы")
        public event D1 e1; // как бы "таблица" для методов, соответствующих указанному строчкой выше шаблону. ("Сама таблица")

        public void Click(int x, int y)
        { // Событие запущено
            e1(x,y); // Запускает всю пачку зарегистрированных здесь методов по очереди ("for i in (select * from e1) loop execute i.method; end loop;")
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            C1 c1 = new C1(); // класс, содержащий событие
            C2 c2 = new C2(); // класс, содержащий некие методы

            c1.e1 += c2.M1; // регистрируем метод в событии. Когда событие сработает, этот метод будет запущен ("Добавляем запись в таблицу")

            c1.Click(1, 2); // Запускаем событие, должен сработать метод M1 из класса C1

            // Добавляем к событию еще один метод ("Добавляем еще одну запись в таблицу")
            c1.e1 += c2.M2; // Странным образом, можно использовать только += и -=, просто = использовать нельзя

            c1.Click(10, 20); // Теперь будут запущены методы M1 и M2.

            // c1.e1(1,2); // Почему-то вот так делать нельзя, только через охватывающий метод
            c1.e1 -= c2.M1; // Удаляем метод из события ("Удаляем запись из таблицы")

            c1.Click(100, 200); // Теперь будет запущен только метод M2.

            CD1 cd1 = new CD1();
            cd1.InvokeQ5();
            cd1.InvokeAllQ5();
        }
    }

    // Просто класс с какими-то методами
    public class C2 { 
        public void M1(int a, int b) {
            Console.WriteLine($"M1: Сумма чисел ={a + b}");            
        }
        public void M2(int a, int b)
        {
            Console.WriteLine($"M2: Произведение чисел ={a * b}");
        }
    }
}
