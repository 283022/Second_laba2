using Game.Players;
using Game.Struct;

namespace Game.NPC.Angry;

public sealed class Wolf : AngryNpc
{
    

    public Wolf()
    {
        Name = "Wolf";
        Distance = 0;
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
                                    * Random.Shared.Next(5, 20), Random.Shared.Next(15, 20));
        }

        return MeatStach;
    }

    public override void Attach(Archer player, int distance)
    {
        if (distance > Distance) return;

        var damage = GenerateDamage();
        player.GetDamage(this, damage);
    }

    protected override double GenerateDamage()
    {
        return Random.Shared.Next(10, 15);
    }
}