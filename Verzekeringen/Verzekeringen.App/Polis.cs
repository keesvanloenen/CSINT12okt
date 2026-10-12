namespace Verzekeringen.App;

public class Polis
{
    public string? Code { get; set; }        // = null!;
    public Klant? Klant { get; set; }
    public decimal? Premie { get; set; }

	//public Polis(string code)
	//{
	//	Initialize(code);
	//}

 //   private void Initialize(string code)
 //   {
 //       Code = code;
 //   }
}
