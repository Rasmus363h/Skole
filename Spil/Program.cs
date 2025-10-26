using System.Data;

namespace Spil;

class Program
{
    //skaber både en player og et monster
    static Player Player = new Player();
    static Goblin Goblin = new Goblin();

    static int block = 0;
    
    static void Main(string[] args)
    {
        //titel skærm for spillet
        string valgPåStartSkaermen = null;
        while (valgPåStartSkaermen != "1" /*&& valgPåStartSkaermen != "2"*/)
        {
            Console.WriteLine("Skriv 1 for at starte spillet:");
            //Console.WriteLine("Skriv 2 for at loade en profil");
            valgPåStartSkaermen = Console.ReadLine();
            Console.Clear();
        }
        
        runde();

    }
    static void runde()
    {
        string valg = null;
        while (valg != "light" && valg != "medium" && valg != "heavy" && valg != "block" && valg != "rest" && valg != "heal")
        {
            
            //hud for spilleren til at se hvor meget liv og energi både du og modstanderen har
            Console.WriteLine(@"Dit liv: " + Player.Liv);
            Console.WriteLine("Dit energi: " + Player.Energi);
            Console.WriteLine();
            Console.WriteLine("Modstanderens liv: " + Goblin.Liv);
            Console.WriteLine("Modstanderens energi: " + Goblin.Energi);
            Console.WriteLine();

            //muligheder for hvilke angreb du kan bruge
            Console.WriteLine("light | medium | heavy | block | rest | heal");
            valg = Console.ReadLine();
            Console.Clear();
        }
        udregningAfSkade(valg);
    }

    static void udregningAfSkade(string angreb)
    {
        int damage = 0;
        bool crit;
        switch (angreb)
        {
            case "light":
            {
                (damage, crit) = Player.light();
                break;
            }
            case "medium":
            {
                (damage, crit) = Player.light();
                break;
            }
            case "heavy":
            {
                (damage, crit) = Player.light();
                break;
            }
            case "block":
            {
                block = Player.block();
                break;
            }
            case "rest":
            {
                
                break;
            }
            case "heal":
            {
                
                break;
            }
                Goblin.Liv -= damage;
        }
    }

}