



using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;

public class DamageDealComponent : EcsComponent
{
    public int damageByHand = 1;
    public WeaponComponent weapon;
    public Transform weaponPosition;

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
            if (entity.collider.TryGetComponent<HealthComponent>(out HealthComponent entityHp))
            {
                entityHp.DealDamage(damageByHand);
            }
            }
    }
    public void SetCooldownToZero() => cooldown = 0;

    public void SetWeapon(WeaponComponent weapon)
    {
        if (this.weapon != null)
        {
            //trow weapon
            //and take new one
            ThrowWeapon();
            return;
        }
        if (weapon != null)
        {
            timeBetweenAttacks = weapon.timeBetweenAttacks;
        }
        else timeBetweenAttacks = timeBetweenMeleeAttacks;

        this.weapon = weapon;
        this.weapon.transform.SetParent(weaponPosition);
        this.weapon.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity );
    }
    public void ThrowWeapon()
    {
        if (weapon == null) return;
        GameObject weaponObject = weapon.gameObject;

        weaponObject.transform.SetParent(GameManager.Instance.World.transform);

        var rb = weaponObject.AddComponent<Rigidbody2D>();
        var bc = weaponObject.AddComponent<BulletComponent>();
        bc.rb = rb;
        bc.bulletSpeed = 5;
        bc.StartFly();


        weapon = null;
        // sadly weapon will be destroyed on throw
    }
}
