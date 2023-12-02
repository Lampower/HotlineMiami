using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glock : Weapon
{
    public override void Fire()
    {
        GameObject prefab = Instantiate(bulletPrefab, transform);
        prefab.GetComponent<Rigidbody2D>().AddForce(transform.forward * 10);
    }

    public override void Reload(out int ammo)
    {
        throw new System.NotImplementedException();
    }
}
