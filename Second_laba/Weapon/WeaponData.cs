namespace Second_laba.Weapon;

public class WeaponData
{
    public string Type { get; init; } = string.Empty;
    public string BaseName { get; set; } = string.Empty;
    public int BaseCost { get; init; }
    public int BaseDamage { get; init; }
    public int DamageVariation { get; init; }
    public int CostVariation { get; init; }
    public double SpecialChance { get; init; }
}