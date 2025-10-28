namespace Game.Weapon;

public interface IWeapon
{
    double GenerateDamage();

    string Name { get; }
    int Cost { get; }
    int Damage { get; }
    //в 4 лабе distance
    double Distance { get; }
    
   
}