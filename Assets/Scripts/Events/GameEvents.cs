

using System;
using UnityEngine;

namespace Events
{
    public class GameEvents
    {
        public static Action<HitEntityEvent> OnHitEntity;
        public static Action<WeaponPickupEvent> OnWeaponPickup;
    }
    public class HitEntityEvent
    {
        public GameObject sender;
        public GameObject hittedObject;
        public GameObject weaponHitted;
    }
    public class EntityDiesEvent
    {
        GameObject entity;
    }

    public class WeaponPickupEvent
    {
        public DamageDealComponent holder;
        public WeaponComponent weapon;
    }
}