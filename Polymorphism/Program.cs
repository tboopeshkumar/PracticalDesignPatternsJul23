
interface IFlyingObject {
    void Fly();
}

class Superman : IFlyingObject 
{
    public void Fly() 
    {
        System.Console.WriteLine("Up, up and away");
    }
}

class Plane : IFlyingObject
{
    public void Fly()
    {
        System.Console.WriteLine("Take off");
    }
}

class Mosquito : IFlyingObject
{
    public void Fly()
    {
        System.Console.WriteLine("Zzzzzz");
    }
}

class Program
{

    public static void Main(string[] args)
    {
        List<IFlyingObject> flyingObjects = new()
        {
                new Superman(),
                new Plane(),
                new Mosquito()
        };

        flyingObjects.ForEach(f => f.Fly());
    }
}