using System;
using System.IO;
namespace Box
{
    class Point
    {
        public int X;
        public int Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
    class Box
    {
        public int xl;
        public int yl;
        public int h;
        int w;

        public int W
        {
            get
            {
                return w;
            }
            set
            {
                w = value;
            }
        }

        public Box()
        {

        }
        public Box(int x, int y, int height, int width)
        {
            xl = x;
            yl = y;
            h = height;
            w = width;

        }
        public Box Copy()
        {
            Console.WriteLine("Copied box:");
            Box box = new Box();
            box.xl = xl;
            box.yl = yl;
            box.h = h;
            box.W = W;
            return box;
        }

        public virtual void Display()
        {
            Console.WriteLine(xl);
            Console.WriteLine(yl);
            Console.WriteLine(h);
            Console.WriteLine(w);
        }
        public bool Test(Point pt)
        {
            int res = yl - h;
            int res2 = xl + w;
            if (pt.Y <= yl && pt.Y >= res && pt.X >= xl && pt.X <= res2)
            {
                return true;
            }
            return false;


        }
        public static Box operator +(Box b1, Box b2)
        {
            int x11 = b1.xl;
            int x12 = b1.xl + b1.w;
            int y11 = b1.yl;
            int y12 = b1.yl - b1.h;
            int x21 = b2.xl;
            int x22 = b2.xl + b2.w;
            int y21 = b2.yl;
            int y22 = b2.yl - b2.h;

            int x31 = Math.Max(x11, x21);
            int x32 = Math.Min(x12, x22);
            int y31 = Math.Min(y11, y21);
            int y32 = Math.Max(y12, y22);

            return new Box(x31, y31, y31 - y32, x32 - x31);
        }
        public virtual void WriteInFile(string path)
        {
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(xl);
                writer.WriteLine(yl);
                writer.WriteLine(h);
                writer.WriteLine(W);
            }

        }

  
    }
    class TextBox : Box
    {
        public string txt;




        public TextBox()
        {

        }

        public TextBox(string text,int x, int y, int height, int weight) : base(x, y, height, weight)
        {
            txt = text;
        }

        public override void Display()
        {
            Console.WriteLine(txt);
            Console.WriteLine(xl);
            Console.WriteLine(yl);
            Console.WriteLine(h);
            Console.WriteLine(W);
        }

        public override void WriteInFile(string path)
        {
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(txt);
                writer.WriteLine(xl);
                writer.WriteLine(yl);
                writer.WriteLine(h);
                writer.WriteLine(W);
            }

        }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            Point pt = new Point(4, 5);
            Box bx_a = new Box(1, 2, 2, 6);
            Box bx_b = new Box(1, 2, 2, 6);
            TextBox tb_a = new TextBox("BoxOne",6, 9, 2, 0);
            TextBox tb_b = new TextBox("BoxTwo",5, 5, 7, 2);
            Box res = bx_a + bx_b;
            res.Display();
            bool b = bx_b.Test(pt);
            Console.WriteLine(b);
            Box[] arr = { tb_a, tb_b, bx_a, bx_b };
            for (int i = 0; i < arr.Length; i++)
            {
               arr[i].Display();
                arr[i].WriteInFile("Privet.txt");
            }

        }
    }
}
