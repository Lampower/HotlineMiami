using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupWeaponComponent : EcsComponent
{
    public DamageDealComponent weaponHolder;
    WeaponComponent weaponNearPlayer = null;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (InputSystem.Instance.isPickup)
        {
            if (weaponNearPlayer != null)
            {
                Debug.Log(weaponNearPlayer);
                Debug.Log(weaponHolder);
                weaponHolder.SetWeapon(weaponNearPlayer);

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.TryGetComponent<WeaponComponent>(out WeaponComponent wc))
        {
            weaponNearPlayer = wc;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<WeaponComponent>(out WeaponComponent wc))
        {
            if (wc == weaponNearPlayer) weaponNearPlayer = null;
        }
    }
}
