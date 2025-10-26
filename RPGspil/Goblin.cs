namespace RPGspil;

public class Goblin
{
    
    public int Liv { get; set; } = 20;
    public int MaxLiv { get; set; } = 20;
    public int Energi { get; set; } = 10;

    private static Random rnd = new Random();

    
    public (int damage, bool crit) Light()
    {
        int attack = rnd.Next(1, 3); 
        bool isCrit = Crit();
        if (isCrit)
            attack = (int)Math.Round(attack * 1.5);

        Energi = Math.Max(0, Energi - 1);
        return (attack, isCrit);
    }
    
    public (int damage, bool crit) Medium()
    {
        int attack = rnd.Next(2, 4); 
        bool isCrit = Crit();
        if (isCrit)
            attack = (int)Math.Round(attack * 1.5);

        Energi = Math.Max(0, Energi - 2);
        return (attack, isCrit);
    }
    
    public (int damage, bool crit) Heavy()
    {
        int attack = rnd.Next(3, 5); 
        bool isCrit = Crit();
        if (isCrit)
            attack = (int)Math.Round(attack * 1.5);

        Energi = Math.Max(0, Energi - 3);
        return (attack, isCrit);
    }
    
    public int Block()
    {
        int blocked = rnd.Next(1, 3); 
        return blocked;
    }
    
    public bool Crit()
    {
        int chance = rnd.Next(1, 5); 
        return chance == 1;
    }
    
    public (int damage, bool crit) RandomAttack()
    {
        if (Energi <= 0)
        {
            Energi = 10; 
            Console.WriteLine("Goblin får energi tilbage!");
            return (0, false);
        }
        int choice = rnd.Next(1, 4); 
        return choice switch
        {
            1 => Light(),
            2 => Medium(),
            _ => Heavy(),
        };
    }
    
    public void Reset()
    {
        Liv = MaxLiv;
        Energi = 10;
    }
}