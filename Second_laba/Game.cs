using Second_laba.Logger;
using Second_laba.NPC;
using Second_laba.NPC.Angry;
using Second_laba.NPC.Friend;
using Second_laba.Players;

namespace Second_laba;

public class Game
{
    private readonly AllLogers _logs = new ([new LoggerConsole(Console.WriteLine)
        , new LoggerFile("log.txt")]); 
    
    //Генерируется волки и возвращается указатель на список из волков
    private Npc[] GenerateNpc()
    {
        var npc = new Npc[Random.Shared.Next(2, 4)];
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

            if (npc is FriednlyNpc friednly)
            {
                hero.Loot(friednly);
                continue;
            }
            
            //Вывод магазина на экран
            _logs.Log("You wanna buy some Weapon or Itmes?(Y/N)");
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.Y)
            {
                _logs.Log(market.ToString());
                _logs.Log("Input number items, would like to buy");
                var keyNumber = Convert.ToInt32(Console.ReadKey());
                var newWeapon = market.BuyWeapon(keyNumber, hero.GooldPlayer());
                hero.AddNewWeaponToInventory(newWeapon);
            }
            
            var angnpc = (AngryNpc)npc;
            while (!hero.IsDeath() && !angnpc.IsDead())
            {
                Fighting(angnpc, hero);
            }

            if (!hero.IsDeath()) continue;
            
            _logs.Log($"{hero.Name} is Dead");
            break;
        }
        
        
    }
}