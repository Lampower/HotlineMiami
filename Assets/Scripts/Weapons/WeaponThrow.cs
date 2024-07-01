

using UnityEngine;

public class WeaponThrow: MonoBehaviour
{
    public float flyTime;
    public Rigidbody2D weaponRb;

    public void Init(Rigidbody2D weaponRb, float flyTime = 2)
    {
        this.weaponRb = weaponRb;
        this.flyTime = flyTime;
    }

    private void FixedUpdate()
    {
        if (flyTime > 0)
        {
            weaponRb.velocity = transform.forward;
            flyTime -= Time.deltaTime;
        }
        else
        {
            weaponRb.velocity = Vector3.zero;
            Destroy(weaponRb);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // enemy damage and other
        weaponRb.velocity = Vector3.zero;
        Destroy(weaponRb);

    }
}