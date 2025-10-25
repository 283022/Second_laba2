namespace Game.Weapon;

public interface IWeapon
{
    double GenerateDamage();

    string Name { get; }
    int Cost { get; }
    int Damage { get; }
}