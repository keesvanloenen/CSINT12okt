namespace Verzekeringen.App;

public readonly struct Bedrag
{
    public decimal Value { get; }
    public string Currency { get; }

    public Bedrag(decimal value, string currency = "EUR")
    {
        if (value <0)
        {
            throw new ArgumentException("Bedrag kan niet negatief");
        }

        Value = value;
        Currency = currency;
    }

    public static implicit operator Bedrag(decimal value) =>
        new Bedrag(value);
    
    public static explicit operator decimal(Bedrag bedrag) =>
        bedrag.Value;

    public static explicit operator int(Bedrag bedrag) =>
        (int)bedrag.Value;

    public override string ToString() =>
        $"{Currency} {Value}";
} 
