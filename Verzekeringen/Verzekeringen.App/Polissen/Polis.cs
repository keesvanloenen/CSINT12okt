namespace Verzekeringen.App.Polissen;

//public delegate void PolisHandler(object sender, ClaimArgs args);		// straks mooier

public class Polis
{
    public string? Code { get; set; }        // = null!;
    public Klant? Klant { get; set; }
    public decimal? Premie { get; set; }

	public decimal Uitgekeerd { get; private set; } = 0m;

	public event EventHandler<ClaimArgs>? ClaimIngediend;
    
    public void VerwerkClaim(decimal bedrag, string omschrijving)
	{
		Uitgekeerd += bedrag;

		if (bedrag > 1100)
		{
			var claimArgs = new ClaimArgs("Bedrag boven de 1100", bedrag);
			OnClaimIngediend(claimArgs);
		}
	}

	protected virtual void OnClaimIngediend(ClaimArgs args)
	{
        ClaimIngediend?.Invoke(this, args);

        //if (ClaimIngediend is not null)
        //{
        //	ClaimIngediend(this, "Bedrag boven de 1100");
        //}
    }

    public void Deconstruct(out string? code, out string? klantNaam, out decimal? premie)
	{
		code = Code;
		klantNaam = Klant?.Naam;
		premie = Premie;
	}

	public virtual void BerekenPremie()
	{
		Console.WriteLine("Bereken standaard premie");
		Premie = 50m;
	}
}
