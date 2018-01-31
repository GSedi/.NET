using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_4_
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Manager("aaa", "sss", 20, Genders.Female, "+77777777777", "342");
            Person p2 = "qwerty";
            Console.WriteLine("Hello world!!!");
            Console.WriteLine(p.ToString());
            Console.WriteLine(p2.ToString());
            Console.ReadKey();
        }
    }
}
