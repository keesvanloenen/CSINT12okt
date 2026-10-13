namespace DelegatesDemo;

//                     vvvvvvvvvvvv nieuwe type!
//public delegate double MathsFunctie(double arg);
//              ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ zo moet de functie eruit zien

internal class Program
{
        static void Plot(Func<double, double> f, double xStart, double xEnd, double step)
    {
        for (double x = xStart; x < xEnd; x += step)
        {
            double y = f(x);
            Console.WriteLine($"{x:N2}, {y:N2}");
        }
    }

    static void Main(string[] args)
    {
        //MathsFunctie mijnFunctie = new MathsFunctie(Math.Tan);
        //MathsFunctie mijnFunctie = Math.Tan;
        
        Plot( x => x - 1, 0.0, Math.PI / 2, 0.01);
    }
    static double Dubbelaar(double x) => x * 2;
    static double Trippelaar(double x) => x * 3;
}
