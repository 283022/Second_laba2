using Game.Players;
using Game.Struct;

namespace Game.NPC.Angry;

public abstract class AngryNpc : Npc
{
    protected double Health = 100;
    public int Level { get; protected set; } = 1;
    public double HealthPoints => Health;
    protected readonly Meat[] MeatStach = new Meat[Random.Shared.Next(1, 10)];
    public int Distance { get; protected set; }
    //в 4 лабе координаты
    public (double x, double y) CurrentCoordinates { get; set; } = (Random.Shared.Next(0,60), Random.Shared.Next(0,60));
    public abstract Meat[] LootIt();

    protected abstract double GenerateDamage();

    public virtual void Attach(Archer player, int distance)
    {
        if (distance > Distance) return;
        double damage = Random.Shared.Next(15, 35);
        player.GetDamage(this, damage);
    }

    public virtual void GetDamage(Archer player, double damage)
    {
        Health = double.Max(0, Health - damage);
    }

    //в 4 лабе distance
    public static int AggressionArea(AngryNpc npc, double playerX, double playerY)
    {
        var distance = npc.GetDistance(playerX, playerY);

        return distance switch
        {
            > 40 => 0,
            > 10 and <=40 => 1,
            < 10 and >=0 => 2,
            < 0.0 => throw new ArgumentOutOfRangeException("distance isn't negative"),
            _ => throw new ArgumentOutOfRangeException("distance can't be calculate")
        };
        
    }

    public bool IsDead()
    {
        return Health <= 0;
    }
}