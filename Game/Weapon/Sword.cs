namespace Game.Weapon;

public class Sword(string name, int cost, int baseDamage) : IWeapon
{
    private readonly int _baseDamage = baseDamage;
    public string Name { get; } = name;
    public int Cost { get; } = cost;
    public int Damage { get; } = baseDamage;

    public double GenerateDamage()
    {
        return _baseDamage * Random.Shared.NextDouble() * 0.9 + _baseDamage;
    }
}