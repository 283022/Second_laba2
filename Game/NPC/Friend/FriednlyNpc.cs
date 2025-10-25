using Game.Players;

namespace Game.NPC.Friend;

public abstract class FriednlyNpc : Npc
{
    public double HealthFor { get; protected set; } = Random.Shared.Next(10, 15);
    public int GooldFor { get; protected set; } = Random.Shared.Next(1, 6);

    public abstract void GetItem(Archer archer);

}