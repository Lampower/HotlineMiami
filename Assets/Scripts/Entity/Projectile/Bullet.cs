using Assets.Scripts.Events.Events;
using Assets.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private IFireable _shooter;
    private Vector2 _direction;
    private int _speed;
    private int _damage;

    Rigidbody2D _rb;

    public void Init(Transform pivot, 
        Vector2 direction = new Vector2(), 
        int speed = 0, 
        IFireable shooter = null,
        int damage = 1)
    {
        transform.position = pivot.position;
        transform.rotation = pivot.rotation;
        _direction = direction;
        _rb = GetComponent<Rigidbody2D>();
        _speed = speed;
        _shooter = shooter;
        _damage = damage;
    }
    void Update()
    {
        _rb.velocity = _direction * _speed;
    }

    private void OnEnable()
    {
        StartCoroutine(DestroyBullet(2));
    }

    private void OnDestroy()
    {
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StopAllCoroutines();
        if (collision.gameObject.TryGetComponent<IDamagable>(out IDamagable obj))
        {
            obj.ApplyDamage(_shooter, _damage);
        }
        StartCoroutine(DestroyBullet(0.05f));
    }

    private IEnumerator DestroyBullet(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
