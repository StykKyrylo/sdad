// Клас Money має одну відповідальність: представляти гроші.
// Це відповідає принципу єдиної відповідальності (Single Responsibility Principle).
public class Money
{
    public int Dollars { get; set; }
    public int Cents { get; set; }

    public Money(int dollars, int cents)
    {
        Dollars = dollars;
        Cents = cents;
    }

    // Метод Display() відповідає за виведення грошей.
    // Це відповідає принципу розділення інтерфейсу (Interface Segregation Principle),
    // оскільки класи, які використовують Money, можуть вибрати, чи хочуть вони виводити гроші.
    public void Display()
    {
        Console.WriteLine($"{Dollars}.{Cents}");
    }
}

// Клас Product має одну відповідальність: представляти продукт.
// Це відповідає принципу єдиної відповідальності (Single Responsibility Principle).
public class Product
{
    public string Name { get; set; }
    public Money Price { get; set; }

    public Product(string name, Money price)
    {
        Name = name;
        Price = price;
    }

    // Метод ReducePrice() відповідає за зменшення ціни продукту.
    // Це відповідає принципу розділення інтерфейсу (Interface Segregation Principle),
    // оскільки класи, які використовують Product, можуть вибрати, чи хочуть вони зменшувати ціну.
    public void ReducePrice(int amount)
    {
        Price.Dollars -= amount;
    }
}

// Клас Warehouse має одну відповідальність: представляти склад.
// Це відповідає принципу єдиної відповідальності (Single Responsibility Principle).
public class Warehouse
{
    public List<Product> Products { get; set; }

    public Warehouse()
    {
        Products = new List<Product>();
    }

    // Метод AddProduct() відповідає за додавання продукту на склад.
    // Це відповідає принципу розділення інтерфейсу (Interface Segregation Principle),
    // оскільки класи, які використовують Warehouse, можуть вибрати, чи хочуть вони додавати продукти.
    public void AddProduct(Product product)
    {
        Products.Add(product);
    }
}

// Клас Reporting має одну відповідальність: представляти звітність.
// Це відповідає принципу єдиної відповідальності (Single Responsibility Principle).
public class Reporting
{
    private Warehouse _warehouse;

    public Reporting(Warehouse warehouse)
    {
        _warehouse = warehouse;
    }

    // Метод InventoryReport() відповідає за створення звіту про інвентаризацію.
    // Це відповідає принципу розділення інтерфейсу (Interface Segregation Principle),
    // оскільки класи, які використовують Reporting, можуть вибрати, чи хочуть вони створювати звіти про інвентаризацію.
    public void InventoryReport()
    {
        foreach (var product in _warehouse.Products)
        {
            Console.WriteLine($"Product: {product.Name}, Price: {product.Price.Dollars}.{product.Price.Cents}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Створюємо новий об'єкт Money
        Money price = new Money(100, 50);
        price.Display(); // Виводимо ціну

        // Створюємо новий об'єкт Product
        Product product = new Product("Product1", price);
        Console.WriteLine($"Product: {product.Name}, Price: {product.Price.Dollars}.{product.Price.Cents}");

        // Зменшуємо ціну продукту
        product.ReducePrice(10);
        Console.WriteLine($"Product: {product.Name}, Price: {product.Price.Dollars}.{product.Price.Cents}");

        // Створюємо новий об'єкт Warehouse і додаємо продукт
        Warehouse warehouse = new Warehouse();
        warehouse.AddProduct(product);

        // Створюємо новий об'єкт Reporting і генеруємо звіт
        Reporting reporting = new Reporting(warehouse);
        reporting.InventoryReport();
    }
}
