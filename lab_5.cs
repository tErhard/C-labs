using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TCircle circle1 = new TCircle();
            TCircle circle2 = new TCircle(8);
            TCircle circle3 = new TCircle(circle2);

            Console.WriteLine($"Радіус першого круга: {circle1.radius}");

            Console.WriteLine($"Радіус другого круга: {circle2.radius}");

            Console.WriteLine($"Радіус третього круга {circle3.radius}");

            var square1 = circle1.getSquare(circle1.radius);
            Console.WriteLine($"Площа першого круга: { square1}");

            var square2 = circle2.getSquare(circle2.radius);
            Console.WriteLine($"Площа другого круга: { square2}");

            var sector1 = circle1.getSectorArea(circle1.radius);
            Console.WriteLine($"Площа сектора першого круга: {sector1}");

            var sector2 = circle2.getSectorArea(circle2.radius);
            Console.WriteLine($"Площа сектора другого круга: {sector2}");

            var length1 = circle1.getLength(circle1.radius);
            Console.WriteLine($"Довжина першого кола: {length1}");

            var length2 = circle2.getLength(circle2.radius);
            Console.WriteLine($"Довжина другого кола: {length2}");

            circle1.Comparison(circle1.radius, circle2.radius);

            var suma = circle1 + circle2;
            Console.WriteLine($"Сума радіусів: { suma}");
            var riz = circle1 - circle2;
            Console.WriteLine($"Різниця радіусів: { riz}");
            var dob = circle1 * circle2;
            Console.WriteLine($"Добуток: { dob}");
            Console.WriteLine();

            TCone cone1 = new TCone();
            TCone cone2 = new TCone(10, 4);


            Console.WriteLine($"Радіус першого конуса: {cone1.radius}");

            Console.WriteLine($"Висота першого конуса: {cone1.hight}");

            Console.WriteLine($"Радіус другого конуса: {cone2.radius}");

            Console.WriteLine($"Висота другого конуса: {cone2.hight}");

            var volume = cone1.getVolume(cone1.radius, cone1.hight);
            Console.WriteLine($"Об'єм першого конуса: {volume}");

            var square3 = cone1.getSquare(cone1.radius);
            Console.WriteLine($"Площа конуса: {square3}");

            var length3 = cone1.getLength(cone1.radius);
            Console.WriteLine($"Довжина кола основи конуса: {length3}");

            cone1.Comparison(cone1.radius, cone2.radius);

            Console.WriteLine($"Сума радіусів конусів: {cone1 + cone2}");
            Console.WriteLine($"Різниця радіусів конусів: {cone1 - cone2}");
            Console.WriteLine($"Добуток: {cone1 * cone2}");

        }
    }
    internal class TCircle
    {
        public double radius;
        public TCircle()
        {
            Console.Write("Введіть радіус: ");
            radius = Convert.ToDouble(Console.ReadLine());
        }
        public TCircle(double radius)
        {
            this.radius = radius; ;
        }

        public TCircle(TCircle r)
        {
            radius = r.radius;
        }
        public virtual double getSquare(double a)
        {
            return Math.PI * Math.Pow(a, 2);
        }

        public virtual double getSectorArea(double a)
        {
            return (Math.PI * Math.Pow(a, 2)) / 360;
        }

        public virtual double getLength(double a)
        {
            return 2 * Math.PI * a;
        }

        public virtual void Comparison(double a, double b)
        {
            if (a > b)
            {
                Console.WriteLine("Перше коло більше");
            }
            else
            {
                Console.WriteLine("Друге коло більше");
            }
        }

        public static double operator +(TCircle circle1, TCircle circle2)
        {
            return circle1.radius + circle2.radius;
        }
        public static double operator -(TCircle circle1, TCircle circle2)
        {
            return circle1.radius - circle2.radius;
        }
        public static double operator *(TCircle circle1, TCircle circle2)
        {
            return circle1.radius * 8;
        }
    }

    internal class TCone : TCircle
    {
        public double hight;
        public TCone()
        {
            Console.Write("Введіть висоту конуса: ");
            hight = Convert.ToDouble(Console.ReadLine());
        }

        public TCone(double radius, double hight)
            : base(radius)
        {
            this.hight = hight;
        }

        public double getVolume(double a, double b)
        {
            return (1 / 3) * Math.PI * Math.Pow(a, 2) * b;
        }

        public override double getSquare(double a)
        {
            var l = Math.Sqrt(Math.Pow(hight, 2) + Math.Pow(a, 2));
            return Math.PI * a * (a + l);
        }

        public override void Comparison(double a, double b)
        {
            if (a > b)
                Console.WriteLine("Радіус першого конуса більше");
            else
                Console.WriteLine("Радіус другого конуса більше");
        }
    }
}
