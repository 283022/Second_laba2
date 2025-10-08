namespace Second_laba.NPC.Friend;

public abstract class FriednlyNpc : Npc
{
    public double HealthFor { get; protected set; } = Random.Shared.Next(10, 15);
    public int ExpFor { get; protected set; } = Random.Shared.Next(1, 6);
}