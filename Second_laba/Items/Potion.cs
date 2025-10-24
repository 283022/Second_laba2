using Second_laba.Players;

namespace Second_laba.Items;


public class Poition: Item
{
    public Poition()
    {
        Name = $"Poition: {_healthpoint}";
    }
    private double _healthpoint = Random.Shared.Next(50,60) ;


    public override void Use(Archer archer)
    {
        archer.UseItem(this, _healthpoint);
    }
}