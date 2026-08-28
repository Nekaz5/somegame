using System.Collections.Specialized;
using System;

public class GameStats
{
    public int Hp { get; set; }
    public int Energy { get; set; }
    public int gold { get; set; }
    public GameStats(int hp, int energy, int gold)
    {
        Hp = hp;
        Energy = energy;
        this.gold = gold;
    }
} 
public class Oldnew
{
    public static GameStats Tripped(GameStats player)
    {
        Console.WriteLine("You tripped and lost 1 HP!");
        player.Hp -= 1;
        return player;
    }
    public static GameStats FoundGold(GameStats player)
    {
        Console.WriteLine("You found 10 gold!");
        player.gold += 10;
        return player;
    }
    public static GameStats FoundApple(GameStats player)
    {
        Console.WriteLine("You found an apple and gained 5 energy!");
        player.Energy += 5;
        return player;
    }
    public static GameStats FoundNothing(GameStats player)
    {
        Console.WriteLine("You found nothing.");
        return player;
    }
    public static GameStats FoundCabin(GameStats player)
    {
        string input = "";
        Console.WriteLine("You found a cabin go in [Y/N]");
        input = Console.ReadLine() ?? string.Empty;
        if (input == "y" || input == "Y")
        {
            Console.WriteLine("You found a cabin there is a bed will you sleep [Y/N]");
            input = Console.ReadLine() ?? string.Empty;
            if (input == "y" || input == "Y")
            {
                Random rand = new Random();
                int sleep = rand.Next(1, 3);
                if (sleep == 1)
                {
                    Console.WriteLine("You slept well and gained 3 HP!");
                    player.Hp += 3;
                }
                else
                {
                    Console.WriteLine("You slept there was bed bug and lost 2 HP and 3 energy!");
                    player.Hp -= 2;
                    player.Energy -= 3;
                }
            }
        }
        else
        {
            Console.WriteLine("you passed on the cabin");
        }
        return player;
    }
    public static void game()
    {
        GameStats Player = new GameStats(10, 100, 0);
        for (int hours = 0; hours < 10; hours++)
        {
            string input = Console.ReadLine() ?? string.Empty;
            if (Player.Hp <= 0)
            {
                Console.WriteLine("You have died!");
                break;
            }
            if (Player.Energy <= 0)
            {
                Console.WriteLine("You have run out of energy!");
                Player.Hp -= 1;
                break;
            }
            if (Player.Energy > 100)
            {
                Player.Energy = 100;
            }
            if (Player.Hp > 10)
            {
                Player.Hp = 10;
            }
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"Hour: {hours + 1}");
            Console.WriteLine($"Player HP: {Player.Hp}," + $" Player Energy: {Player.Energy}," + $" Player Gold: {Player.gold}");
            Random rand = new Random();
            int action = rand.Next(1, 6);
            switch (action)
            {
                case 1:
                    Tripped(Player);
                    break;
                case 2:
                    FoundGold(Player);
                    break;
                case 3:
                    FoundApple(Player);
                    break;
                case 4:
                    FoundNothing(Player);
                    break;
                case 5:
                    FoundCabin(Player);
                    break;
            }
        }
    }
    public static void Main(string[] args)
    {
        game();
    }
}