namespace RPGspil;

public class Player
{
    public int Lives { get; set; } = 25;
    public int MaxLiv { get; set; } = 25;
    public int Energi { get; set; } = 12;
    public int XP { get; set; } = 0;
    public int Level { get; set; } = 1;
    public int Gold { get; set; } = 0;
    public int HealthPotions { get; set; } = 0;
    public int EnergyPotion { get; set; } = 0;
    
    private static Random rnd = new Random();

    public (int damage, bool crit) Attack(string type)
    {
        int damage = 0;
        
        switch (type.ToLower())
        {
            case "light":
                damage = rnd.Next(1, 3); 
                Energi -= 1;
                break;
            case "medium":
                damage = rnd.Next(2, 4); 
                Energi -= 2;
                break;
            case "heavy":
                damage = rnd.Next(3, 5); 
                Energi -= 3;
                break;
            default:
                Console.WriteLine("Ugyldig angrebstype!");
                break;
        }
       
        bool Crit = crit();
        if (Crit == true)
        {
            damage = (int)Math.Round(damage * 1.5);
        }

        return (damage, Crit);
    }

    public bool crit()
    {
        //tager et tal mellem 1 og 4 og hvis tallet er 1 vil den retunere true hvis ikke giver den false
        int Crit = rnd.Next(1, 5);
        if (Crit == 1)
        {
            return true;
        }

        return false;
    }
    public void UseHealthPotion()
    {
        if (HealthPotions > 0)
        {
            int heal = 10;
            Lives = Math.Min(MaxLiv, Lives + heal);
            HealthPotions--;
            Console.WriteLine($"Du brugte en health potion og fik {heal} liv tilbage!");
        }
        else
        {
            Console.WriteLine("Du har ingen health potions!");
        }
    }
    public void UseEnergyPotion()
    {
        if (EnergyPotion > 0)
        {
            int restore = 5;
            Energi += restore;
            EnergyPotion--;
            Console.WriteLine($"Du brugte en energy potion og fik {restore} energi!");
        }
        else
        {
            Console.WriteLine("Du har ingen energy potions!");
        }
    }
    public void AddXP(int amount)
    {
        XP += amount;
        int nextLevelXP = Level * 100;

        if (XP >= nextLevelXP)
        {
            Level++;
            XP -= nextLevelXP;
            MaxLiv += 5;
            Energi += 2;
            Lives = MaxLiv;
            Console.WriteLine($"🎉 Du steg i level! Ny level: {Level}");
        }
    }
    public void Reward(int xp, int gold)
    {
        AddXP(xp);
        Gold += gold;
        Console.WriteLine($"Du fik {xp} XP og {gold} guld!");
    }
    public void ShowStats()
    {
        Console.WriteLine("Stats");
        Console.WriteLine($"Level: {Level}  XP: {XP}");
        Console.WriteLine($"Liv: {Lives}/{MaxLiv}");
        Console.WriteLine($"Energi: {Energi}");
        Console.WriteLine($"Guld: {Gold}");
        Console.WriteLine($"Health Potions: {HealthPotions}");
        Console.WriteLine($"Energy Potions: {EnergyPotion}");
        Console.WriteLine("");
    }
}