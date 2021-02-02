using System;
using System.ComponentModel;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;
using PersonInf;

namespace ExperementNetCore
{
    delegate void AccountHandler(AccounArgs message);

    class AccounArgs
    {
        public string Name;
        public AccounArgs(string name)
        {
            Name = name;
        }
    }

    class CompanyArg: AccounArgs
    {
        public string Company;
        public CompanyArg(string name, string company)
            : base(name)
        {
            Company = company;
        }
    }

    class Person
    {

        public Person(string name, AccountHandler k)
        {
            _notify += k;
            Name = name;
        }


        public event AccountHandler _notify;
        private string name;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value != name)
                {
                    name = value;
                    DisplayTo();
                }
                
            }
        }

        public virtual void DisplayTo()
        {
            _notify?.Invoke(new AccounArgs(name));
        }

    }
    class Employee : Person
    {
        public string Company { get; set; }

        public Employee(string name, string company, AccountHandler k)
            : base(name, k)
        {
            Company = company;
        }

        public override void DisplayTo()
        {
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person("Max", Display);
            
            p = new Employee("Mixa","KEK", Display);
            
            Employee e = new Employee("Lexa","LLOOOL", Display);
            
            Console.Read();
        }

        static void Display(string name)
        {
            Console.WriteLine(name);
        }
        static void Display(string name, string company)
        {
            Console.WriteLine($"{name} {company}");
        }
    }
}

