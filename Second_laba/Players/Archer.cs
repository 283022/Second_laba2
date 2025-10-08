using Second_laba.NPC.Angry;
using Second_laba.NPC.Friend;

namespace Second_laba.Players;

public sealed class Archer(string name)
{
    private double _level = 1;
    private double _health = 100.0;
    private int _expirience = 0;
    public string Name { get; private set; } = name;
    public double HealthPoints => _health;

    private double GenerateDamage()
    {
        return _level * Random.Shared.Next(10, 25);
    }

    private void GetExperience(int exp)
    {
        _expirience += exp;
        LevelUp();
    }

    private void LevelUp()
    {
        for (var i = 0; i < _expirience % 30; i++)
        {
            _level += 0.2;
        }
    }

    public void GetDamage(AngryNpc npc, double damage)
    {
        _health = double.Max(0, _health - damage);
    }

    public void Attach(AngryNpc npc)
    {
        var damage = GenerateDamage();
        npc.GetDamage(this, damage);
    }

    public void Loot(AngryNpc npc)
    {
        var loots = npc.LootIt();
        foreach (var loot in loots)
        {
            _health += double.Min(loot.FoodValue + _health, 100);
            GetExperience(loot.ExpValues);
        }
    }

    public void Loot(FriednlyNpc npc)
    {
        _health += double.Min(npc.HealthFor + _health, 100);
        GetExperience(npc.ExpFor);
    }

    public bool IsDeath()
    {
        return _health <= 0;
    }
}