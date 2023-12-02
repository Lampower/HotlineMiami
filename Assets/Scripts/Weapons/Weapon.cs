using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected GameObject weaponPrefab;
    [SerializeField] protected GameObject bulletPrefab;
    [SerializeField] protected Player player;

    private void Start()
    {
        transform.parent.TryGetComponent<Player>(out player);
    }

    private int currentAmmo;
    protected int maxAmmo;

    

    public abstract void Fire();

    public abstract void Reload(out int ammo);
}
