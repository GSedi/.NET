using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_5_
{
    class Program
    {
        static void Main(string[] args)
        {
            Int16 int16 = 32767;
            Int32 int32 = 32768;
            double _double = 3.14;

            //int16 = int32;
            int32 = int16;
            _double = int32;
            //int32 = _double;
        }
    }
}
