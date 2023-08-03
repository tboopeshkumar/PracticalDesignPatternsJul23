class Location
{
    private static int locationSequence = 1;
    private int sequence = 0;
    private string city;

    public void MoveTo(string city)
    {
        this.city = city;
        this.sequence = Location.locationSequence++;
    }

    public void print()
    {
        System.Console.WriteLine($"{sequence}: {city}");
    }

    public Momento GetMomento(){
        var momento = new Momento();
        momento.State.Add(city);
        momento.State.Add(sequence);
        return momento;
    }

    public void SetMomento(Momento momento) {
        this.city = momento.State[0] as string;
        this.sequence = (int)momento.State[1];
    }


}


class Momento {

    public List<object> State = new List<object>();
    public Momento() { }
}


public class MementoDemo
{
    public static void Main(string[] args)
    {
        var history = new System.Collections.Generic.Stack<Momento>();
        var location = new Location();
        location.MoveTo("Kolkata");
        history.Push(location.GetMomento());
        location.print();
        location.MoveTo("Indore");
        location.print();
        location.MoveTo("Mumbai");
        location.print();
        location.SetMomento(history.Pop());
        location.print();
    }
}