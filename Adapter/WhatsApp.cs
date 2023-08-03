public class WhatsApp {
  String receiver;

  public WhatsApp(String receiver) {
    this.receiver = receiver;
  }

  public void SubmitMessage(String message) {
    Console.WriteLine("This message " + message + " has been sent");
  }
}
