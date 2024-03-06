using Assets.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Events;
using Assets.Scripts.Events.Events;

public abstract class AbstractEntity : MonoBehaviour, IInteractable
{
    public static List<AbstractEntity> entities = new List<AbstractEntity>();
    public virtual void Initialize()
    {
        entities.Add(this);
    }

    public abstract void Interact(IInteractable interactingObject);

}
