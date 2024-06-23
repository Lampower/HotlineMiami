

using System.Collections;
using UnityEngine;

public class BulletComponent: EcsComponent
{
    public float bulletSpeed = 5;
    public float time2live = 2;

    public Rigidbody2D rb;

    private void OnEnable()
    {
    }
   
    public void StartFly()
    {
        rb.AddForce(transform.up * bulletSpeed, ForceMode2D.Impulse);
    }
    public void StartDestroyBulletOverTime()
    {
        StartCoroutine(DestroyBulletTime());
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
    IEnumerator StopFly()
    {
        yield return new WaitForSeconds(time2live);
        rb.AddForce(Vector3.zero);
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}