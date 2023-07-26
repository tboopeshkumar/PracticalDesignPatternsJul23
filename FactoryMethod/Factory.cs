abstract class Product
{
    protected String description = "";
    public abstract void MakeComputer(int cpu, int ram, int storage, int display);
    public String GetInfo()
    {
        return this.description;
    }
}

class PC : Product
{
    public override void MakeComputer(int cpu, int ram, int storage, int display)
    {
        this.description = $"DELL PC: CPU {cpu}, RAM {ram}, STORAGE {storage}, DISPLAY {display}";
    }
}

class Laptop : Product
{
    public override void MakeComputer(int cpu, int ram, int storage, int display)
    {
        this.description = $"DELL Laptop: CPU {cpu}, RAM {ram}, STORAGE {storage}, DISPLAY {display}";
    }
}

class ComputerFactory
{
    private Dictionary<string, Func<Product>> factory = new() 
    {
      {"PC", () => new PC()},
      {"Laptop", () => new Laptop()},
    };
    
    public Product CreateComputer(string type)
    {          
        return factory[type]();
    }
}

public class Order
{
    private ComputerFactory cs = new ComputerFactory();
    Product? PlaceOrder(string type, int cpu, int ram, int storage, int display)
    {
        Product? product = cs.CreateComputer(type);
        product.MakeComputer(cpu, ram, storage, display);
        return product;
    }

    public static void Main()
    {
        var order = new Order();
        var computer = order.PlaceOrder("Laptop", 4, 16, 512, 16);
        Console.WriteLine(computer?.GetInfo());
    }
}

