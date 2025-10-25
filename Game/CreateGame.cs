using Game.Logger;
using Game.NPC;
using Game.NPC.Angry;
using Game.NPC.Friend;
using Game.Players;

namespace Game;

public class CreateGame
{
    private readonly AllLogers _logs = new([new LoggerConsole(Console.WriteLine), new LoggerFile("log.txt")]);

    //Генерируется волки и возвращается указатель на список из волков
    private Npc[] GenerateNpc()
    {
        var npc = new Npc[Random.Shared.Next(4, 7)];
        for (var i = 0; i < npc.Length; i++)
        {
            var type = Random.Shared.Next(1, 6);
            npc[i] = type switch
            {
                1 => new Wolf(),
                2 => new Villager(),
                3 => new Bandit(),
                4 => new Wolf(),
                5 => new Bandit(),
                6 => new Wolf(),
                _ => npc[i]
            };
        }

        return npc;
    }

    private void PrintMarket(Archer hero, Market market)
    {
        _logs.Log("You wanna buy some Weapon or Items?(Y/N)");
        var key = Console.ReadLine()?.ToLower();
        if (key != "y") return;

        _logs.Log("");
        _logs.Log(market.ToString());
        _logs.Log("your gold is " + hero.GoldPlayer());

        _logs.Log("Input number items, would like to buy(Enter to Exit)");
        var keyNumber = Console.ReadLine();
        if (string.IsNullOrEmpty(keyNumber)) return;

        _logs.LogWithOutConsole(keyNumber);
        var newWeapon = market.BuyWeapon(Convert.ToInt32(keyNumber), hero);
        _logs.Log(newWeapon ? $"Bought was accepted" : $"Bought not accepted");
    }

    private void PrintInventoryHero(Archer hero)
    {
        _logs.Log("You wanna chose your weapon(Y/N)");
        var key = Console.ReadLine()?.ToLower();
        if (key != "y") return;
        _logs.Log(hero.PrintPlayerInventory());
        _logs.LogWithOutConsole(key);

        _logs.Log("Input number weapon, would like to chose(Enter to Exit)");
        key = Console.ReadLine();
        if (string.IsNullOrEmpty(key)) return;
        _logs.LogWithOutConsole(key);
        _logs.Log(hero.GetCurrentWeapon(Convert.ToInt32(key))
            ? "The weapon was choose"
            : "The weapon was not choose");
    }

    //боевка между агрессивным нпс и героем
    private void Fighting(AngryNpc npc, Archer hero)
    {
        _logs.Log($"Hp hero is {hero.HealthPoints:F2} ");
        _logs.Log($"Hp {npc.Name} is {npc.HealthPoints:F2} ");

        _logs.Log($"{hero.Name} attach {npc.Name}");
        hero.Attach(npc);

        if (npc.IsDead())
        {
            _logs.Log($"{npc.Name} is Dead");
            hero.Loot(npc);
        }
        else
        {
            _logs.Log($"{npc.Name} attach {hero.Name}");
            npc.Attach(hero);
        }
    }

    public void Run_Game()
    {
        _logs.Log("");
        _logs.Log("Starting game");
        var hero = new Archer("hero");
        var npcs = GenerateNpc();
        var market = new Market();
        _logs.Log($"NPC in this round =  {npcs.Length}");

        foreach (var npc in npcs)
        {
            _logs.Log(npc.Name);

            if (npc is FriednlyNpc friendly)
            {
                hero.Loot(friendly);
                continue;
            }

            PrintMarket(hero, market);
            PrintInventoryHero(hero);

            var angrynpc = (AngryNpc)npc;
            while (!hero.IsDeath() && !angrynpc.IsDead())
            {
                Fighting(angrynpc, hero);
            }

            if (hero.IsDeath()) break;
        }

        _logs.Log(hero.IsDeath() ? $"{hero.Name} is Dead" : $"{hero.Name} is Win");
    }
}