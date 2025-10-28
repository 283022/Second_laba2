namespace Game.NPC.Angry;

public static class NpcExtension
{
    //в 4 лабе расширяющий статик
    public static double GetDistance(this AngryNpc npc, double playerX, double playerY)
    {
        return Math.Sqrt((Math.Pow(npc.CurrentCoordinates.x, 2) - Math.Pow(playerX, 2)) 
                         + (Math.Pow(npc.CurrentCoordinates.y, 2) + Math.Pow(playerY, 2)));
    }
}
