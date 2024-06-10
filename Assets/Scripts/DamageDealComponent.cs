



using UnityEngine;

public class DamageDealComponent : EcsComponent
{
    public int amount;
    public float timeBetweenAttacks = 0.5f;
    private float cooldown = 0;

    private void Update()
    {
        if (InputSystem.Instance.isAttacking)
        {
            DealDamage();
        }
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }

    }

    public void DealDamage()
    {
        if (cooldown <= 0)
        {
            Debug.Log($"{gameObject.name} attacking");
            cooldown = timeBetweenAttacks;
        }


    }
}
