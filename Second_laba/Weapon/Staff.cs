namespace Second_laba.Weapon;

public class Staff(string name, int cost, int baseDamage, double specialChance)
    : IWeapon
{
    private readonly int _baseDamage = baseDamage;
    public string Name { get; } = name;
    public int Cost { get; } = cost;
    public int Damage { get; } = baseDamage;

    public double GenerateDamage()
    {
        if (Random.Shared.NextDouble() < specialChance)
        {
            return _baseDamage + Random.Shared.Next(10, 40);
        }

        return _baseDamage * Random.Shared.NextDouble() * 0.9 + _baseDamage;
    }
}