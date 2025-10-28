namespace Game.Weapon;

public static class WeaponFactory
{
    
    
    public static IWeapon CreateWeapon(WeaponData baseData)
    {
        // Рандомизируем характеристики
        var damage = baseData.BaseDamage + Random.Shared.Next(-baseData.DamageVariation, baseData.DamageVariation + 1);
        var cost = baseData.BaseCost + Random.Shared.Next(-baseData.CostVariation, baseData.CostVariation + 1);
        
        return baseData.Type.ToLower() switch
        {
            //в 4 лабе distance
            "bow" => new Bow("Bow", cost, damage, baseData.Distance),
            "staff" => new Staff("Staff", cost, damage, baseData.SpecialChance, baseData.Distance),
            "sword" => new Sword("Sword", cost, damage, baseData.Distance),
            _ => throw new ArgumentException($"Unknown weapon type: {baseData.Type}")
        };
    }
    
}