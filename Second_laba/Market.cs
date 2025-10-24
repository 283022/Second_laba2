using Second_laba.Players;
using Second_laba.Weapon;

namespace Second_laba;

public class Market
{
    private readonly List<WeaponData> _baseWeaponData;
    private readonly List<IWeapon> _generatedWeapons;
    private const int Size = 4;
    public Market()
    {
        _generatedWeapons = [];
        _baseWeaponData = CreateWeaponData();
        RefresherStock();
    }

    private List<WeaponData> CreateWeaponData()
    {
        return new List<WeaponData>
        {
            new WeaponData
            {
                Type = "Bow",
                BaseName = "Лук",
                BaseCost = 200,
                BaseDamage = 10,
                DamageVariation = 5,
                CostVariation = 50
            },
            new WeaponData
            {
                Type = "Staff",
                BaseName = "Посох",
                BaseCost = 150,
                BaseDamage = 8,
                DamageVariation = 4,
                CostVariation = 40,
                SpecialChance = 0.2
            },
            new WeaponData
            {
                Type = "Sword",
                BaseName = "Меч",
                BaseCost = 250,
                BaseDamage = 12,
                DamageVariation = 6,
                CostVariation = 60
            }
        };
    }


    public override string ToString()
    {
        var res = "Магазин оружия:\n";
        
        for (var i = 0; i < _generatedWeapons.Count; i++)
        {
            var weapon = _generatedWeapons[i];
            // Показываем КОНКРЕТНЫЙ урон
            res += $"{i + 1}. {weapon.Name} | {weapon.Cost} | {weapon.Damage} - урон\n";
        }

        return res;
    }

    public bool BuyWeapon(int position, Archer archer)
    {
        // Позиция начинается с 1, поэтому вычитаем 1
        var actualPosition = position - 1;

        if (actualPosition < 0 || actualPosition >= _generatedWeapons.Count)
        {
            return false;
        }

        var weapon = _generatedWeapons[actualPosition];
        var money = archer.GoldPlayer();

        if (weapon.Cost > money) return false;
        
        // Находим базовые данные для создания копии
        var baseType = weapon switch
        {
            Bow => "Bow",
            Staff => "Staff",
            Sword => "Sword",
            _ => "Bow"
        };

        var baseData = _baseWeaponData.First(d => d.Type == baseType);
        var weaponCopy = WeaponFactory.CreateWeapon(baseData);

        archer.AddNewWeaponToInventory(weaponCopy);

        // Убираем купленное оружие из магазина и забираем это золото у пользователя
        archer.GoldPlayerMinus(weapon.Cost ,this);
        _generatedWeapons.RemoveAt(actualPosition);
        
        return true;
    }

    //Регенерация магазина
    

    //генерация оружия
    private void RefresherStock()
    {
        _generatedWeapons.Clear();
        
        for (var i = 0; i < Size - _generatedWeapons.Count; i++)
        {
            var randomBaseData = _baseWeaponData[Random.Shared.Next(_baseWeaponData.Count)];
            var weapon = WeaponFactory.CreateWeapon(randomBaseData);
            _generatedWeapons.Add(weapon);
        }
        
    }
}