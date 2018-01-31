using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_4_
{
    class Manager : Person
    {
        private string phoneNumber, officeLocation;

        public string PhoneNumber {
            get { return phoneNumber; }
            set { phoneNumber = value; }

        }

        public string OfficeLocation {
            get { return officeLocation; }
            set { officeLocation = value; }
        }

        public Manager() : base(){}
        public Manager(string firstName, string lastName, int age, Genders gender, string phoneNumber, string officeLocation) : base(firstName, lastName, age, gender) {
            this.phoneNumber = phoneNumber;
            this.officeLocation = officeLocation;

        }

        public override string ToString()
        {
            return base.ToString() + "\n Phone Number: " + this.phoneNumber + "\n Office location: " + this.officeLocation;
        }
    }
}
