using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortString
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore";
            string[] arrayString = s.Split();
            Array.Sort(arrayString);
            s = String.Join(" ", arrayString);

            Console.WriteLine(s);
            Console.ReadKey();
        }
    }
}
