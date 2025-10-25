using Game.NPC.Angry;
using Game.NPC.Friend;
using Game.Weapon;

namespace Game.Players;

public sealed class Archer(string name)
{
    private readonly Inventory _inventory = new Inventory();
    
    private double _health = 100.0;
    private readonly double _basedamage = 1.5;
    private double _gold;
    public string Name { get; private set; } = name;
    public double HealthPoints => _health;
    private IWeapon? _currentWeapon;

    public string PrintPlayerInventory()
    {
        return _inventory.ToString() != string.Empty? _inventory.ToString(): "inventory is empty";
    }


    public bool GetCurrentWeapon(int position)
    {
        _currentWeapon = _inventory.GetWeapon(position - 1);
        return _currentWeapon != null;
    }

    /*public void UseItemsFromInventory(int position)
    {
        _inventory.UseItem(position, this);
    }*/

    public void AddNewWeaponToInventory(IWeapon? weapon)
    {
        _inventory.AddNewWeapon(weapon);
    }

    

    private double GenerateDamage()
    {
        if (_currentWeapon != null)
        {
            return _currentWeapon.GenerateDamage();
        }

        return _basedamage * Random.Shared.Next(15, 21);
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
            _health = double.Min(loot.FoodValue + _health, 100);
            _gold += loot.GooldValue;
        }
    }

    public void Loot(FriednlyNpc npc)
    {
        _health = double.Min(npc.HealthFor + _health, 100);
        _gold += npc.GooldFor;
    }

    public double GoldPlayer()
    {
        return _gold;
    }

    public void GoldPlayerMinus(double gold, Market market)
    {
        _gold -= gold;
    }

    public bool IsDeath()
    {
        return _health <= 0;
    }
}