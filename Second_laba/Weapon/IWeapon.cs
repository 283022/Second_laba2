namespace Second_laba.Weapon;

public interface IWeapon
{
    double GenerateDamage();

    string Name { get; }
    int Cost { get; }
}