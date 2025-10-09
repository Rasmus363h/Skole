using System.Data;

namespace RPGSpil;

class Program
{
    static void Main(string[] args)
    {
        //skaber både en player og et monster
        Player Player = new Player();
        Goblin Goblin = new Goblin();
        
        //titel skærm for spillet
        string valgPåStartSkaermen = null;
        while (valgPåStartSkaermen != "1")
        {
            Console.WriteLine("Skriv 1 for at starte spillet:");
            valgPåStartSkaermen = Console.ReadLine();
            Console.Clear();
        }

        //hud for spilleren til at se hvor meget liv og energi både du og modstanderen har
        Console.WriteLine("Dit liv: " + Player.Liv);
        Console.WriteLine("Dit energi: " + Player.Energi);
        Console.WriteLine();
        Console.WriteLine("Modstanderens liv: " + Goblin.Liv);
        Console.WriteLine("Modstanderens energi: " + Goblin.Energi);
        Console.WriteLine();
        
        //muligheder for hvilke angreb du kan bruge
        Console.WriteLine("");
    }
}