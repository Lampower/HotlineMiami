

using System;
using UnityEngine;

namespace Events
{
    public class GameEvents
    {
        public static Action<HitEntityEvent> OnHitEntity;
        public static Action<WeaponPickupEvent> OnWeaponPickup;
    }

    public class Event
    {
        public bool isCancelled = false;
    }
    public class HitEntityEvent: Event
    {
        public GameObject sender;
        public GameObject hittedObject;
        public GameObject weaponHitted;
    }
    public class EntityDiesEvent: Event
    {
        GameObject entity;
    }

    public class WeaponPickupEvent: Event
    {
    }
}