

using Events;
using System;
using System.Collections;
using UnityEngine;

public class Bullet: MonoBehaviour
{
    public Rigidbody2D rb;
    private Weapon weapon;

    public float flySpeed;
    public float flyTime;
    public void Init(Weapon weapon, float flySpeed, float flyTime)
    {
        this.weapon = weapon;
        this.flySpeed = flySpeed;
        this.flyTime = flyTime;

        StartCoroutine(Fly());
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.gameObject.tag == "Entities")
        {
            HitEntityEvent evt = new HitEntityEvent();
            evt.weaponHitted = weapon.gameObject;
            evt.sender = weapon.gameObject;
            evt.hittedObject = collision.gameObject;
            GameEvents.OnHitEntity?.Invoke(evt);
            if (evt.isCancelled) return;
            DestroyBullet();
        }
    }

    public void DestroyBullet()
    {
        StopAllCoroutines();
        Destroy(gameObject);
    }

    IEnumerator Fly()
    {
        rb.velocity = transform.up * flySpeed * Time.deltaTime;
        yield return new WaitForSeconds(flyTime);
        rb.velocity = Vector2.zero;
        DestroyBullet();
    }
}