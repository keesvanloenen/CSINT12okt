// Record struct: value-based equality + Deconstruct + ToString
// Deze variant gebruikt geen primaire constructor
public readonly record struct BedragAlsRecordStruct1
{
    public decimal Value { get; }
    public string Currency { get; }

    public BedragAlsRecordStruct1(decimal value, string currency = "EUR")
    {
        if (value < 0)
        {
            throw new ArgumentException("Bedrag kan niet negatief");
        }

        Value = value;
        Currency = currency;
    }

    public static implicit operator BedragAlsRecordStruct1(decimal value) =>
        new BedragAlsRecordStruct1(value);

    public static explicit operator decimal(BedragAlsRecordStruct1 bedrag) =>
        bedrag.Value;

    public static explicit operator int(BedragAlsRecordStruct1 bedrag) =>
        (int)bedrag.Value;

    public override string ToString() =>
        $"{Currency} {Value}";
}
