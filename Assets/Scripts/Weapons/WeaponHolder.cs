

using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder: MonoBehaviour
{
    public float pickupRadius = 1;
    public Transform weaponPivot;

    public Weapon currentWeapon;

    private Weapon avalibleWeapon = null;

    public GameObject fistsPrefab;
    private Fists fists;

    float currentCooldown = 0;

    private void Start()
    {
        fists = Instantiate(fistsPrefab).GetComponent<Fists>();
        Debug.Log(fists);
        SetWeapon(null);
    }
    private void Update()
    {
        if ( currentCooldown > 0)
        {
            currentCooldown -= Time.deltaTime;
        }
        if (InputSystem.Instance.isAttacking && currentCooldown <= 0)
        {
            currentCooldown = currentWeapon.FireRate;
            currentWeapon.Attack();
        }
        if (InputSystem.Instance.isPickup)
        {
           PickUpWeapon();
        }
    }

    public void SetWeapon(Weapon weapon)
    {
        currentCooldown = 0;

        if (weapon == null)
        {
            fists.gameObject.SetActive(true);

            if (currentWeapon != null) currentWeapon.transform.parent = GameManager.Instance.World.transform;
            // throw weapon
            this.currentWeapon = fists;
        }
        else if (this.currentWeapon.GetType() == typeof(Fists) || this.currentWeapon == null)
        {
            fists.gameObject.SetActive(false);
            this.currentWeapon = weapon;
        }
        else
        {
            //throw weapon
            this.currentWeapon = weapon;
        }
        this.currentWeapon.transform.parent = weaponPivot;
        currentWeapon.transform.SetLocalPositionAndRotation(weaponPivot.localPosition, weaponPivot.localRotation);
    }

    void PickUpWeapon()
    {
        var weaponsOnScene = GameObject.FindObjectsOfType<Weapon>();
        foreach (var weapon in weaponsOnScene)
        {
            Debug.Log(weapon);
            Debug.Log(Vector2.Distance(transform.position, weapon.transform.position));
            if (Vector2.Distance(transform.position, weapon.transform.position) <= pickupRadius)
            {
                Debug.Log("Ало нахуй");
                SetWeapon(weapon);
                return;
            }
        }
        SetWeapon(null);
    }



    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log(collision.gameObject.name);
    //    if (collision.collider.TryGetComponent<Weapon>(out Weapon weapon))
    //    {
    //        avalibleWeapon = weapon;
    //    }
    //}

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.collider.TryGetComponent<Weapon>(out Weapon weapon) && (weapon == avalibleWeapon))
    //    {
    //        avalibleWeapon = null;
    //    }
    //}

    private void ThrowWeapon(Weapon weapon)
    {
        GameObject weaponObj = weapon.gameObject;
        Rigidbody2D rb = weaponObj.AddComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}