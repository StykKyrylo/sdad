// Завдання 1: Адаптер
using System.IO;

public class Logger
{
    public void Log(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public void Error(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public void Warn(string message)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}

public class FileWriter
{
    private string filePath; // Путь к файлу для записи

    public FileWriter()
    {
    }

    public FileWriter(string path)
    {
        filePath = path;
    }

    public void Write(string text)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(text);
            }

            Console.WriteLine($"Текст успешно записан в файл {filePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при записи в файл: {ex.Message}");
        }
    }
}

public class FileLogger : Logger
{
    private readonly FileWriter _fileWriter;

    public FileLogger(FileWriter fileWriter)
    {
        _fileWriter = fileWriter;
    }

    public new void Log(string message)
    {
        _fileWriter.Write(message);
    }

    public new void Error(string message)
    {
        _fileWriter.Write(message);
    }

    public new void Warn(string message)
    {
        _fileWriter.Write(message);
    }
}

// Завдання 2: Декоратор
public abstract class Hero
{
    public abstract string GetDescription();
}

public class Warrior : Hero
{
    public override string GetDescription()
    {
        return "Warrior";
    }
}

public class Mage : Hero
{
    public override string GetDescription()
    {
        return "Mage";
    }
}

public class Paladin : Hero
{
    public override string GetDescription()
    {
        return "Paladin";
    }
}

public abstract class HeroDecorator : Hero
{
    protected readonly Hero _hero;

    public HeroDecorator(Hero hero)
    {
        _hero = hero;
    }

    public override string GetDescription()
    {
        return _hero.GetDescription();
    }
}

public class ArmorDecorator : HeroDecorator
{
    public ArmorDecorator(Hero hero) : base(hero) { }

    public override string GetDescription()
    {
        return base.GetDescription() + ", Armor";
    }
}

public class SwordDecorator : HeroDecorator
{
    public SwordDecorator(Hero hero) : base(hero) { }

    public override string GetDescription()
    {
        return base.GetDescription() + ", Sword";
    }
}

// Завдання 3: Фасад
public class BigMacMenu
{
    public void Prepare()
    {
        // Реалізація приготування BigMac Menu
    }
}

// Завдання 4: Міст
public abstract class Shape
{
    protected readonly IRenderer _renderer;

    public Shape(IRenderer renderer)
    {
        _renderer = renderer;
    }

    public abstract void Draw();
}

public class Circle : Shape
{
    public Circle(IRenderer renderer) : base(renderer) { }

    public override void Draw()
    {
        _renderer.Render("Drawing Circle");
    }
}

public class Square : Shape
{
    public Square(IRenderer renderer) : base(renderer) { }

    public override void Draw()
    {
        _renderer.Render("Drawing Square");
    }
}

public class Triangle : Shape
{
    public Triangle(IRenderer renderer) : base(renderer) { }

    public override void Draw()
    {
        _renderer.Render("Drawing Triangle");
    }
}

public interface IRenderer
{
    void Render(string message);
}

public class VectorRenderer : IRenderer
{
    public void Render(string message)
    {
        Console.WriteLine(message + " as vector graphics");
    }
}

public class RasterRenderer : IRenderer
{
    public void Render(string message)
    {
        Console.WriteLine(message + " as pixels");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Завдання 1: Адаптер
        FileWriter fileWriter = new FileWriter();
        FileLogger fileLogger = new FileLogger(fileWriter);
        fileLogger.Log("Log message");
        fileLogger.Error("Error message");
        fileLogger.Warn("Warn message");

        // Завдання 2: Декоратор
        Hero hero = new Warrior();
        hero = new ArmorDecorator(hero);
        hero = new SwordDecorator(hero);
        Console.WriteLine(hero.GetDescription());

        // Завдання 3: Фасад
        BigMacMenu bigMacMenu = new BigMacMenu();
        bigMacMenu.Prepare();

        // Завдання 4: Міст
        Shape shape = new Circle(new VectorRenderer());
        shape.Draw();
        shape = new Square(new RasterRenderer());
        shape.Draw();
    }
}