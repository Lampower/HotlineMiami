

using Events;
using UnityEngine;

public class Fists : Weapon
{
    public float fistsArea = 1;
    public Collider2D collider2D;
    public override void Attack()
    {
        RaycastHit2D[] colliders = new RaycastHit2D[10];
        ContactFilter2D contactFilter = new ContactFilter2D() { };
        var amount = collider2D.Cast(transform.up, colliders, 0);
        Debug.Log(amount);
        for (int i = 0; i < amount; i++)
        {
            Debug.Log(colliders[i].transform.gameObject);
            if (colliders[i].transform.tag == "Entity")
            {
                HitEntityEvent evt = new HitEntityEvent();
                evt.sender = this.gameObject;
                evt.weaponHitted = this.gameObject;
                evt.hittedObject = colliders[i].transform.gameObject;
                GameEvents.OnHitEntity.Invoke(evt);
            }
        }
    }
}