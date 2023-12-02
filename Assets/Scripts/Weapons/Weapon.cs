using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected GameObject weaponPrefab;
    [SerializeField] protected GameObject bulletPrefab;

    private int currentAmmo;
    protected int maxAmmo;

    

    public abstract void Fire();

    public abstract void Reload(out int ammo);
}
