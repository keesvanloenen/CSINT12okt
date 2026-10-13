// Nogmaals een record struct
// Deze variant gebruikt wel een primaire constructor
public readonly record struct BedragAlsRecordStruct2(decimal Value, string Currency = "EUR")
{
    public decimal Value { get; } =
        Value >= 0
        ? Value
        : throw new ArgumentException("Bedrag kan niet negatief");
    
    public static implicit operator BedragAlsRecordStruct2(decimal value) =>
        new BedragAlsRecordStruct2(value);

    public static explicit operator decimal(BedragAlsRecordStruct2 bedrag) =>
        bedrag.Value;

    public static explicit operator int(BedragAlsRecordStruct2 bedrag) =>
        (int)bedrag.Value;

    public override string ToString() =>
        $"{Currency} {Value}";
}
