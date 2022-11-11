
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1._1
{
    internal class Program
    {
        static int Main(string[] args)
        {
            Console.WriteLine("number=");
            var number = int.Parse(Console.ReadLine());
            int[] numbers = new int[4];
            var sum = 0;
            var k = 0;
            while (number == 5)
            {
                k = number % 10;
                sum += k;
                number = number / 10;
            }
            return sum;

            Console.WriteLine("Цифра 5 є у цьому числі разів :  " + (sum));

        }
    }
}
