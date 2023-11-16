public class Character
{
    public string Height { get; set; }
    public string Stature { get; set; }
    public string HairColor { get; set; }
    public string EyeColor { get; set; }
    public string Clothing { get; set; }
    public string Inventory { get; set; }
}

public interface ICharacterBuilder
{
    void SetHeight(string height);
    void SetStature(string stature);
    void SetHairColor(string hairColor);
    void SetEyeColor(string eyeColor);
    void SetClothing(string clothing);
    void SetInventory(string inventory);
    Character GetCharacter();
}

public class HeroBuilder : ICharacterBuilder
{
    private Character _character = new Character();

    public void SetHeight(string height)
    {
        _character.Height = height;
    }

    public void SetStature(string stature)
    {
        _character.Stature = stature;
    }

    public void SetHairColor(string hairColor)
    {
        _character.HairColor = hairColor;
    }

    public void SetEyeColor(string eyeColor)
    {
        _character.EyeColor = eyeColor;
    }

    public void SetClothing(string clothing)
    {
        _character.Clothing = clothing;
    }

    public void SetInventory(string inventory)
    {
        _character.Inventory = inventory;
    }

    public Character GetCharacter()
    {
        return _character;
    }
}

public class EnemyBuilder : ICharacterBuilder
{
    private Character _character = new Character();

    public void SetHeight(string height)
    {
        _character.Height = height;
    }

    public void SetStature(string stature)
    {
        _character.Stature = stature;
    }

    public void SetHairColor(string hairColor)
    {
        _character.HairColor = hairColor;
    }

    public void SetEyeColor(string eyeColor)
    {
        _character.EyeColor = eyeColor;
    }

    public void SetClothing(string clothing)
    {
        _character.Clothing = clothing;
    }

    public void SetInventory(string inventory)
    {
        _character.Inventory = inventory;
    }

    public Character GetCharacter()
    {
        return _character;
    }
}

public class Director
{
    public void Construct(ICharacterBuilder builder)
    {
        builder.SetHeight("Tall");
        builder.SetStature("Strong");
        builder.SetHairColor("Black");
        builder.SetEyeColor("Blue");
        builder.SetClothing("Armor");
        builder.SetInventory("Sword");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Director director = new Director();

        HeroBuilder heroBuilder = new HeroBuilder();
        director.Construct(heroBuilder);
        Character hero = heroBuilder.GetCharacter();

        EnemyBuilder enemyBuilder = new EnemyBuilder();
        director.Construct(enemyBuilder);
        Character enemy = enemyBuilder.GetCharacter();

        Console.WriteLine($"Hero: {hero.Height}, {hero.Stature}, {hero.HairColor}, {hero.EyeColor}, {hero.Clothing}, {hero.Inventory}");
        Console.WriteLine($"Enemy: {enemy.Height}, {enemy.Stature}, {enemy.HairColor}, {enemy.EyeColor}, {enemy.Clothing}, {enemy.Inventory}");
    }
}