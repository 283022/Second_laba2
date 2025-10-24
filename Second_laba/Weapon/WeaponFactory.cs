namespace Second_laba.Weapon;

public static class WeaponFactory
{
    
    
    public static IWeapon CreateWeapon(WeaponData baseData)
    {
        // Рандомизируем характеристики
        var damage = baseData.BaseDamage + Random.Shared.Next(-baseData.DamageVariation, baseData.DamageVariation + 1);
        var cost = baseData.BaseCost + Random.Shared.Next(-baseData.CostVariation, baseData.CostVariation + 1);
        
        // Ограничиваем значения
        damage = Math.Max(1, damage);
        cost = Math.Max(1, cost);
        
        
        return baseData.Type.ToLower() switch
        {
            "bow" => new Bow("Bow", cost, damage),
            "staff" => new Staff("Staff", cost, damage, baseData.SpecialChance),
            "sword" => new Sword("Sword", cost, damage),
            _ => throw new ArgumentException($"Unknown weapon type: {baseData.Type}")
        };
    }
    
}