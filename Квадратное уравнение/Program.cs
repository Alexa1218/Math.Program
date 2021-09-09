using System;

namespace Квадратное_уравнение
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Квадратное уравнение a*x^2+b*x+c=0");
            Console.Write("Введите а = ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("Введите b = ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("Введите c = ");
            double c = double.Parse(Console.ReadLine());
            PrintRoots(a, b, c);
        }
        static double GetDiscr(double a, double b, double c)
        {
            return b * b - 4 * a * c;
        }
        static (double, double) GetRoots(double a, double b, double D)
        {
            double x1 = (-b + Math.Sqrt(D)) / (2 * a);
            double x2 = (-b - Math.Sqrt(D)) / (2 * a);
            return (x1, x2);
        }
        static void PrintRoots(double a, double b, double c)
        {
            double D = GetDiscr(a, b, c);
            var (x1, x2) = GetRoots(a, b, D);
            if (D<0)
            {
                Console.WriteLine("Нет корней.");
            }
            else
            {
                if (D == 0)
                {
                    Console.WriteLine($"Единственный корень x = {x1}");
                }
                else
                {
                    Console.WriteLine($"x1 = {x1}");
                    Console.WriteLine($"x2 = {x2}");
                }
            }
        }
    }
}
