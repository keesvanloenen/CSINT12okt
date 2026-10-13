namespace Verzekeringen.App.Polissen;

public class AutoPolis : Polis
{
    private readonly ITariefApi _tariefApi;     // deze onthoudt echt de waarde (state)
    
    public AutoPolis(ITariefApi tariefApi)
    {
        _tariefApi = tariefApi;
    }

    public override void BerekenPremie()
    {
        Console.WriteLine("Bereken premie voor AutoPolis");
        Premie = 100m;

        var extraPremie = _tariefApi.HaalDagtariefOp("auto");
        Premie += extraPremie;
    }

    
}
