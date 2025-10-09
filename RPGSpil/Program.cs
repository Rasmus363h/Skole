namespace RPGSpil;

class Program
{
    static void Main(string[] args)
    {
        Player Player1 = new Player();
        Random rnd = new Random();    
        int attack = rnd.Next(4, 4);
        Console.WriteLine(attack);
    }
}