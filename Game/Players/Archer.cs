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
    public int Distance { get; private set; }
    public string Name { get; private set; } = name;
    public double HealthPoints => _health;
    private IWeapon? _currentWeapon;
    //в 4 лабе
    public (double x, double y) CurrentCoordinates { get; set; } = (Random.Shared.Next(0,60), Random.Shared.Next(0,60));

    //в 4 лабе
    public static double DamageInfo { get; private set; }
    public static int Kills { get; private set; } 
    
    public string PrintPlayerInventory()
    {
        return _inventory.ToString() != string.Empty? _inventory.ToString(): "inventory is empty";
    }


    public bool GetCurrentWeapon(int position)
    {
        if (_currentWeapon != null) Distance = _currentWeapon.Distance;
        _currentWeapon = _inventory.GetWeapon(position - 1);
        return _currentWeapon != null;
    }
    
    

    public void AddNewWeaponToInventory(IWeapon? weapon)
    {
        _inventory.AddNewWeapon(weapon);
    }

    

    private double GenerateDamage(double distance) //в 4 лабе distance и все, что с ней связано
    {
        double damage;
        if (_currentWeapon != null)
        {
            if (_currentWeapon.Distance >= distance) {
                damage = _currentWeapon.GenerateDamage();
                //в 4 лабе 
                DamageInfo += damage;
                return damage;
            }
        }

        if (distance != 0) return 0;
        
        damage = _basedamage * Random.Shared.Next(15, 21);
        //в 4 лабе
        DamageInfo += damage;
        return damage;

    }

    public void GetDamage(AngryNpc npc, double damage)
    {
        _health = double.Max(0, _health - damage);
    }

    public void Attach(AngryNpc npc,int distance)
    {
        //в 4 лабе distance
        var damage = GenerateDamage(distance);
        npc.GetDamage(this, damage);
        //в 4 лабе
        if (npc.IsDead())
        {
            Kills++;
        }
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