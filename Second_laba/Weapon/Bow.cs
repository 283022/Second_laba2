namespace Second_laba.Weapon;

public class Bow : IWeapon
{
    private const int BaseDamage = 10;
    public string Name => "Bow";
    public int Cost => 250; 
    public double GenerateDamage()
    {
        return BaseDamage * Random.Shared.NextDouble() * 1.5 + BaseDamage;
    }
}