namespace Game.Weapon;

public class WeaponData
{
    public string Type { get; set; } = string.Empty;
    public string BaseName { get; set; } = string.Empty;
    public int BaseCost { get; set; }
    public int BaseDamage { get; set; }
    public int DamageVariation { get; set; }
    
    public int CostVariation { get; set; }
    public double SpecialChance { get; set; }
    //в 4 лабе distance
    public int Distance { get; set; }
    
}