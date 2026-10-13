namespace Verzekeringen.App;

public readonly struct Bedrag : IEquatable<Bedrag>
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

    public Bedrag Add(Bedrag other)
    {
        if (Currency != other.Currency)
        {
            throw new InvalidOperationException("Currencies must match");
        }

        return new Bedrag(Value + other.Value, Currency);
    }

    public static bool operator ==(Bedrag left, Bedrag right) => 
        left.Equals(right);

    public static bool operator !=(Bedrag left, Bedrag right) =>
        !left.Equals(right);

    public override int GetHashCode() =>
        HashCode.Combine(Value, Currency);

    public bool Equals(Bedrag other) =>
        Value == other.Value &&
        string.Equals(Currency, other.Currency, StringComparison.Ordinal);

    public override bool Equals(object? obj) =>
        obj is Bedrag other && Equals(other);
    
    
    public static Bedrag operator +(Bedrag a, Bedrag b) =>
        a.Add(b);

    public static implicit operator Bedrag(decimal value) =>
        new Bedrag(value);
    
    public static explicit operator decimal(Bedrag bedrag) =>
        bedrag.Value;

    public static explicit operator int(Bedrag bedrag) =>
        (int)bedrag.Value;

    public override string ToString() =>
        $"{Currency} {Value}";

} 
