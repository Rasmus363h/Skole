namespace RPGspil;

class Program
{
    static void Main(string[] args)
    {
        Player player = new Player();
        Goblin goblin = new Goblin();
        bool running = true;
        
        while (running)
        {
            Console.Clear();
            Console.WriteLine("1. Kæmp mod en Goblin");
            Console.WriteLine("2. Gå i Shop");
            Console.WriteLine("3. Vis spiller stats");
            Console.WriteLine("4. Gem spil");
            Console.WriteLine("5. Indlæs spil");
            Console.WriteLine("6. Afslut");
            Console.Write("\nVælg handling: ");
            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    Fight(player, goblin);
                    break;
                case "2":
                    Shop(player);
                    break;
                case "3":
                    player.ShowStats();
                    Console.ReadKey();
                    break;
                case "4":
                    SaveGame(player);
                    break;
                case "5":
                    player = LoadGame();
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Ugyldigt valg!");
                    break;
            }
        }
    }   
    
    // 🥊 Kamp mellem spiller og goblin
    static void Fight(Player player, Goblin goblin)
    {
        goblin.Reset();
        Console.Clear();
        Console.WriteLine("En ond goblin angriber dig!");
        

        while (player.Lives > 0 && goblin.Liv > 0)
        {
            Console.Clear();
            Console.WriteLine($" Spiller: {player.Lives}/{player.MaxLiv} HP |  {player.Energi} energi");
            Console.WriteLine($" Goblin: {goblin.Liv}/{goblin.MaxLiv} HP |  {goblin.Energi} energi");
            Console.WriteLine("\n1. Light attack\n2. Medium attack\n3. Heavy attack\n4. Brug potion\n5. Flygt");
            Console.Write("\nVælg: ");
            string input = Console.ReadLine();

            // Flygt fra kampen
            if (input == "5") return; 

            //spilleren
            (int dmg, bool crit) = input switch
            {
                "1" => player.Attack("light"),
                "2" => player.Attack("medium"),
                "3" => player.Attack("heavy"),
                "4" => HandlePotionUse(player),
                _ => (0, false)
            };

            if (dmg > 0)
            {
                goblin.Liv -= dmg;
                Console.WriteLine($"Du slog goblinen for {dmg} skade {(crit ? "(CRIT!)" : "")}");
            }

            if (goblin.Liv <= 0)
            {
                Console.WriteLine("Du besejrede goblinen!");
                player.Reward(50, 25); // XP + guld
                Console.ReadKey();
                return;
            }

            //Goblinens tur
            var goblinAttack = goblin.RandomAttack();
            if (goblinAttack.damage > 0)
            {
                player.Lives -= goblinAttack.damage;
                Console.WriteLine($"Goblinen angriber dig for {goblinAttack.damage} skade {(goblinAttack.crit ? "(CRIT!)" : "")}");
            }
            else
            {
                Console.WriteLine("Goblinen genvinder energi");
            }

            if (player.Lives <= 0)
            {
                Console.WriteLine("Du er død");
                player.Lives = player.MaxLiv;
                player.Gold = Math.Max(0, player.Gold - 10); // straf
                Console.ReadKey();
                return;
            }
        }
    }

    // 🍷 Brug potion i kamp
    static (int, bool) HandlePotionUse(Player player)
    {
        Console.WriteLine("\n1. Health potion\n2. Energy potion");
        string pChoice = Console.ReadLine();

        if (pChoice == "1") player.UseHealthPotion();
        else if (pChoice == "2") player.UseEnergyPotion();

        Thread.Sleep(800);
        return (0, false);
    }

    // 🛒 Shop
    
    static void Shop(Player player)
    {
        bool inShop = true;
        while (inShop)
        {
            Console.Clear();
            Console.WriteLine("=== SHOP ===");
            Console.WriteLine($"Guld: {player.Gold}");
            Console.WriteLine("1. Køb Health Potion (10 guld)");
            Console.WriteLine("2. Køb Energy Potion (8 guld)");
            Console.WriteLine("3. Tilbage");
            Console.Write("\nVælg: ");
            string shopChoice = Console.ReadLine();

            switch (shopChoice)
            {
                case "1":
                    if (player.Gold >= 10)
                    {
                        player.Gold -= 10;
                        player.HealthPotions++;
                        Console.WriteLine("Du købte en Health Potion!");
                    }
                    else Console.WriteLine("Ikke nok guld!");
                    break;
                case "2":
                    if (player.Gold >= 8)
                    {
                        player.Gold -= 8;
                        player.EnergyPotion++;
                        Console.WriteLine("Du købte en Energy Potion!");
                    }
                    else Console.WriteLine("Ikke nok guld!");
                    break;
                case "3":
                    inShop = false;
                    break;
            }
            Thread.Sleep(800);
        }
    }

    static void SaveGame(Player player)
    {
        string savePath = Path.Combine(AppContext.BaseDirectory, "save.txt");
        using (StreamWriter sw = new StreamWriter(savePath))
        {
            sw.WriteLine(player.Lives);
            sw.WriteLine(player.MaxLiv);
            sw.WriteLine(player.Energi);
            sw.WriteLine(player.XP);
            sw.WriteLine(player.Level);
            sw.WriteLine(player.Gold);
            sw.WriteLine(player.HealthPotions);
            sw.WriteLine(player.EnergyPotion);
        }

        Console.WriteLine("Spil gemt i 'save.txt'!");
        Thread.Sleep(800);
    }

    // 📂 Indlæs spillet med StreamReader
    static Player LoadGame()
    {
        if (!File.Exists("save.txt"))
        {
            Console.WriteLine("Ingen gemt fil fundet!");
            Thread.Sleep(800);
            return new Player();
        }

        Player player = new Player();

        using (StreamReader sr = new StreamReader("save.txt"))
        {
            player.Lives = int.Parse(sr.ReadLine());
            player.MaxLiv = int.Parse(sr.ReadLine());
            player.Energi = int.Parse(sr.ReadLine());
            player.XP = int.Parse(sr.ReadLine());
            player.Level = int.Parse(sr.ReadLine());
            player.Gold = int.Parse(sr.ReadLine());
            player.HealthPotions = int.Parse(sr.ReadLine());
            player.EnergyPotion = int.Parse(sr.ReadLine());
        }

        Console.WriteLine("Spil indlæst!");
        Thread.Sleep(800);
        return player;
    }
    
}