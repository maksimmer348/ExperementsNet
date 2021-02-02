using System;

namespace PersonInf
{
    public class Person
    {
        private int _age;
        public int Age
        {
            get { return _age; }
            set
            {
                if (value < 0)
                {
                    _age = 0;
                    return;
                }
                _age = value;
            }
        }
           
        public string Name { get; set; }


        public Person(string name, int age)
        {
            Age = age;
            Name = name;
        }
    }
}
