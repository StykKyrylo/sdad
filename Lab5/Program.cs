// Завдання 1: Компонувальник
using System.Text.RegularExpressions;

public abstract class LightNode
{
    public abstract string OuterHTML { get; }
    public abstract string InnerHTML { get; }
}

public class LightTextNode : LightNode
{
    private string _text;

    public LightTextNode(string text)
    {
        _text = text;
    }

    public override string OuterHTML => _text;
    public override string InnerHTML => _text;
}

public class LightElementNode : LightNode
{
    private string _tagName;
    private bool _isBlock;
    private bool _isSelfClosing;
    private List<string> _classes;
    private List<LightNode> _children;

    public LightElementNode(string tagName, bool isBlock, bool isSelfClosing)
    {
        _tagName = tagName;
        _isBlock = isBlock;
        _isSelfClosing = isSelfClosing;
        _classes = new List<string>();
        _children = new List<LightNode>();
    }

    public override string OuterHTML
    {
        get
        {
            string classes = string.Join(" ", _classes);
            string children = string.Join("", _children.Select(c => c.OuterHTML));
            return $"<{_tagName} class=\"{classes}\">{children}{(_isSelfClosing ? "/" : "")}</{_tagName}>";
        }
    }

    public override string InnerHTML
    {
        get
        {
            return string.Join("", _children.Select(c => c.OuterHTML));
        }
    }

    public void AppendChild(LightNode node)
    {
        _children.Add(node);
    }

    public void ReplaceChild(LightNode node, LightNode newNode)
    {
        int index = _children.IndexOf(node);
        if (index != -1)
        {
            _children[index] = newNode;
        }
    }

    public void RemoveChild(LightNode node)
    {
        _children.Remove(node);
    }

    public void InsertBefore(LightNode node, LightNode refNode)
    {
        int index = _children.IndexOf(refNode);
        if (index != -1)
        {
            _children.Insert(index, node);
        }
    }
}

// Завдання 2: Компонувальник
public class IronMan : Hero
{
    public override string GetDescription()
    {
        return "IronMan";
    }
}

public class GloveOfPower : HeroDecorator
{
    public GloveOfPower(Hero hero) : base(hero) { }

    public override string GetDescription()
    {
        return base.GetDescription() + ", GloveOfPower";
    }
}

public class InfinityStones : HeroDecorator
{
    public InfinityStones(Hero hero) : base(hero) { }

    public override string GetDescription()
    {
        return base.GetDescription() + ", InfinityStones";
    }
}

// Завдання 3: Проксі
public class SmartTextReader
{
    public string[][] Read(string filePath)
    {
        // Реалізація читання тексту з файлу і перетворення його на двомірний масив
    }
}

public class SmartTextChecker : SmartTextReader
{
    private SmartTextReader _smartTextReader;

    public SmartTextChecker(SmartTextReader smartTextReader)
    {
        _smartTextReader = smartTextReader;
    }

    public new string[][] Read(string filePath)
    {
        Console.WriteLine("Opening file...");
        string[][] text = _smartTextReader.Read(filePath);
        Console.WriteLine("File opened successfully.");
        Console.WriteLine($"Total lines: {text.Length}");
        Console.WriteLine($"Total characters: {text.Sum(line => line.Length)}");
        Console.WriteLine("Closing file...");
        return text;
    }
}

public class SmartTextReaderLocker : SmartTextReader
{
    private SmartTextReader _smartTextReader;
    private Regex _regex;

    public SmartTextReaderLocker(SmartTextReader smartTextReader, string pattern)
    {
        _smartTextReader = smartTextReader;
        _regex = new Regex(pattern);
    }

    public new string[][] Read(string filePath)
    {
        if (_regex.IsMatch(filePath))
        {
            Console.WriteLine("Access denied!");
            return null;
        }
        else
        {
            return _smartTextReader.Read(filePath);
        }
    }
}

// Завдання 4: Легковаговик
public class LightHTML
{
    public LightNode Parse(string text)
    {
        // Реалізація аналізу тексту і перетворення його на LightHTML
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Завдання 1: Компонувальник
        LightElementNode element = new LightElementNode("div", true, false);
        element.AppendChild(new LightTextNode("Hello, world!"));
        Console.WriteLine(element.OuterHTML);

        // Завдання 2: Компонувальник
        Hero hero = new IronMan();
        hero = new GloveOfPower(hero);
        hero = new InfinityStones(hero);
        Console.WriteLine(hero.GetDescription());

        // Завдання 3: Проксі
        SmartTextReader smartTextReader = new SmartTextReader();
        SmartTextChecker smartTextChecker = new SmartTextChecker(smartTextReader);
        SmartTextReaderLocker smartTextReaderLocker = new SmartTextReaderLocker(smartTextChecker, ".*\\.txt$");
        smartTextReaderLocker.Read("file.txt");

        // Завдання 4: Легковаговик
        LightHTML lightHTML = new LightHTML();
        LightNode node = lightHTML.Parse("Hello, world!");
        Console.WriteLine(node.OuterHTML);
    }
}
