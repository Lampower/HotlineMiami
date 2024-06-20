



using System.Collections.Generic;
using UnityEngine;

public class DamageDealComponent : EcsComponent
{
    public int damageByHand = 1;
    public WeaponComponent weapon;
    public WeaponComponent Weapon { 
        get 
        { return weapon; } 
        set 
        {
            if (value != null)
            {
                timeBetweenAttacks = value.timeBetweenAttacks;
            }
            else timeBetweenAttacks = timeBetweenMeleeAttacks;

            weapon = value;
        } 
    }

    public Collider2D HandCollider;
    public RaycastHit2D[] colliders = new RaycastHit2D[0];

    public float timeBetweenMeleeAttacks = 0.5f;
    public float timeBetweenAttacks = 0.5f;
    [SerializeField] private float cooldown = 0;

    private void Start()
    {
        timeBetweenAttacks = weapon == null ? timeBetweenMeleeAttacks : weapon.timeBetweenAttacks;
    }

    private void Update()
    {
        if (InputSystem.Instance.isAttacking && cooldown <= 0)
        {
            Debug.Log("Attacking");
            cooldown = timeBetweenAttacks;
            if (weapon != null )
            {
                weapon.Fire();
            }
            else
            {
                DealDamageByHand();
            }
        }
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }

    }

    public void DealDamageByHand()
    { 
        Debug.Log($"{gameObject.name} melee attacking");
            
        int amount = HandCollider.Cast(transform.up, colliders) ;
        Debug.Log(colliders.Length);
        foreach (var entity in colliders)
        {
            if (entity.collider.TryGetComponent<LiveComponent>(out LiveComponent entityHp))
            {
                entityHp.DealDamage(damageByHand);
            }
            }
    }
    public void SetCooldownToZero() => cooldown = 0;

}
