namespace Verzekeringen.App.Polissen;

public interface ITariefApi
{
    decimal HaalDagtariefOp(string polisSoort); // eigenlijk enum
}
