interface DiscountStrategy
{
    double CalculateDiscount();
}

class Product
{
    public string name;
    public double unitPrice;
    public double quantity;

    public Product(string name, double unitPrice, int quantity)
    {
        this.name = name;
        this.unitPrice = unitPrice;
        this.quantity = quantity;
    }
}

class Order
{
    List<Product> productList = new();
    DiscountStrategy discountStrategy = new NoDiscount();

    public void AddProduct(Product product)
    {
        productList.Add(product);
    }

    public List<Product> GetProductList()
    {
        return productList;
    }

    public void SetDiscountStrategy(DiscountStrategy strategy)
    {
        this.discountStrategy = strategy;
    }

    public void CheckOut()
    {
        double total = 0;
        double discount = 0;
        foreach (var product in productList)
        {
            total += product.unitPrice * product.quantity;
        }

        discount = discountStrategy.CalculateDiscount() * total;
       
        System.Console.WriteLine("Order details");
        foreach (var product in productList)
        {
            System.Console.WriteLine($"{product.name} {product.unitPrice} {product.quantity} {product.unitPrice * product.quantity}");
        }
        System.Console.WriteLine($"Amount: {total}", total);
        System.Console.WriteLine($"Discount: {discount}");
        System.Console.WriteLine($"Net: {total - discount}");
    }
}

class NoDiscount : DiscountStrategy {
    public double CalculateDiscount() {
        return 0;
    }
}

class StandardDiscount : DiscountStrategy {
    public double CalculateDiscount() {
        return .10d;
    }
}

class VipDiscount : DiscountStrategy{
    public double CalculateDiscount() {
        return .30d;
    }
}

class HighValueHighDiscount: DiscountStrategy {
     public double CalculateDiscount() {
        return .20d;
    }
}
class HighValueLowDiscount: DiscountStrategy {
     public double CalculateDiscount() {
        return .10d;
    }
}

public class StrategyDemo
{
    public static void Main(string[] args)
    {
        var order = new Order();
        order.AddProduct(new Product("iPhone", 1_00_000, 1));
        order.AddProduct(new Product("AirPods", 30_000, 2));
        order.AddProduct(new Product("Macbook", 2_20_000, 1));
        order.SetDiscountStrategy(new StandardDiscount());
        order.CheckOut();
    }
}
