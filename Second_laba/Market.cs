using System.Runtime.InteropServices;
using Second_laba.Weapon;

namespace Second_laba;

public class Market
{
    private List<IWeapon> _weapons = [new Bow(), new Staff(), new Sword()];


    public IWeapon? BuyWeapon(int position,double money)
    {
        if (_weapons.Count < position) throw new IndexOutOfRangeException();
        return _weapons[position].Cost <= money ? _weapons[position] : null;
    }
    
    
    public override string ToString()
    {
        var res = string.Empty;
        foreach (var weapon in _weapons)
        {
            res += weapon.Name + "|" + weapon.Cost + "\n";
        }

        return res;
    }
}