namespace Verzekeringen.App.Polissen;

public class ClaimArgs : EventArgs
{
    public string? Omschrijving { get; }
    public decimal Bedrag { get; }

    public ClaimArgs(string? omschrijving, decimal bedrag)
    {
        Omschrijving = omschrijving;
        Bedrag = bedrag;
    }
}
