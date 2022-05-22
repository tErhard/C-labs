using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_1._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("a = ");
            double a = double.Parse(Console.ReadLine());

            Console.Write("b = ");
            double b = double.Parse(Console.ReadLine());

            Console.Write("c = ");
            double c = double.Parse(Console.ReadLine());

            double y = Math.Max(Math.Max(a - b, a - c), Math.Cos(Math.Max(a * b * c, a - b - c)));

            Console.WriteLine(" y = " + y);

        }
    }
}
