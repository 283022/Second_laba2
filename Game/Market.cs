using System.Text.Json;
using Game.Players;
using Game.Weapon;

namespace Game;

public class Market
{
    // Создаем 2 списка. В первом будет лежать весь проинициализированный файл json в WeaponData
    //во втором будут лежать максимум всего 4 объекта вида WeaponData.
    
    private readonly List<WeaponData> _baseWeaponData;
    private readonly List<WeaponData> _generatedWeapons;
    private const int Size = 4;

    public Market()
    {
        _generatedWeapons = [];
        _baseWeaponData = InitWeaponData();
        RefresherStock();
    }


    //Иницилаизация Json файла
    private List<WeaponData> InitWeaponData()
    {
        var json = File.ReadAllText("Weapon.json");

        //При Deserialize все имена будут без учета реестра
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var weapon = JsonSerializer.Deserialize<List<WeaponData>>(json, options);

        if (weapon == null || weapon.Count == 0)
        {
            throw new Exception("JSON файл пуст или содержит ошибки");
        }

        return weapon;
    }


    public override string ToString()
    {
        var res = "Магазин оружия:\n";

        for (var i = 0; i < _generatedWeapons.Count; i++)
        {
            var weapon = _generatedWeapons[i];
            // Показываем КОНКРЕТНЫЙ урон
            res += $"{i + 1}. {weapon.BaseName} | {weapon.BaseCost} | {weapon.BaseDamage} - урон\n";
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

        if (weapon.BaseCost > money) return false;

        archer.AddNewWeaponToInventory(WeaponFactory.CreateWeapon(weapon));

        // Убираем купленное оружие из магазина и забираем это золото у пользователя
        archer.GoldPlayerMinus(weapon.BaseCost, this);
        _generatedWeapons.RemoveAt(actualPosition);

        return true;
    }


    //Регенерация магазина
    private void RefresherStock()
    {
        var difference = Size - _generatedWeapons.Count;
        for (var i = 0; i < difference; i++)
        {
            
            var randomBaseData = _baseWeaponData[Random.Shared.Next(_baseWeaponData.Count)];
            var weaponCopy = new WeaponData
            {
                Type = randomBaseData.Type,
                BaseName = randomBaseData.BaseName,
                BaseDamage = randomBaseData.BaseDamage,
                BaseCost = randomBaseData.BaseCost,
                DamageVariation = randomBaseData.DamageVariation,
                CostVariation = randomBaseData.CostVariation
            };
            
            weaponCopy.BaseDamage += Random.Shared.Next(-weaponCopy.DamageVariation,
                weaponCopy.DamageVariation + 1 ) ;

            weaponCopy.BaseCost += Random.Shared.Next(-weaponCopy.CostVariation,
                weaponCopy.CostVariation + 1);

          
            _generatedWeapons.Add(weaponCopy);
        }
    }
}