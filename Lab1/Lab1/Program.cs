using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person("aaa", "sss", 20, Genders.Female);
            Person p2 = "qwerty";

            Console.WriteLine("Hello world!!!");
            Console.WriteLine(p.ToString());
            Console.ReadKey();
        }
    }
}
