
using Second_laba.Weapon;

namespace Second_laba.Items;

public class Inventory(int size)
{
    /*private readonly List<Item> _items = [];
    */
    private readonly List<IWeapon?> _weapons = [];
    public IWeapon? this[int position] => _weapons[position];
    
    /*public bool AddNewItem(Item newItem)
    {
        if (_items.Contains(newItem) || _items.Count >= size)
            return false;

        _items.Add(newItem);

        return true;
    }

    public bool UseItem(int position, Archer archer)
    {
        if (_items.Count < position) return false;
        _items[position].Use(archer);
        _items.RemoveAt(position);
        return true;
    }
    */

    public IWeapon? GetWeapon(int position)
    {
        return _weapons.Count < position ? null : _weapons[position];
    }

    public bool AddNewWeapon(IWeapon? newWeapon)
    {
        if (_weapons.Contains(newWeapon))
            return false;

        _weapons.Add(newWeapon);

        return true;
    }

    public bool RemoveWeaponFromPos(int position)
    {
        if (_weapons.Count < position)
            return false;

        _weapons.RemoveAt(position);
        return true;
    }


    /*
    public bool RemoveItemFromPos(int position)
    {
        if (_items.Count < position)
            return false;

        _items.RemoveAt(position);
        return true;
    }
    */

    public override string ToString()
    {
        var strokes = string.Empty;
        foreach (var weapon in _weapons)
        {
            strokes += $"{weapon?.Name},";
        }

        return strokes;
    }
}