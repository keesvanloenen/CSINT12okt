namespace Verzekeringen.App;

public class Klant(string naam)
{
    public int Id { get; set; }                 // Non-nullable value type
    public string Naam { get; set; } = naam;

    public ContactVoorkeur Voorkeur { get; set; }
}
