namespace Verzekeringen.App.Polissen;

public class TariefApi : ITariefApi
{
    public decimal HaalDagtariefOp(string polisSoort)
    {
        Console.WriteLine($"Dagtarief wordt opgehaald bij externe API voor {polisSoort}");
        return polisSoort == "auto" ? 2.50m : 1.00m;
    }
}
