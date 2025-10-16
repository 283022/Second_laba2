using Second_laba.Logger;
using Second_laba.NPC;
using Second_laba.NPC.Angry;
using Second_laba.NPC.Friend;
using Second_laba.Players;

namespace Second_laba;

public class Game
{
    private readonly AllLogers _logs = new AllLogers(); 
    
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
        _logs.Log($"NPC in this round =  {npcs.Length}");
        foreach (var npc in npcs)
        {
            _logs.Log(npc.Name);

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
            
            _logs.Log($"{hero.Name} is Dead");
            break;
        }
        
        
    }
}