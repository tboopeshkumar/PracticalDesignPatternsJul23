

class Computer
{
    public virtual void Print() 
    {

    }
}

class PC : Computer
{
    public override void Print()
    {
        System.Console.WriteLine("I am a PC");
    }
}

class Laptop : Computer
{
    public override void Print()
    {
        System.Console.WriteLine("I am a Laptop");
    }
}

class ComputerFactory
{
    public Computer create(string type)
    {
        var computer = (Computer)Activator.CreateInstance(null, type).Unwrap();
        return computer;
    }
}

class Program
{
    public static void Main(string[] args)
    {
        var cf = new ComputerFactory().create("PC");
        cf.Print();
    }
}