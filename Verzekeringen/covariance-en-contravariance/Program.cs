namespace covariance_en_contravariance;

interface IJuicer<in T>        // in means contravariant, iN -> coNtravariant
{
    void Juice(T fruit);
}

public class FruitJuicer : IJuicer<Fruit>
{
    public void Juice(Fruit fruit)
    {
        Console.WriteLine($"Juicing a {fruit.Name}");
    }
}



public abstract class Fruit
{
    public required string Name { get; set; }
}

public class Apple : Fruit { }
public class Banana : Fruit { }

internal class Program
{
    static void Main(string[] args)
    {
        // covariance
        Apple apple1 = new Apple { Name = "Braeburn" };
        Apple apple2 = new Apple { Name = "Fuji" };
        List<Apple> apples = [apple1, apple2];
        ShowFruits(apples);

        // --------------------------------------------

        // contravariant
        IJuicer<Fruit> fruitJuicer = new FruitJuicer();
        JuiceApples(fruitJuicer);

    }

    private static void ShowFruits(IEnumerable<Fruit> fruits)
    {
        foreach (var fruit in fruits)
        {
            Console.WriteLine(fruit.Name);
        }

        //Fruit banana = new Banana { Name = "Chiquita " };
        //fruits[0] = banana;
    }

    static void JuiceApples(IJuicer<Apple> appleJuicer)
    {
        appleJuicer.Juice(new Apple { Name = "Golden Delicious" });
    }

}
