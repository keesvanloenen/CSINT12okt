namespace static_en_generics_demo;

public interface ILogger
{
    static string Format(string message) =>
        $"{DateTime.Now}: {message}";
}
