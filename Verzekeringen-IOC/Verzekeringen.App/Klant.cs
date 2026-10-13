namespace Verzekeringen.App;

public class Klant(string naam)
{
    public int Id { get; set; }
    public string Naam { get; set; } = naam;
    public ContactVoorkeur Voorkeur { get; set; }
}
