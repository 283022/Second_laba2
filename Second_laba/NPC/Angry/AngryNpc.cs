using Second_laba.Players;
using Second_laba.Struct;

namespace Second_laba.NPC.Angry;

public abstract class AngryNpc : Npc
{
    protected double Health = 100;
    public int Level { get; protected set; } = 1;
    public double HealthPoints => Health;
    protected readonly Meat[] MeatStach = new Meat[Random.Shared.Next(1, 10)];

    public abstract Meat[] LootIt();

    protected abstract double GenerateDamage();

    public virtual void Attach(Archer player)
    {
        double damage = Random.Shared.Next(15, 35);
        player.GetDamage(this, damage);
    }

    public virtual void GetDamage(Archer player, double damage)
    {
        Health = double.Max(0, Health - damage);
    }

    public bool IsDead()
    {
        return Health <= 0;
    }
}