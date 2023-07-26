namespace ClassesVsInterfaces
{

    interface IDeveloper
    {
        void WriteCode();
    }

    interface IMusician
    {
        void PlayMusic();
    }

    class Human
    {
        public void Sleep()
        {
            Console.WriteLine("Zzzzzzzz......");
        }

        public void Eat()
        {
            Console.WriteLine("Chomp! Chomp!");
        }

        public void Love()
        {
            Console.WriteLine("Sing songs");
        }
    }

    class Branden : Human, IDeveloper
    {
        public void WriteCode()
        {
            Console.WriteLine("printf(\"Hello world\")");
        }
    }

    class Sanjay : Human, IDeveloper, IMusician
    {
        public void PlayMusic()
        {
            Console.WriteLine("~~~~~ ```````` ##### ##");
        }

        public void WriteCode()
        {
            Console.WriteLine("System.out.println(\"Hello world\")");
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            var eich = new Branden();

            eich.Eat();
            eich.Sleep();
            eich.Love();
            eich.WriteCode();

            Console.WriteLine("\n");

            var vyas = new Sanjay();

            IDeveloper dev = eich;
            dev.WriteCode();

            Console.WriteLine("\n");

            dev = vyas;
            dev.WriteCode();

            Console.WriteLine("\n");

            List<IDeveloper> team = new List<IDeveloper>();
            team.Add(eich);
            team.Add(vyas);

            team.ForEach(e => e.WriteCode()); 

            Console.WriteLine("\n");

            List<IMusician> orchestra = new List<IMusician>();  
            orchestra.Add(vyas);
            orchestra.ForEach(e => e.PlayMusic());

        }
    }
}

