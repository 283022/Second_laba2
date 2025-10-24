namespace Second_laba.Weapon;

public class Sword : IWeapon
{
    private const int BaseDamage = 20;
    public string Name => "Sword";
    public int Cost => 200; 
    public double GenerateDamage()
    {
        return BaseDamage * Random.Shared.NextDouble() * 1.5 + BaseDamage;
    }
}