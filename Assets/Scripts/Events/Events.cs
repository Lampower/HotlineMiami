

using System;
using UnityEngine;

namespace Events
{
    public class Events
    {
        public static Action<HitEntityEvent> OnHitEntityEvent;

    }
    public class HitEntityEvent
    {
        GameObject sender;
        GameObject hittedObject;
        GameObject weaponHitted;
    }
    public class EntityDiesEvent
    {
        GameObject entity;
    }
}