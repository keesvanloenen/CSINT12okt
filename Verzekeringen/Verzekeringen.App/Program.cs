using System.Text;

namespace Verzekeringen.App;

internal class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        // DemoNullableValueTypes();
        // DemoEnum();
        // DemoTuples();
        //DemoDeconstruct();
        //DemoRecord();
        DemoSchadeCollection();
        //DemoCollectionInitializer();
        //BitArray_Introductie();

    }

    private static void BitArray_Introductie()
    {
        bool[] flagsA = new bool[8];

        flagsA[0] = true;
        flagsA[3] = true;
        flagsA[6] = true;

        // Dit wordt:
        // 01001001

        // Dit kan in één byte:
        byte flagsB = 0b01001001;

        // ------------------------------------------------------

        /*
        Bitwise OR |
        Gebruik je om bits aan te zetten:

        01000000
        00001000
        --------
        01001000   OR
        */

        
        byte a = 0b01000000;
        byte b = 0b00001000;

        byte result = (byte)(a | b);

        // ------------------------------------------------------

        /*
        Bit shift <<
        1 << n maakt een getal waarbij bit n aanstaat
        */

        byte flagsC = 0;
        flagsC |= 1 << 2;
        flagsC |= 1 << 5;

        // ------------------------------------------------------

        /* 
        Bitwise AND &
        Gebruik je om bits te controleren
        
        1 & 1 = 1
        1 & 0 = 0
        0 & 1 = 0
        0 & 0 = 0
        */

        byte flagsD = 0b01001000;
        bool isBit3Set = (flagsD & (1 << 3)) != 0;

        /*
        flags       01001000
        mask        00001000
                    --------
        AND         00001000
        */

        // ------------------------------------------------------

        /*
        Bitwise & samen met ~
        Gebruik je om bits uit te zetten:
        */

        // voorbeeld:
        //flagsD &= ~(1 << 3);

        // 1 << 3 = 00001000

        // Negeren/inverteren:
        // 11110111

        /*
        flags       01001000
        mask        11110111
                    --------
        AND         01000000    Bit 3 is nu weg
        */




    }

    private static void DemoCollectionInitializer()
    {
        List<char> characters = new List<char>() { 'b', 'c', 'd' };
        // collection initializer                ^^^^^^^^^^^^^^^^^

        List<char> characters2 = new () { 'b', 'c', 'd' };
        List<char> characters3 = [ 'b', 'c', 'd' ];
        // collection expr.      ^^^^^^^^^^^^^^^^^

        characters.AddRange(['e', 'f']);

        characters = ['a', .. characters, 'g', 'h'];            // Joepie, spreaden

        foreach (var character in characters) 
        {
            Console.Write(character);
        }

    }

    private static void DemoSchadeCollection()
    {
        //var schadeCollection = new SchadeCollection();


        //schadeCollection.Add(schade1);
        //schadeCollection.Add(schade2);
        //schadeCollection.Add(schade3);
        //schadeCollection.Add(schade4);
        //schadeCollection.Add(schade5);

        var schade1 = new Schade("a", 1m, DateTime.Now);
        var schade2 = new Schade("b", 2m, DateTime.Now);
        var schade3 = new Schade("c", 3m, DateTime.Now);
        var schade4 = new Schade("d", 4m, DateTime.Now);
        var schade5 = new Schade("e", 5m, DateTime.Now);

        SchadeCollection schadeCollection = 
        [
            schade1, schade2, schade3, schade4, schade5
        ];

        Console.WriteLine(schadeCollection.Count);
        Console.WriteLine(schadeCollection[1]);

        schadeCollection[4] = new Schade("Z", 9m, DateTime.Now);
        Console.WriteLine(schadeCollection[0]);

        Schade? schadeB = schadeCollection["B"];
        var bedragBijSchadeB = schadeB?.Bedrag.ToString() ?? "n/b";
        Console.WriteLine($"Bedrag bij schade B: {schadeB?.Bedrag:C}");

        for (var i = 0; i < schadeCollection.Count; i++)
        {
            Console.WriteLine(schadeCollection[i]);
        }

        // dankzij yield return
        foreach (var schade in schadeCollection)
        {
            Console.WriteLine(schade);
        }
    }

    private static void DemoRecord()
    {
        // ToString()
        var schade1 = new Schade("Hagelschade", 9967m, DateTime.Now);
        Console.WriteLine(schade1);

        // Deconstruct()
        var (_, Bedrag, Datum) = schade1;
        Console.WriteLine($"{Datum}: {Bedrag:C}");

        // Value-based equality ...

        // Werk immutable met ... with

        Schade schade2 = schade1 with
        {
            Datum = schade1.Datum.AddDays(6 * 7),
            Bedrag = schade1.Bedrag - 3000,
        };

        Console.WriteLine(schade2);

    }

    private static void DemoDeconstruct()
    {
        var polis = new Polis { Code = "ABC123", Klant = new Klant("Mo"), Premie = 123m };
        var (code, klantnaam, premie) = polis;      // Deconstruct
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

        if (s1 is string) {  /* ... */
    }
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
