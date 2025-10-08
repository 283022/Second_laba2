using Second_laba.Struct;

namespace Second_laba.NPC.Angry;

public class Bandit : AngryNpc
{
    public Bandit()
    {
        Name = "Bandit";
    }


    public override Meat[] LootIt()
    {
        if (Health != 0)
        {
            throw new MethodAccessException("Метод может быть вызван для волка с 0 здоровьем");
        }

        for (var i = 0; i < MeatStach.Length; i++)
        {
            MeatStach[i] = new Meat(Random.Shared.NextDouble()
                                    * Random.Shared.Next(30, 60), Random.Shared.Next(10, 24));
        }

        return MeatStach;
    }


    protected override double GenerateDamage()
    {
        return Random.Shared.Next(20, 40);
    }
}