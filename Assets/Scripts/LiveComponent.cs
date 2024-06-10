

public class LiveComponent : EcsComponent
{
    public int health = 1;
    public bool IsDead()
    {
        return health < 1;
    }

    public void DealDamage(int amount)
    {
        health -= amount;
        // kill entity
    }

}