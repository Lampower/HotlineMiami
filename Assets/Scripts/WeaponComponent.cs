


using UnityEngine;

public class WeaponComponent: EcsComponent
{
    public GameObject bulletPrefab;
    public Transform WeaponPivot;

    public int damage;
    public float timeBetweenAttacks = 0.5f;
    private float cooldown = 0;

    public void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.transform.SetPositionAndRotation(WeaponPivot.position, WeaponPivot.rotation);
    }

    public void SetCooldownToZero() => cooldown = 0;
}