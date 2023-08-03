class Singleton 
{
    public static int counter = 1;
    private static Singleton instance = new Singleton();

    private Singleton() {}

    public  int NextCounter()
    {
        return counter++;
    }

    public static Singleton GetInstance()
    {
        return instance;
    }
}

class Program
{
    public static void Main(string[] args)
    {
        var single = Singleton.GetInstance();

        System.Console.WriteLine(single.NextCounter());

        var single2 = Singleton.GetInstance();

        System.Console.WriteLine(single.NextCounter());

        System.Console.WriteLine(single == single2);
    }
}