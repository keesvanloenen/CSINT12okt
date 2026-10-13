namespace Verzekeringen.App.Polissen;

public class ReisPolis : Polis
{
    public override void BerekenPremie()
    {
        Console.WriteLine("Bereken premie voor ReisPolis");
        Premie = 20m;
    }
}
