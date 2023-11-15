using System;

class Program
{
    static void Main()
    {
        // Створюємо рівні підтримки
        SupportHandler level1 = new Level1SupportHandler();
        SupportHandler level2 = new Level2SupportHandler();
        SupportHandler level3 = new Level3SupportHandler();
        SupportHandler level4 = new Level4SupportHandler();

        // Встановлюємо ланцюжок відповідальностей
        level1.SetNext(level2);
        level2.SetNext(level3);
        level3.SetNext(level4);

        // Симулюємо виклик користувача
        Console.WriteLine("Вітаємо в системі підтримки користувачів!");
        level1.HandleRequest();

        Console.ReadLine();
    }
}

abstract class SupportHandler
{
    protected SupportHandler nextHandler;

    public void SetNext(SupportHandler handler)
    {
        nextHandler = handler;
    }

    public abstract void HandleRequest();
}

class Level1SupportHandler : SupportHandler
{
    public override void HandleRequest()
    {
        Console.WriteLine("Чи у вас проблеми з підключенням до мережі?");
        Console.WriteLine("1. Так");
        Console.WriteLine("2. Ні");

        string response = Console.ReadLine();

        if (response == "1")
        {
            Console.WriteLine("Рівень підтримки 1 вирішує проблеми з мережевим підключенням.");
        }
        else if (nextHandler != null)
        {
            nextHandler.HandleRequest();
        }
    }
}

class Level2SupportHandler : SupportHandler
{
    public override void HandleRequest()
    {
        Console.WriteLine("Чи у вас проблеми з програмним забезпеченням?");
        Console.WriteLine("1. Так");
        Console.WriteLine("2. Ні");

        string response = Console.ReadLine();

        if (response == "1")
        {
            Console.WriteLine("Рівень підтримки 2 вирішує проблеми з програмним забезпеченням.");
        }
        else if (nextHandler != null)
        {
            nextHandler.HandleRequest();
        }
    }
}

// Аналогічно реалізуй рівні 3 і 4

class Level3SupportHandler : SupportHandler
{
    public override void HandleRequest()
    {
        Console.WriteLine("Чи у вас проблеми з апаратним забезпеченням?");
        Console.WriteLine("1. Так");
        Console.WriteLine("2. Ні");

        string response = Console.ReadLine();

        if (response == "1")
        {
            Console.WriteLine("Рівень підтримки 3 вирішує проблеми з апаратним забезпеченням.");
        }
        else if (nextHandler != null)
        {
            nextHandler.HandleRequest();
        }
    }
}

class Level4SupportHandler : SupportHandler
{
    public override void HandleRequest()
    {
        Console.WriteLine("Проблема не визначена на жодному рівні підтримки.");
    }
}
