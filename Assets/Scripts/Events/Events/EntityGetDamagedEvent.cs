using Assets.Scripts.Interfaces;
using System;
using UnityEngine;
namespace Assets.Scripts.Events.Events
{
    public class EntityGetDamageEvent: Event
    {
        public static Action<EntityGetDamageEvent> OnEntityDamage;

        public int damage { get; }
        public IDamagable hittedObject { get; }
        public AbstractEntity hitObject { get; }
        public Vector3 positionOfHit { get; }

        public EntityGetDamageEvent(
            int damage,
            IDamagable hittedObject,
            AbstractEntity hitObject,
            Vector3 positionOfHit

            )
        {
            this.damage = damage;
            this.hittedObject = hittedObject;
            this.hitObject = hitObject;
            this.positionOfHit = positionOfHit;
        }
    }
}
