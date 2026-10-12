namespace Verzekeringen.App;

public class Klant
{
    public int Id { get; set; }                 // Non-nullable value type
    public string Naam { get; set; }            // Non-nullable reference type (set in constructor)

    public ContactVoorkeur Voorkeur { get; set; }

    public Klant(string naam)
    {
        Naam = naam;
    }
}
