namespace static_en_generics_demo;


public class Temperatuur : IParseable<Temperatuur>
{
    public double Graden { get; }
    public Temperatuur(double graden) => Graden = graden;
    public static Temperatuur Parse(string s) => new Temperatuur(double.Parse(s));
}

public class Afstand : IParseable<Afstand>
{
    public double Meters { get; }
    public Afstand(double meters) => Meters = meters;
    public static Afstand Parse(string s) => new Afstand(double.Parse(s));
}

public interface IParseable<TSelf>
{
    static abstract TSelf Parse(string s);
}


interface IHasName
{
    static virtual string Name => "Onbekend";
}

class Klant : IHasName
{
    public static string Name => "Klant";       // eigen versie
}

class Order : IHasName { }


internal class Program
{
    static void Main(string[] args)
    {
        var logLine = ILogger.Format("Server started");
        Console.WriteLine(logLine);


        // static abstract en static virtual
        Console.WriteLine(Temperatuur.Parse("16").Graden);
        Console.WriteLine(Afstand.Parse("5000").Meters);

        var resultTemperatuur = ParseAlles<Temperatuur>(["10", "20", "30"]);
        var resultAfstand = ParseAlles<Afstand>(["10", "20", "30"]);

        var klantNaam = Naam<Klant>();
        Console.WriteLine(klantNaam);

        var orderNaam = Naam<Order>();
        Console.WriteLine(orderNaam);
    }

    private static string Naam<T>() where T : IHasName
    {
        return T.Name;
    }

    static List<T> ParseAlles<T>(List<string> input) where T : IParseable<T>
    {
        var result = new List<T>();
        foreach (var s in input)
        {
            result.Add(T.Parse(s));   // werkt nu
        }
        return result;
    }
}
