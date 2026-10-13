namespace Verzekeringen.App.Polissen;

public class AutoPolis : Polis
{
    public override void BerekenPremie()
    {
        Console.WriteLine("Bereken premie voor AutoPolis");
        Premie = 100m;

        var tariefApi = new TariefApi();
        var extraPremie = tariefApi.HaalDagtariefOp("auto");
        Premie += extraPremie;
    }
}
