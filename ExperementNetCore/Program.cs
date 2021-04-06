using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;

namespace ExperementNetCore
{
    class Program
    {
        static void Main(string[] args)
        {
          
            Person p1 = new Person {Name = "Bill", Age = 34};
            Person p2 = new Person {Name = "Tom", Age = 23};

            Person p3 = new Person {Name = "Alice", Age = 21};
            Person p4 = new Person {Name = "Maximmer", Age = 21};
            Person[] people = new Person[] {p1, p2, p4, p3};


            Person[] peopleLenght = new Person[] { p1, p2, p4, p3 };
            Array.Sort(peopleLenght, new PeopleComparer());

            foreach (Person p in peopleLenght)
            {
                Console.WriteLine($"{p.Name} - {p.Age}");
            }
        }
    }

   

    class Person : IComparable<Person> 
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public int CompareTo(Person o)
        {
            return this.Age.CompareTo(o.Age); 
        }
    }

    class PeopleComparer : IComparer<Person>//В данном случае используется обобщенная версия интерфейса IComparer, чтобы не делать излишних преобразований типов.
    {
        public int Compare(Person p1, Person p2)//Метод Compare предназначен для сравнения двух объектов o1 и o2. Он также возвращает три значения,
            //в зависимости от результата сравнения: если первый объект больше второго, то возвращается число больше 0, если меньше
            //- то число меньше нуля; если оба объекта равны, возвращается ноль.
        {
            if (p1.Name.Length > p2.Name.Length)//он сравнивает объекты в зависимости от длины строки - значения свойства Name 
                return 1;
            else if (p1.Name.Length < p2.Name.Length)
                return -1;
            else
                return 0;
        }
    }
}

