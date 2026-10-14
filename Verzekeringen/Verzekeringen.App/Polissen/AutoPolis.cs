namespace Verzekeringen.App.Polissen;

public class AutoPolis : Polis
{
    private readonly ITariefApi _tariefApi;     // deze onthoudt echt de waarde (state)

    public int AantalClaims { get; private set; }
    public bool IsRisicoVol { get; private set; }

    public AutoPolis(ITariefApi tariefApi)
    {
        _tariefApi = tariefApi;
    }

    protected override void OnClaimIngediend(ClaimArgs args)
    {
        AantalClaims++;
        IsRisicoVol = (AantalClaims > 1);

        base.OnClaimIngediend(args);
    }

    public override void BerekenPremie()
    {
        Console.WriteLine("Bereken premie voor AutoPolis");
        Premie = 100m;

        var extraPremie = _tariefApi.HaalDagtariefOp("auto");
        Premie += extraPremie;
    }

    
}
