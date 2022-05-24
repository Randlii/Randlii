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
