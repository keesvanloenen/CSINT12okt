namespace Verzekeringen.App;

internal class Program
{
    static void Main(string[] args)
    {

        // DemoNullableValueTypes();
        // DemoEnum();
        // DemoTuples();
        DemoDeconstruct();

    }

    private static void DemoDeconstruct()
    {
        var polis = new Polis { Code = "ABC123", Klant = new Klant("Mo"), Premie = 123m };
        var (code, klantnaam, premie) = polis;
        Console.WriteLine($"{code}\t{klantnaam}\t{premie}");
    }

    private static void DemoTuples()
    {
        //(string, decimal) premieInfo = ("WA Verzekering", 110.00m);
        //Console.WriteLine($"Premie: {premieInfo.Item2}");

        (string Product, decimal Premie) premieInfo = ("WA Verzekering", 110.00m);
        Console.WriteLine($"Premie: {premieInfo.Premie}");

        (string Product, decimal Premie) premieInfo2 = ("WA Verzekering", 110.00m);
        Console.WriteLine($"Premie: {premieInfo.Premie}");

        Console.WriteLine($"Equal: {premieInfo == premieInfo2}");

        var (_, toegepast)= SchadeBerekening.BerekenUitkering(1500m, 600m);
        Console.WriteLine($"Uitkering: {toegepast}");
    }



    private static void DemoEnum()
    {
        Klant klant1 = new Klant("An de Wit");
        klant1.Voorkeur = ContactVoorkeur.Sms | ContactVoorkeur.Telefoon | ContactVoorkeur.Email;

        Console.WriteLine((ushort)klant1.Voorkeur);

        //if (klant1.Voorkeur == ContactVoorkeur.Sms)
        //if ((klant1.Voorkeur & ContactVoorkeur.Sms) != 0)

        //if ((klant1.Voorkeur & (ContactVoorkeur.Sms | ContactVoorkeur.Email)) != 0)

        if ((klant1.Voorkeur.HasFlag(ContactVoorkeur.Sms) || 
             klant1.Voorkeur.HasFlag(ContactVoorkeur.Email)))
        {
            Console.WriteLine("Klant wil contact via SMS en/of Email");
        }

    }

    private static void DemoNullableValueTypes()
    {
        decimal? premie = null;
        //Console.WriteLine($"Premie: {premie}");

        Console.WriteLine($"Premie: {(premie != null ? premie : "onbekend")}");     // ternary
        Console.WriteLine($"Premie: {(premie?.ToString() ?? "onbekend")}");

        Console.WriteLine(decimal.MinValue);        // decimal is een STRUCT met properties en methods

        string s1 = "Hoi";
        string s2 = "Hoi";

        Console.WriteLine(s1 == s2);    // true, omdat == overloaded is (vergelijk inhoud van de strings)

        // pattern matching: is
        // kun je gebruiken bij type checks of null:

        if (s1 is string) {  /* ... */ }
        if (s1 is null) {  /* ... */ }
        // if (s1 is s2) {  /* ... */ } // dit mag dus niet

        Polis polis = new Polis();
        Console.WriteLine($"Poliscode: {polis.Code ?? "Nog niet toegekend"}");

        polis.Code ??= "POL12345";
        Console.WriteLine($"Polisnummer na toekenning: {polis.Code}");

        polis.Klant = new Klant("Mo Janssen");
        Console.WriteLine($"Klantnaam: {polis.Klant.Naam}");
        Console.WriteLine($"Lengte naam: {polis.Klant.Naam.Length}");
    }
}
