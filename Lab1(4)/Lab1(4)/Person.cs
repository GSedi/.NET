using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_4_
{
    public enum Genders { Male, Female };
    public class Person
    {
        private string _firstName, _lastName;
        private int _age;

        private Genders _gender;



        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public Person() { }
        public Person(string name) {
            _firstName = name;

        }
        public Person(string firstName, string lastName, int age)
        {
            _firstName = firstName;
            _lastName = lastName;
            _age = age;
        }

        public Person(string firstName, string lastName, int age, Genders gender) : this(firstName, lastName, age)
        {
            _gender = gender;
        }

        public override string ToString()
        {
            return "\n Firstname: " + _firstName + "\n Lastname: " + _lastName + "\n Age: " + _age + "\n Gender: " + _gender.ToString();
        }

        public static implicit operator Person(String name) {
            Person p = new Person(name);
            return p;
        }

        public static explicit operator string(Person p) {
            return p._firstName;

        }
        
        /*public static implicit operator ==(Person p1, Person p2) {
            return  p1._firstName == p2._firstName;
        }
        */
    }
}
