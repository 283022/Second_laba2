using Second_laba.Players;

namespace Second_laba.Items;

public abstract class Item
{
    public Guid Id { get; protected set; }
    public string Name { get; protected set; } = string.Empty;
    public abstract void Use(Archer archer);

}