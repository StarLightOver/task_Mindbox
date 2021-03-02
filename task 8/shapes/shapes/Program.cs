using System;
using Figure;

namespace shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!\n");

            try
            {
                IFigure c = new Triangle(new double[] { 10, 12, 17 });

                Foo(c);
            }
            catch (Exception ex) {
                Console.Write(ex.Message);
            }
            

            Console.ReadKey();
        }

        static void Foo(IFigure figure)
        {
            Console.WriteLine("Площадь = " + figure.GetSquare().ToString());
        }
    }
}
