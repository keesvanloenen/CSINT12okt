using System.Numerics;

namespace OperatorOverloadingOnGenerics;

public record User(string Naam, int Leeftijd);

public static class MathHelpers
{
    //       👇 static                            👇 nieuwe interface
    public static T Sum<T>(T a, T b) where T : INumber<T>
    {
        return a + b;
    }


    // ---------------------------------------------------------------

    //       👇 static                                                       👇 nieuwe interface
    public static TResult Add<T, TResult>(T left, T right) where T : IAdditionOperators<T, T, TResult>
    {
        return left + right;
    }
}


internal class Program
{
    static void Main(string[] args)
    {
        int res1 = MathHelpers.Sum(10, 20);             
        double res2 = MathHelpers.Sum(1.5, 2.5);        
        decimal res3 = MathHelpers.Sum(100m, 50m);      

        Console.WriteLine(res1);                        // 30
        Console.WriteLine(res2);                        // 4
        Console.WriteLine(res3);                        // 150

        // -----------------------------------------------------------

        decimal result = MathHelpers.Add<decimal, decimal>(10.50m, 11.45m);

        Console.WriteLine(result);                      // 21.95

        var user1 = new User("Mo", 28);
        var user2 = new User("Bo", 20);

        int result2 = MathHelpers.Add<User, int>(user1, user2);
    }

}
