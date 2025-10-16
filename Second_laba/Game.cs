using Second_laba.Logger;
using Second_laba.Logger.Interfaces;
using Second_laba.NPC;
using Second_laba.NPC.Angry;
using Second_laba.NPC.Friend;
using Second_laba.Players;

namespace Second_laba;

public class Game
{
    
    private readonly ILoggerWriter[] _log = new ILoggerWriter[]{new LoggerConsole(),new LoggerFile("log.txt")};

    private void Log(string message)
    {
        foreach (var forLoggerIn in _log)
            
        {
            forLoggerIn.Log(message);
        }
    }
    
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
        Log($"Hp hero is {hero.HealthPoints:F2} ");
        Log($"Hp {npc.Name} is {npc.HealthPoints:F2} ");

        Log($"{hero.Name} attach {npc.Name}");
        hero.Attach(npc);

        if (npc.IsDead())
        {
            Log($"{npc.Name} is Dead");
            hero.Loot(npc);
        }
        else
        {
            Log($"{npc.Name} attach {hero.Name}");
            npc.Attach(hero);
        }
    }

    public void Run_Game()
    {
        Log("");
        Log("Starting game");
        var hero = new Archer("hero");
        var npcs = GenerateNpc();
        Log($"NPC in this round =  {npcs.Length}");
        foreach (var npc in npcs)
        {
            Log(npc.Name);

            if (npc is FriednlyNpc friednly)
            {
                hero.Loot(friednly);
                continue;
            }

            var angnpc = (AngryNpc)npc;
            while (!hero.IsDeath() && !angnpc.IsDead())
            {
                Fighting(angnpc, hero);
            }

            if (!hero.IsDeath()) continue;
            
            Log($"{hero.Name} is Dead");
            break;
        }
        
        
    }
}