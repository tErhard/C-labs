using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TMatrix matrix = new TMatrix(3, 4);
            matrix.CreateMatrix();
            matrix.PrintMatrix();
            Console.WriteLine(matrix.MatrixMin());
            Console.WriteLine(matrix.MatrixMax());
            Console.WriteLine(matrix.MatrixSum());
        }
        class TMatrix
        {
            private int a;
            public int A
            {
                get { return a; }
                set
                {
                    if (value > 0)
                        a = value;
                    else
                        throw new Exception("Incorect value");
                }
            }
            private int b;
            public int B
            {
                get { return b; }
                set
                {
                    if (value > 0)
                        b = value;
                    else
                        throw new Exception("Incorect value");
                }
            }
            private double[,] matrix;
            public double[,] Matrix
            {
                get { return matrix; }
                set { matrix = value; }
            }
            public TMatrix()
            {
                A = 3;
                B = 3;
                Matrix = new double[3, 3];
                for (int i = 0; i < a; i++)
                {
                    for (int j = 0; j < b; j++)
                    {
                        matrix[i, j] = 0;
                    }
                }
            }
            public TMatrix(int ab)
            {
                A = ab;
                B = ab;
                Matrix = new double[ab, ab];
                for (int i = 0; i < ab; i++)
                {
                    for (int j = 0; j < ab; j++)
                    {
                        matrix[i, j] = 0;
                    }
                }
            }
            public TMatrix(int a, int b)
            {
                A = a;
                B = b;
                Matrix = new double[a, b];
                for (int i = 0; i < a; i++)
                {
                    for (int j = 0; j < b; j++)
                    {
                        matrix[i, j] = 0;
                    }
                }
            }
            public void CreateMatrix()
            {
                for (int i = 0; i < a; i++)
                {
                    for (int j = 0; j < b; j++)
                    {
                        Console.Write($"{i + 1}{j + 1}: ");
                        matrix[i, j] = double.Parse(Console.ReadLine());
                    }
                }
            }
            public void PrintMatrix()
            {
                for (int i = 0; i < a; i++)
                {
                    for (int j = 0; j < b; j++)
                    {
                        Console.Write(matrix[i, j] + "\t");
                    }
                    Console.WriteLine();
                }
                Console.ReadLine();
            }
            public double MatrixMax()
            {
                double max = matrix[0, 0];
                for (int i = 0; i < a; i++)
                {
                    for (int j = 0; j < b; j++)
                    {
                        if (max < matrix[i, j])
                        {
                            max = matrix[i, j];
                        }
                    }
                }
                return max;
            }
            public double MatrixMin()
            {
                double min = matrix[0, 0];
                for (int i = 0; i < a; i++)
                {
                    for (int j = 0; j < b; j++)
                    {
                        if (min > matrix[i, j])
                        {
                            min = matrix[i, j];
                        }
                    }
                }
                return min;
            }
            public double MatrixSum()
            {
                double sum = 0;
                for (int i = 0; i < a; i++)
                {
                    for (int j = 0; j < b; j++)
                    {
                        sum += matrix[i, j];
                    }
                }
                return sum;
            }
        }
    }
}
