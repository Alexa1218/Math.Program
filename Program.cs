using System;
using System.Collections.Generic;

namespace Functions
{
    class Program
    {
        static void Main()
        {
            Console.Write("Введите X_min = ");
            double X_min = double.Parse(Console.ReadLine());
            Console.Write("Введите X_max = ");
            double X_max = double.Parse(Console.ReadLine());
            Console.Write("Введите N = ");
            int N = int.Parse(Console.ReadLine());
            var (X, Y) = FillArrays1(N, X_min, X_max);
            // var (X, Y) = FillArrays2(N, X_min, X_max, out var X, out var Y); 
            PrintAnswer(X, Y);
        }
        static (double[], double[]) FillArrays1(int N, double X_min, double X_max)
        {
            double[] X = new double[N];
            double[] Y = new double[N];
            double dx = (X_max - X_min) / (N + 1);
            for (int i = 0; i < N; i++)
            {
                double x = i * dx + X_min;
                X[i] = x;
                Y[i] = F(x);
            }
            return (X, Y);
        }
        /* static void FillArrays2(int N, double X_min, double X_max, out double[] X, out double[]Y) 
         { 
             X = new double[N]; 
             Y = new double[N]; 
             double dx = (X_max - X_min) / (N + 1); 
             for (int i = 0; i < N; i++) 
             { 
                 double x = i * dx + X_min; 
                 X[i] = x; 
                 Y[i] = F(x); 
             } 
         }*/

        static double F(double x)
        {
            if (x == 0)
            {
                return 1;
            }
            else
            {
                return Math.Sin(x) / x;

            }
        }

        static void PrintAnswer(double[] X, double[] Y)
        {
            for (int i = 0; i < X.Length; i++)
            {
                Console.WriteLine("{0} : X = {1:f2} : Y = {2:f2}", i, X[i], Y[i]);
            }
        }
    }
}