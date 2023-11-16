public class DatabaseRepository
{
    private static DatabaseRepository _instance;
    private static readonly object _lock = new object();

    private DatabaseRepository()
    {
        // Приватний конструктор, щоб запобігти створенню екземпляра за допомогою оператора new
    }

    public static DatabaseRepository Instance
    {
        get
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new DatabaseRepository();
                }
                return _instance;
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        DatabaseRepository db1 = DatabaseRepository.Instance;
        DatabaseRepository db2 = DatabaseRepository.Instance;

        if (db1 == db2)
        {
            Console.WriteLine("db1 and db2 are the same instance.");
        }
    }
}
