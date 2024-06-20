

using System.Collections;
using UnityEngine;

public class BulletComponent: EcsComponent
{
    public float bulletSpeed = 5;
    public float time2live = 2;

    public BoxCollider2D collider;
    public Rigidbody2D rb;

    private void Start()
    {
        StartCoroutine(DestroyBulletTime());
        rb.AddForce(transform.up * bulletSpeed, ForceMode2D.Impulse);
    }
    

    private void Update()
    {
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.collider);
        DestroyBullet();
    }

    IEnumerator DestroyBulletTime()
    {
        yield return new WaitForSeconds(time2live);
        DestroyBullet();
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}