public abstract class Clothing
{
    public string Type { get; set; }
}

public class MenClothing : Clothing
{
    public string Size { get; set; }
    public string Style { get; set; }

    // Дополнительные свойства и методы для MenClothing
}

public class WomenClothing : Clothing
{
    public string Size { get; set; }
    public string Color { get; set; }

    // Дополнительные свойства и методы для WomenClothing
}

public class ChildrenClothing : Clothing
{
    public string AgeGroup { get; set; }

    // Дополнительные свойства и методы для ChildrenClothing
}

public interface IClothingFactory
{
    Clothing CreateClothing();
}

public class ShoesFactory : IClothingFactory
{
    public Clothing CreateClothing()
    {
        // Логика создания обуви
        return new MenClothing { Type = "Shoes", Size = "42", Style = "Casual" };
    }
}

public class SocksFactory : IClothingFactory
{
    public Clothing CreateClothing()
    {
        // Логика создания шкарпеток
        return new WomenClothing { Type = "Socks", Size = "One Size", Color = "White" };
    }
}

public class HatsFactory : IClothingFactory
{
    public Clothing CreateClothing()
    {
        // Логика создания шапок
        return new ChildrenClothing { Type = "Hats", AgeGroup = "5-10" };
    }
}

public class TShirtsFactory : IClothingFactory
{
    public Clothing CreateClothing()
    {
        // Логика создания футболок
        return new MenClothing { Type = "T-Shirt", Size = "M", Style = "Sporty" };
    }
}

class Program
{
    static void Main(string[] args)
    {
        IClothingFactory factory = new ShoesFactory();
        Clothing clothing = factory.CreateClothing();
        // ...
    }
}
