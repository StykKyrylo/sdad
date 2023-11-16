public class Virus
{
    public double Weight { get; set; }
    public int Age { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public List<VirusChild> Children { get; set; }

    public Virus Clone()
    {
        return new Virus
        {
            Weight = this.Weight,
            Age = this.Age,
            Name = this.Name,
            Type = this.Type,
            Children = this.Children.Select(c => c.Clone()).ToList()
        };
    }
}

public class VirusChild : Virus
{
    public DateTime BirthDate { get; set; }
    public Virus Parent { get; set; }

    public new VirusChild Clone()
    {
        return new VirusChild
        {
            Weight = this.Weight,
            Age = this.Age,
            Name = this.Name,
            Type = this.Type,
            Children = this.Children.Select(c => c.Clone()).ToList(),
            BirthDate = this.BirthDate,
            Parent = this.Parent
        };
    }
}

class Program
{
    static void Main(string[] args)
    {
        Virus parent = new Virus
        {
            Weight = 1.0,
            Age = 1,
            Name = "Parent",
            Type = "ParentType",
            Children = new List<VirusChild>()
        };

        VirusChild child = new VirusChild
        {
            Weight = 0.5,
            Age = 0,
            Name = "Child",
            Type = "ChildType",
            BirthDate = DateTime.Now,
            Parent = parent
        };

        parent.Children.Add(child);

        Virus clonedParent = parent.Clone();

        Console.WriteLine($"Parent and clonedParent are the same instance: {parent == clonedParent}");
        Console.WriteLine($"Child and clonedChild are the same instance: {parent.Children[0] == clonedParent.Children[0]}");
    }
}
