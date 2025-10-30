using Game.Players;
using Game.Struct;

namespace Game.NPC.Angry;

public sealed class Bandit : AngryNpc
{
    public Bandit()
    {
        Name = "Bandit";
        Distance = 2;
    }


    public override void Attach(Archer player, int distance)
    {
        if (distance > Distance) return;
        var damage = GenerateDamage();
        player.GetDamage(this, damage);
    }

    public override Meat[] LootIt()
    {
        if (Health != 0)
        {
            throw new MethodAccessException("Метод может быть вызван для волка с 0 здоровьем");
        }
        
        
        for (var i = 0; i < MeatStach.Length; i++)
        {
            MeatStach[i] = new Meat(Random.Shared.NextDouble()
                                    * Random.Shared.Next(30, 60), Random.Shared.Next(10, 20));
        }

        return MeatStach;
    }


    protected override double GenerateDamage()
    {
        return Random.Shared.Next(13, 20);
    }
}