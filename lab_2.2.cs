using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("n= ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("m= ");
            int m = int.Parse(Console.ReadLine());
            int[,] mas = new int[n, m];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    mas[i, j] = rnd.Next(0, 100);
                    Console.Write(mas[i, j] + "\t");
                }
                Console.WriteLine();
            }
            int k = 0;
            int p = 0;
            while (true)
            {
                Console.Write("k= ");
                k = int.Parse(Console.ReadLine());
                Console.Write("p= ");
                p = int.Parse(Console.ReadLine());
                Console.WriteLine("");
                if (k == p ^ k - 1 > m ^ p - 1 > m ^ k == 0 ^ p == 0)
                {
                    Console.WriteLine("Дані не підходять, введіть інші p та k");
                }
                else break;
            }

            for (int i = 0; i < n; i++)
            {
                mas[i, k - 1] = mas[i, k - 1] + mas[i, p - 1];
                mas[i, p - 1] = mas[i, k - 1] - mas[i, p - 1];
                mas[i, k - 1] = mas[i, k - 1] - mas[i, p - 1];
            }

            for (int el = 0; el < n; el++)
            {
                for (int elem = 0; elem < m; elem++)
                {
                    Console.Write(mas[el, elem] + "\t");
                }
                Console.WriteLine();

            }
        }
    }
}
