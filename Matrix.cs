using System;

namespace Matrix1
{
    class Matrix
    {
        private int _N;
        private int _M;
        private double[,] _Items;

        public Matrix(int N, int M)
        {
            _N = N;
            _M = M;
            _Items = new double[N, M];
        }
        public int N
        {
            get                // вывод матрицы (только для чтения)
            {
                return _N;
            }
            set               // изменение размерпа матрицы вводимое пользователем
            {
                _N = value;
            }


            /* //Упрощение верхней записи 1

              get => _N;   
              set => _N = value;


             //Упрощение верхней записи 2

             public int N => _N     // Только для чтения 


             //Упрощение верхней записи 3

             public int N {get; set}*/
        }
        public int M => _M;     // Только для чтения 

        public double this[int i, int j]  //Объясняем программе, что делать с матрицей при "ЭТИХ" (i ,j) значениях
        {
            get
            {
                return _Items[i, j];
            }
            set
            {
                _Items[i, j] = value;
            }
        }


        // Обычный метод сложения матриц

        public Matrix Sum(Matrix B)
        {
            Matrix C = new Matrix(N, M);
            for (var i = 0; i < N; i++)
                for (var j = 0; j < M; j++)
                    C[i, j] = this[i, j] + B[i, j];
            return C;
        }

        // Статический метод

        public static Matrix Sum(Matrix A, Matrix B)
        {
            Matrix C = new Matrix(A.N, A.M);
            for (var i = 0; i < C.N; i++)
                for (var j = 0; j < C.M; j++)
                    C[i, j] = A[i, j] + B[i, j];
            return C;
        }


        // Определение оператора

        public static Matrix operator +(Matrix A, Matrix B)   //тип опертаора :  Matrix       ; название оператора: + (то есть то, что будет делать)  
        {
            Matrix C = new Matrix(A.N, A.M);
            for (var i = 0; i < C.N; i++)
                for (var j = 0; j < C.M; j++)
                    C[i, j] = A[i, j] + B[i, j];
            return C;
        }

        // Оператор умножения

        public static Matrix operator *(Matrix A, double B) // Обратный порядок, если сделать (double A, Matrix B) => B*A
        {
            var C = new Matrix(A.N, A.M);
            for (var i = 0; i < C.N; i++)
                for (var j = 0; j < C.M; j++)
                    C[i, j] = A[i, j] * B;
            return C;
        }

        // умножение двух матриц

        public static Matrix operator *(Matrix A, Matrix B)
        {
            if (A.M != A.N)
                throw new Exception();   //вывод ошибки
            var C = new Matrix(A.M, B.M);
            for (var i = 0; i < C.N; i++)
                for (var j = 0; j < C.M; j++)
                    for (var k = 0; k < A.M; k++)
                        C[i, j] += A[i, k] * B[k, j];
            return C;
        }

        // Строит матрицу треугольного вида

        private static void SwapRows(double[,] A, int i1, int i2)   //Метод позволяет поменять две строки местами
        {
            if (i1 == i2) return;
            for (var j = 0; j < A.GetLength(1); j++)
            {
                var tmp = A[i1, j];
                A[i1, j] = A[i2, j];
                A[i2, j] = tmp;
            }
        }


        public static (int ranc, double det) Triangle(double[,] A)    //  можно было без названий ( int, double)
        {
            int N = A.GetLength(0);
            int M = A.GetLength(1);
            int rank = Math.Min(N, M);
            double det = 1;
            for (var i0 = 0; i0 < rank; i0++)
            {
                if (A[i0, i0] == 0)
                {
                    var max = 0.0;
                    var max_index = -1;
                    for (var i1 = i0 + 1; i1 < N; i1++)  //Поиск строки
                    {
                        var abs = Math.Abs(A[i1, i0]);
                        if (abs > max)
                        {
                            max = abs;
                            max_index = i1;
                        }
                    }
                    if (max_index < 0) // матрица выродждена
                    {
                        for (var i = i0; i < N; i++)
                            for (var j = i0; j < M; j++)
                                A[i, j] = 0;
                        return (i0, 0);
                    }
                    SwapRows(A, i0, max_index);
                    det = -det;
                }
                var main = A[i0, i0];
                det *= main;
                for (var i = i0 + 1; i < N; i++)
                    if (A[i, i0] != 0)
                    {
                        var k = A[i, i0] / main;
                        A[i, i0] = 0;
                        for (var j = i0 + 1; j < M; j++)
                            A[i, j] -= A[i0, j] * k;
                    }
            }
            return (rank, det);
        }

        public double GetDetermindnt()   //  определитель
        {
            var items = (double[,])_Items.Clone();
            var (rank, det) = Triangle(items);
            return det;
        }
        public int GetRank()    // ранг
        {
            var items = (double[,])_Items.Clone();
            var (rank, det) = Triangle(items);
            return rank;
        }
        public Matrix(double[,] Items)    //определитель треугольной матрицы
        {
            _Items = Items;
            _N = Items.GetLength(0);
            _M = Items.GetLength(1);
        }
        public Matrix GetTriangle()
        {
            var items = (double[,])_Items.Clone();
            Triangle(items);
            return new Matrix(items);
        }
        public void Print()
        {
            for (var i = 0; i < N; i++)
            {
                for (var j = 0; j < M; j++)
                    Console.Write("{0:f3}\t", _Items[i, j]);
                Console.WriteLine();
            }
        }

        static void Main()
        {
            var A = new Matrix(3, 3);
            A[0, 0] = 2;
            A[0, 1] = 2;
            A[0, 2] = 3;
            A[1, 0] = 4;
            A[1, 1] = 5;
            A[1, 2] = 6;
            A[2, 0] = 7;
            A[2, 1] = 8;
            A[2, 2] = 9;
            A.Print();
            var B = A.GetTriangle();
            Console.WriteLine();
            B.Print();
            Console.WriteLine("det = {0}", A.GetDetermindnt());
        }
    }

}
