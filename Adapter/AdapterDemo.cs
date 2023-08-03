
interface Communication
{
  void SendMessage(String message);
}

class Email : Communication
{
  String recipient;

  public Email(String recipient)
  {
    this.recipient = recipient;
  }

  public void SendMessage(String Message)
  {
    Console.WriteLine($"Email sent to {recipient}");
  }
}

class SMS : Communication
{
  String recipient;

  public SMS(String recipient)
  {
    this.recipient = recipient;
  }

  public void SendMessage(String Message)
  {
    Console.WriteLine($"SMS sent to {recipient}");
  }
}

class WhatsAppAdapter : Communication {
    private WhatsApp app;

    public WhatsAppAdapter(WhatsApp app) {
    this.app = app;
  }

  public void SendMessage(string Message) {
        app.SubmitMessage(Message);
    }

}

class Subscriber
{

  String firstName;
  String lastName;
  List<Communication> notifier = new List<Communication>();

  public Subscriber(String firstName, String lastName)
  {
    this.firstName = firstName;
    this.lastName = lastName;
  }

  public void AddNotifier(Communication comm)
  {
    notifier.Add(comm);
  }

  public void NotifySubscriber(String message)
  {
    foreach (var comm in notifier)
      comm.SendMessage(firstName);
  }
}

public class AdapterDemo
{

  public static void Main()
  {
    var list = new List<Subscriber>();
    var bill = new Subscriber("Bill", "Gates");
    bill.AddNotifier(new Email("billg@microsoft.com"));
    list.Add(bill);

    var elon = new Subscriber("Elon", "Musk");
    elon.AddNotifier(new SMS("1-CALL-ELONMUSK"));
    elon.AddNotifier(new WhatsAppAdapter(new WhatsApp("1-WHATSAPP-ELONMUSK")));
    list.Add(elon);
    foreach (var person in list)
      person.NotifySubscriber("Bill due in 3 days");
  }
}
