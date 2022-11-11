using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3
{
    internal class Program
    {
            class TLine2D
        {
            public int a;
            public int b;
            public int c;
            public TLine2D()
            {
                a = 0;
                b = 0;
                c = 0;
            }
            public TLine2D(int a, int b, int c)
            {
                this.a = a;
                this.b = b;
                this.c = c;
            }
            public static string ShowLine(TLine2D line)
            {
                var str = $"Koef a={line.a} and b={line.b} and c= {line.c}";
                return str;
            }

            public static string FindInterSection(TLine2D first, TLine2D second)
            {
                var determinant = first.b * second.a - first.a * second.b;
                var b1 = -first.c;
                var b2 = -second.c;

                var x = (first.b * b2 - second.b * b1) / determinant;
                var y = (second.a * b1 - first.a * b2) / determinant;
                return $"Точка перетину ({x},{y})";

            }
            public static bool IsOnLine(TLine2D line, int x, int y)
            {
                var flag = line.a * x + line.b * y + line.c;
                if (flag == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public static TLine2D operator +(TLine2D line1, TLine2D line2)
            {
                return new TLine2D { a = line1.a + line2.a, b = line1.b + line2.b, c = line1.c + line2.c };
            }
            public static TLine2D operator -(TLine2D line1, TLine2D line2)
            {
                return new TLine2D { a = line1.a - line2.a, b = line1.b - line2.b, c = line1.c - line2.c };
            }
        }


    }
}
