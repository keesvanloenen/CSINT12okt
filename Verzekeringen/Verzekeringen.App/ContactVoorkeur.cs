namespace Verzekeringen.App;

[Flags]
public enum ContactVoorkeur : ushort
{
    Geen = 0b00000000,       // 0000     // 1 << 0
    Email = 1,      // 0001     // 1 << 1
    Telefoon = 2,   // 0010     // 1 << 2
    Post = 4,
    Sms = 8,
    WhatsApp = 16,
}
