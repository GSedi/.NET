using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class StructPerson
    {
        private string _firstName, _lastName;
        private int _age;
        private enum Gender { Male, Female }

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

        public StructPerson(string firstName, string lastName, int age)
        {
            _firstName = firstName;
            _lastName = lastName;
            _age = age;
        }

        public override string ToString()
        {
            return base.ToString() + "\n Firstname: " + _firstName + "\n Lastname: " + _lastName + "\n Age: " + _age;
        }
    }
}
