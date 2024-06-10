

using System.Collections;
using UnityEngine;

public class BulletComponent: EcsComponent
{
    public float bulletSpeed = 5;
    public float time2live = 2;
    public Vector2 direction;

    public BoxCollider2D collider;
    public Rigidbody2D rb;

    private void OnEnable()
    {
        StartCoroutine(Destroy());
    }

    private void Update()
    {
        rb.velocity = direction * bulletSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(time2live);
        Destroy();
    }
}