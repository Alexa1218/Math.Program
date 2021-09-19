using System;

namespace Integral
{
    class Program
    {
        static void Main()
        {
            const double a = 0;
            const double b = 1;
            const double dx = 0.001;

            /*double S = 0; 
            double x = a; 
            while (x < b) 
            { 
                double y = (F(x) + F(x + dx))/2; 
                double I = y * dx; 
                S += I; 
                x += dx; 
            }*/
            Console.WriteLine(GetIntegral(F, a, b, dx));
        }

        static double F(double x)
        {
            return x * x;
        }
        static double GetIntegral(Func<double, double> f, double a, double b, double dx)
        {

            double x = a;
            double S = 0;
            while (x < b)
            {
                S += (f(x) + f(x += dx)) * dx / 2;

            }
            return S;

        }
    }
}
