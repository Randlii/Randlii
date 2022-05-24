using System;

namespace triangle
{
    class Triangle
    {
        public double xa;
        public double ya;
        public double xb;
        public double yb;
        public double xc;
        public double yc;

        public Triangle(double xa, double ya, double xb, double yb, double xc, double yc)
        {
            this.xa = xa;
            this.ya = ya;
            this.xb = xb;
            this.yb = yb;
            this.xc = xc;
            this.yc = yc;
            if (!Exmination())
                Console.WriteLine("такого треугольника не существует");
        }

        // существует ли треугольник
        bool Exmination()
        {
            if ((xa != xb && ya != yb)  (xa != xc && ya != yc)  (xb != xc && yb != yc))
                return true;
            return false;
        }
        
        //входит ли точка в треугольник
        bool Inside(double x, double y)
        {
            double a1 = (xa - x) * (yb - ya) - (xb - xa) * (ya - y);
            double b1 = (xb - x) * (yc - yb) - (xc - xb) * (yb - y);
            double c1 = (xc - x) * (ya - yc) - (xa - xc) * (yc - y);

            if ((a1 >= 0 && b1 >= 0 && c1 >= 0) || (a1 <= 0 && b1 <= 0 && c1 <= 0))
                return true;
            return false;
        }
        // находим длину
        double Length(double xa, double ya, double xb, double yb)
        {
            return Math.Sqrt(Math.Pow(xa - xb, 2) + Math.Pow(ya - yb, 2));
        }
        
        // находим площадь 
        public static double Square(Triangle obj)
        {
            double ab = obj.Length(obj.xa, obj.ya, obj.xb, obj.yb);
            double bc = obj.Length(obj.xb, obj.yb, obj.xc, obj.yc);
            double ac = obj.Length(obj.xa, obj.ya, obj.xc, obj.yc);

            double p = (ab + bc + ac) / 2;
            double S = Math.Sqrt(p * (p - ab) * (p - bc) * (p - ac));
            return S;
            }

        // операции сравнения
        public static bool operator ==(Triangle ob1, Triangle ob2)
        {
            if (Square(ob1) == Square(ob2))
                return true;
            return false;
        }
        public static bool operator !=(Triangle ob1, Triangle ob2)
        {
            if (Square(ob1) == Square(ob2))
                return false;
            return true;
        }
        public static bool operator >(Triangle ob1, Triangle ob2)
        {
            if (Square(ob1) <= Square(ob2))
                return false;
            return true;
        }
        public static bool operator <(Triangle ob1, Triangle ob2)
        {
            if (Square(ob1) >= Square(ob2))
                return false;
            return true;
        }
        public static bool operator <=(Triangle ob1, Triangle ob2)
        {
            if (Square(ob1) > Square(ob2))
                return false;
            return true;
        }
        public static bool operator >=(Triangle ob1, Triangle ob2)
        {
            if (Square(ob1) < Square(ob2))
                return false;
            return true;
        }

        //записываем в строку
        public override string ToString ()
        {
            return (xa.ToString()+" "+ya.ToString()+" "+xb.ToString()+" "+yb.ToString()+" "+xc.ToString()+" "+yc.ToString());
        }

        //записываем из строки
        public void FromString(string s)
        {
            string[] coords = s.Split(' ');
            xa = double.Parse(coords[0]);
            ya = double.Parse(coords[1]);
            xb = double.Parse(coords[2]);
            yb = double.Parse(coords[3]);
            xc = double.Parse(coords[4]);
            yc = double.Parse(coords[5]);
        }

        // деструктор 
        ~Triangle()
        {
            Console.WriteLine("destructor");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Triangle t1 = new Triangle(0, 0, 3, 0, 0, 4);
            Triangle t2 = new Triangle(0, 0, 4, 0, 0, 3);
            string mas = t1.ToString();
            Console.WriteLine(mas);
            string s = new string ("0, 0, 4, 0, 0, 3");
            Console.WriteLine();
        }
    }
}
