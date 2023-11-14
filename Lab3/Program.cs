public abstract class Subscription
{
    public decimal MonthlyFee { get; set; }
    public int MinimumPeriod { get; set; }
    public List<string> Channels { get; set; }
}

public class DomesticSubscription : Subscription
{
    public string Region { get; set; }

    public DomesticSubscription(decimal monthlyFee, int minimumPeriod, List<string> channels, string region)
    {
        MonthlyFee = monthlyFee;
        MinimumPeriod = minimumPeriod;
        Channels = channels;
        Region = region;
    }

    // Пример дополнительной логики для DomesticSubscription
    public void DisplaySubscriptionDetails()
    {
        Console.WriteLine($"Subscription Details: Domestic Subscription");
        Console.WriteLine($"Monthly Fee: {MonthlyFee:C}");
        Console.WriteLine($"Minimum Period: {MinimumPeriod} months");
        Console.WriteLine($"Channels: {string.Join(", ", Channels)}");
        Console.WriteLine($"Region: {Region}");
    }
}

public class EducationalSubscription : Subscription
{
    public List<string> EducationalResources { get; set; }

    public EducationalSubscription(decimal monthlyFee, int minimumPeriod, List<string> channels, List<string> educationalResources)
    {
        MonthlyFee = monthlyFee;
        MinimumPeriod = minimumPeriod;
        Channels = channels;
        EducationalResources = educationalResources;
    }

    // Пример дополнительной логики для EducationalSubscription
    public void DisplaySubscriptionDetails()
    {
        Console.WriteLine($"Subscription Details: Educational Subscription");
        Console.WriteLine($"Monthly Fee: {MonthlyFee:C}");
        Console.WriteLine($"Minimum Period: {MinimumPeriod} months");
        Console.WriteLine($"Channels: {string.Join(", ", Channels)}");
        Console.WriteLine($"Educational Resources: {string.Join(", ", EducationalResources)}");
    }
}

public class PremiumSubscription : Subscription
{
    public bool AccessToPremiumContent { get; set; }

    public PremiumSubscription(decimal monthlyFee, int minimumPeriod, List<string> channels, bool accessToPremiumContent)
    {
        MonthlyFee = monthlyFee;
        MinimumPeriod = minimumPeriod;
        Channels = channels;
        AccessToPremiumContent = accessToPremiumContent;
    }

    // Пример дополнительной логики для PremiumSubscription
    public void DisplaySubscriptionDetails()
    {
        Console.WriteLine($"Subscription Details: Premium Subscription");
        Console.WriteLine($"Monthly Fee: {MonthlyFee:C}");
        Console.WriteLine($"Minimum Period: {MinimumPeriod} months");
        Console.WriteLine($"Channels: {string.Join(", ", Channels)}");
        Console.WriteLine($"Access to Premium Content: {(AccessToPremiumContent ? "Yes" : "No")}");
    }
}

public interface ISubscriptionCreator
{
    Subscription CreateSubscription { get; }
}

public class WebSite : ISubscriptionCreator
{
    Subscription ISubscriptionCreator.CreateSubscription => throw new NotImplementedException();

    public Subscription CreateSubscription()
    {
        // Логика создания подписки через веб-сайт
        // В данном случае, давайте представим, что пользователь выбирает тип подписки на веб-сайте
        // и вводит необходимые параметры, которые мы передадим соответствующему классу подписки.

        Console.WriteLine("Creating a subscription via website...");

        // Получаем данные от пользователя или используем значения по умолчанию
        decimal monthlyFee = GetMonthlyFeeFromUser();
        int minimumPeriod = GetMinimumPeriodFromUser();
        List<string> channels = GetChannelsFromUser();

        // Предположим, что на веб-сайте пользователь выбирает тип подписки
        // В данном примере, давайте создадим экземпляр EducationalSubscription
        List<string> educationalResources = GetEducationalResourcesFromUser();
        return new EducationalSubscription(monthlyFee, minimumPeriod, channels, educationalResources);
    }

    // Пример методов для получения данных от пользователя
    private decimal GetMonthlyFeeFromUser()
    {
        Console.Write("Enter monthly fee: ");
        return Convert.ToDecimal(Console.ReadLine());
    }

    private int GetMinimumPeriodFromUser()
    {
        Console.Write("Enter minimum period (in months): ");
        return Convert.ToInt32(Console.ReadLine());
    }

    private List<string> GetChannelsFromUser()
    {
        Console.Write("Enter channels (comma-separated): ");
        return Console.ReadLine().Split(',').Select(channel => channel.Trim()).ToList();
    }

    private List<string> GetEducationalResourcesFromUser()
    {
        Console.Write("Enter educational resources (comma-separated): ");
        return Console.ReadLine().Split(',').Select(resource => resource.Trim()).ToList();
    }
}


public class MobileApp : ISubscriptionCreator
{
    Subscription ISubscriptionCreator.CreateSubscription => throw new NotImplementedException();

    public Subscription CreateSubscription()
    {
        // Логика создания подписки через мобильное приложение
        // В данном случае, предположим, что пользователь выбирает тип подписки в мобильном приложении
        // и вводит необходимые параметры, которые мы передадим соответствующему классу подписки.

        Console.WriteLine("Creating a subscription via mobile app...");

        // Получаем данные от пользователя или используем значения по умолчанию
        decimal monthlyFee = GetMonthlyFeeFromUser();
        int minimumPeriod = GetMinimumPeriodFromUser();
        List<string> channels = GetChannelsFromUser();

        // Предположим, что в мобильном приложении пользователь выбирает тип подписки
        // В данном примере, давайте создадим экземпляр PremiumSubscription
        bool accessToPremiumContent = GetAccessToPremiumContentFromUser();
        return new PremiumSubscription(monthlyFee, minimumPeriod, channels, accessToPremiumContent);
    }

    // Пример методов для получения данных от пользователя
    private decimal GetMonthlyFeeFromUser()
    {
        Console.Write("Enter monthly fee: ");
        return Convert.ToDecimal(Console.ReadLine());
    }

    private int GetMinimumPeriodFromUser()
    {
        Console.Write("Enter minimum period (in months): ");
        return Convert.ToInt32(Console.ReadLine());
    }

    private List<string> GetChannelsFromUser()
    {
        Console.Write("Enter channels (comma-separated): ");
        return Console.ReadLine().Split(',').Select(channel => channel.Trim()).ToList();
    }

    private bool GetAccessToPremiumContentFromUser()
    {
        Console.Write("Does the user have access to premium content? (true/false): ");
        return Convert.ToBoolean(Console.ReadLine());
    }
}


public class ManagerCall : ISubscriptionCreator
{
    Subscription ISubscriptionCreator.CreateSubscription => throw new NotImplementedException();

    public Subscription CreateSubscription()
    {
        // Логика создания подписки через звонок менеджеру
        // В данном случае, предположим, что менеджер задает вопросы пользователю и 
        // формирует подписку в зависимости от ответов.

        Console.WriteLine("Creating a subscription via manager call...");

        // Получаем данные от пользователя или используем значения по умолчанию
        decimal monthlyFee = GetMonthlyFeeFromManager();
        int minimumPeriod = GetMinimumPeriodFromManager();
        List<string> channels = GetChannelsFromManager();

        // Предположим, что менеджер на основе ответов формирует тип подписки
        // В данном примере, давайте создадим экземпляр DomesticSubscription
        string region = GetRegionFromManager();
        return new DomesticSubscription(monthlyFee, minimumPeriod, channels, region);
    }

    // Пример методов для получения данных от пользователя
    private decimal GetMonthlyFeeFromManager()
    {
        Console.Write("Enter monthly fee (as suggested by the manager): ");
        return Convert.ToDecimal(Console.ReadLine());
    }

    private int GetMinimumPeriodFromManager()
    {
        Console.Write("Enter minimum period (in months, as suggested by the manager): ");
        return Convert.ToInt32(Console.ReadLine());
    }

    private List<string> GetChannelsFromManager()
    {
        Console.Write("Enter channels (as suggested by the manager, comma-separated): ");
        return Console.ReadLine().Split(',').Select(channel => channel.Trim()).ToList();
    }

    private string GetRegionFromManager()
    {
        Console.Write("Enter region (as suggested by the manager): ");
        return Console.ReadLine();
    }
}


class Program
{
    static void Main(string[] args)
    {
        ISubscriptionCreator creator = new WebSite();
        Subscription subscription = creator.CreateSubscription;
        // ...
    }
}