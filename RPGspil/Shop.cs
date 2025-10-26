namespace RPGspil;

public class Shop
{
    public static void OpenShop(Player player)
    {
        bool shopping = true;

        while (shopping)
        {
            Console.Clear();
            Console.WriteLine("Shop");
            Console.WriteLine($"Dit guld: {player.Gold}\n");
            Console.WriteLine("1. Health Potion (+10 liv) - 10 guld");
            Console.WriteLine("2. Energy Potion (+5 energi) - 8 guld");
            Console.WriteLine("3. Opgrader Max Liv (+5 liv) - 30 guld");
            Console.WriteLine("4. Opgrader Energi (+3 energi) - 25 guld");
            Console.WriteLine("5. Tilbage til hovedmenuen");
            Console.Write("\nVælg et nummer: ");
            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    BuyHealthPotion(player);
                    break;
                case "2":
                    BuyEnergyPotion(player);
                    break;
                case "3":
                    UpgradeHealth(player);
                    break;
                case "4":
                    UpgradeEnergy(player);
                    break;
                case "5":
                    shopping = false;
                    break;
                default:
                    Console.WriteLine("Ugyldigt valg!");
                    break;
            }
        }
    }

    private static void BuyHealthPotion(Player player)
    {
        int price = 10;
        if (player.Gold >= price)
        {
            player.Gold -= price;
            player.HealthPotions++;
            Console.WriteLine("Du købte en Health Potion!");
        }
        else
        {
            Console.WriteLine("Du har ikke nok guld!");
        }
    }

    private static void BuyEnergyPotion(Player player)
    {
        int price = 8;
        if (player.Gold >= price)
        {
            player.Gold -= price;
            player.EnergyPotion++;
            Console.WriteLine("Du købte en Energy Potion!");
        }
        else
        {
            Console.WriteLine("Du har ikke nok guld!");
        }
    }

    private static void UpgradeHealth(Player player)
    {
        int price = 30;
        if (player.Gold >= price)
        {
            player.Gold -= price;
            player.MaxLiv += 5;
            player.Lives = player.MaxLiv;
            Console.WriteLine("Du har nu +5 mere maks HP");
        }
        else
        {
            Console.WriteLine("Du har ikke nok guld!");
        }
    }

    private static void UpgradeEnergy(Player player)
    {
        int price = 25;
        if (player.Gold >= price)
        {
            player.Gold -= price;
            player.Energi += 3;
            Console.WriteLine("Du har nu +3 mere max energi");
        }
        else
        {
            Console.WriteLine("Du har ikke nok guld!");
        }
    }
}