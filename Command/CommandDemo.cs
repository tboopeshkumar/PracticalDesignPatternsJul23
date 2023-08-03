
public interface StockMarket {
  void Buy(string stock, int quantity);
  void Sell(string stock, int quantity);
}

class BSE : StockMarket {
  public void Buy(string stock, int quantity) {
    Console.WriteLine($"Buying {quantity} shares of {stock} on BSE");
  }

  public void Sell(string stock, int quantity) {
    Console.WriteLine($"Selling {quantity} shares of {stock} on BSE");
  }
}

public interface Command {
  void Execute();
}

public class BuyCommand : Command {
  private StockMarket sm;
  private string stock;
  private int quantity;
  public BuyCommand(StockMarket stockMarket, string stock, int quantity) {
    this.sm = stockMarket;
    this.quantity = quantity ;
    this.stock = stock;
  }
  public void Execute() {
    sm.Buy(stock, quantity);
  }
}

public class SellCommand : Command {
  private StockMarket sm;
  private string stock;
  private int quantity;
  public SellCommand(StockMarket stockMarket, string stock, int quantity) {
    this.sm = stockMarket;
    this.quantity = quantity ;
    this.stock = stock;
  }
  public void Execute() {
  sm.Sell(stock, quantity);
  }
}

public class Broker {
  Queue<Command> queue = new Queue<Command>();
  public void PlaceOrder(Command command) {
    queue.Enqueue(command);
  }

  public void ProcessOrders() {
    foreach(var order in queue) {
      order.Execute();
    }
  }
}


public class CommandDemo {
  public static void Main() {
  
    var sm = new BSE();
    var buyCommand = new BuyCommand(sm, "Reliance", 100);
    var sellCommand = new SellCommand(sm, "ACC", 1000);

    var broker = new Broker();
    broker.PlaceOrder(buyCommand);
    broker.PlaceOrder(sellCommand);

    broker.ProcessOrders(); 

  }
}
