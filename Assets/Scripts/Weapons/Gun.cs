

using System.Collections;
using UnityEngine;

public class Gun : Weapon
{
    public Transform weaponPivot;
    public GameObject bulletPrefab;


    public override void Attack()
    {
        GameObject bullet = Instantiate(bulletPrefab, weaponPivot.position, weaponPivot.rotation);
        Bullet bulletComponent = bullet.GetComponent<Bullet>();
        bulletComponent.Init(this, flySpeed, flyTime);

        bulletComponent.rb.velocity = transform.up * flySpeed;
        //bulletComponent.rb.AddForce(transform.up * flySpeed, ForceMode2D.Impulse);
        //StartCoroutine(Fly(bulletComponent));
    }

   
}