namespace Second_laba.NPC;

public abstract class Npc
{
    public Guid Id { get; protected set; } = Guid.NewGuid();

    public string Name { get; protected set; }
}