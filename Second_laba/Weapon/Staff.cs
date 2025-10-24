namespace Second_laba.Weapon;

public class Staff : IWeapon
{
    private const int BaseDamage = 10;
    public string Name => "Staff";

    public int Cost => 100; 
    public double GenerateDamage()
    {
        if (Random.Shared.NextDouble() < 0.2)
        {
            return BaseDamage + Random.Shared.Next(10, 40);
        }

        return BaseDamage * Random.Shared.NextDouble() * 1.5 + BaseDamage;
    }
}