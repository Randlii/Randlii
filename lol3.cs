using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Матрицы
{
    class Matrix
    {
        double[,] a;

        //конструкторы
        public Matrix(int rows, int cols)
        {
            a = new double[rows, cols];
        }

        //метод заполнения матрицы случайными величинами
        public void InputMatrixRandom()
        {
            Random r = new Random();
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    a[i, j] = (double)r.Next(100);
        }

        public void InputMatrix()
        {
            string s = null;
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    s = Console.ReadLine();
                    a[i, j] = Double.Parse(s);
                }
        }

        //1
        //метода преобразования матрицы в строку
        /*
        public override string ToString()
        {
            string s = null;
            for (int i = 0; i < a.GetLength(0); i++, s+="\n")
                for (int j = 0; j < a.GetLength(1); j++)
                    s+= a[i, j] + " ";
            return s;
        }

        //метод отображения матрицы
        public void OutputMatrix ()
        {
            string s = this.ToString();
            Console.WriteLine(s);
        }
        */
//2
        //строковое представление матрицы
        static public implicit operator string(Matrix m)
        {
            string s = null;
            for (int i = 0; i < m.a.GetLength(0); i++, s += "\n")
                for (int j = 0; j < m.a.GetLength(1); j++)
                    s += m.a[i, j] + " ";
            return s;
        }

        //Метод транспонирования матрицы
        static public Matrix operator ~(Matrix m)
        {
            Matrix newm = new Matrix(m.a.GetLength(1), m.a.GetLength(0));
            for (int i = 0; i < m.a.GetLength(0); i++)
            {
                for (int j = 0; j < m.a.GetLength(1); j++)
                    newm.a[j, i] = m.a[i, j];
            }
            return newm;
        }

        //Метод перемножения матриц
        static public Matrix operator *(Matrix m1, Matrix m2)
        {
            if (m1.a.GetLength(1) == m2.a.GetLength(0))
            {
                Matrix newm = new Matrix(m1.a.GetLength(0), m2.a.GetLength(1));
                for (int i = 0; i < m1.a.GetLength(0); i++)
                    for (int j = 0; j < m2.a.GetLength(0); j++)
                        for (int k = 0; k < m1.a.GetLength(1); k++)
                            newm.a[i, j] += m1.a[i, k] * m2.a[k, j];
                return newm;
            }
            else
                throw new Exception("Матрицы таких размерностей не могут быть перемножены!");
        }

        //Умножение матрицы на число

        static public Matrix operator *(Matrix m, double d)
        {
            Matrix newm = new Matrix(m.a.GetLength(0), m.a.GetLength(1));
            for (int i = 0; i < m.a.GetLength(0); i++)
                for (int j = 0; j < m.a.GetLength(0); j++)
                    newm.a[i, j] = m.a[i, j] * d;
            return newm;
        }

        //Умножение числа на матрицу
        static public Matrix operator *(double d, Matrix m)
        {
            Matrix newm = new Matrix(m.a.GetLength(0), m.a.GetLength(1));
            newm = m * d;
            return newm;
        }

        //Операция преобразования целого числа в матрицу
        public static implicit operator Matrix(int n)
        {
            Matrix newm = new Matrix(n, n);
            newm.InputMatrixRandom();
            return newm;
        }

        //Операция преобразования матрицы в вещественное число, т.е. нахождение определителя
        public static explicit operator double(Matrix m)
        {
            string s;
            string[] str;
            double det = 1;
            const double EPS = 1E-9; //определяем переменную EPS
            Matrix opr = new Matrix(m.a.GetLength(0), m.a.GetLength(1));
            
            for (int i = 0; i < m.a.GetLength(0); ++i) //проходим по строкам
            {              
                int k = i; //присваиваем k номер строки
                //идем по строке от i+1 до конца
                for (int j = i + 1; j < m.a.GetLength(0); ++j)
                    if (Math.Abs(m.a[j, i]) > Math.Abs(m.a[k, i])) 
                        k = j; //если равенство выполняется то k присваиваем j
//если равенство выполняется, то определитель приравниваем 0 и выходим из программы
                if (Math.Abs(m.a[k, i]) < EPS)
                {
                    det = 0;
                    break;
                }
                //меняем местами a[i] и a[k]
                //b[0] = m.a[i];
                //m.a[i] = m.a[k];
                //m.a[k] = b[0];
                
                if (i != k)  //если i не равно k, то меняем знак определителя          
                    det = -det;
                
                det *= m.a[i, i]; //умножаем det на элемент a[i, i]             
                for (int j = i + 1; j < m.a.GetLength(0); ++j) //идем по строке от i+1 до конца
                    m.a[i, j] /= m.a[i, i]; //каждый элемент делим на a[i, i]
                for (int j = 0; j < m.a.GetLength(0); ++j) //идем по столбцам
                    if ((j != i) && (Math.Abs(m.a[j, i]) > EPS)) //если да, то идем по k от i+1                       
                        for (k = i + 1; k < m.a.GetLength(0); ++k)
                            m.a[j, k] -= m.a[i, k] * m.a[j, i];
            }
            return det;
        }

        //Сложение матриц
        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            if (m1.a.GetLength(0) != m2.a.GetLength(0) || m1.a.GetLength(1) != m2.a.GetLength(1))
            {
                Console.WriteLine("Сложить можно матрицы только одинаковой размерности!");
return 0;
            }
            Matrix res = new Matrix(m1.a.GetLength(0), m1.a.GetLength(1));
            for (int i = 0; i < m1.a.GetLength(0); i++)
                for (int j = 0; j < m1.a.GetLength(0); j++)
                    res.a[i, j] = m1.a[i, j] + m2.a[i, j];
            return res;
        }

        //Перегрузки cравнения матриц
        public static Matrix operator ==(Matrix m1, Matrix m2)
        {
            if (m1.a.GetLength(0) != m2.a.GetLength(0) || m1.a.GetLength(1) != m2.a.GetLength(1))
            {
                Console.WriteLine("Матрицы не равны.");
                return 0;
            }
            for (int i = 0; i < m1.a.GetLength(0); i++)
                for (int j = 0; j < m1.a.GetLength(1); j++)
                    if (m1.a[i, j] == m2.a[i, j])
                    {
                        Console.WriteLine("Матрицы равны.");
                        return 1;
                    }     
                    else
                    {
                        Console.WriteLine("Матрицы не равны.");
                        return 0;
                    }  
            return 1;
        }
        public static Matrix operator !=(Matrix m1, Matrix m2)
        {
            if (m1.a.GetLength(0) != m2.a.GetLength(0) || m1.a.GetLength(1) != m2.a.GetLength(1))
            {
                Console.WriteLine("Матрицы не равны.");
                return 0;
            }
            for (int i = 0; i < m1.a.GetLength(0); i++)
                for (int j = 0; j < m1.a.GetLength(1); j++)
                    if (m1.a[i, j] != m2.a[i, j])
                    {
                        Console.WriteLine("Матрицы не равны.");
                        return 0;
                    }
            return 1;
        }

    }

    class Program
    {
        static void Main()
        {
            Matrix x, y, z;
            x = new Matrix(2, 3);
            y = new Matrix(3, 4);

            Matrix f, g, h;
            f = new Matrix(2, 2);
            g = new Matrix(2, 2); //g = new Matrix(2, 3);
            f.InputMatrixRandom();
            g.InputMatrixRandom();
            Console.WriteLine(f);
            Console.WriteLine(g);
            h = f + g;
            Console.WriteLine(h);

            Console.WriteLine(f == g);
            Console.WriteLine(f != h);

        }
