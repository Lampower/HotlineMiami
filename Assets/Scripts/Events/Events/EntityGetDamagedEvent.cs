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
        public IFireable shooter { get; }
        public Vector3 positionOfHit { get; }

        public EntityGetDamageEvent(
            int damage,
            IDamagable hittedObject,
            IFireable shooter,
            Vector3 positionOfHit

            )
        {
            this.damage = damage;
            this.hittedObject = hittedObject;
            this.shooter = shooter;
            this.positionOfHit = positionOfHit;
        }
    }
}
