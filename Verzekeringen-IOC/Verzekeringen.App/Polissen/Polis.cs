namespace Verzekeringen.App.Polissen;

public class Polis
{
    public string? Code { get; set; }        // = null!;
    public Klant? Klant { get; set; }
    public decimal? Premie { get; set; }

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
