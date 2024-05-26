

using System.Collections.Generic;
using UnityEngine;

public class MoveComponent : Component
{
    public static List<MoveComponent> moveables { get; private set; } = new List<MoveComponent>(); 
    public float speed = 1;
    public Vector3 direction = Vector3.zero;

    public override void OnComponentEnable()
    {
        moveables.Add(this);
    }

    public override void OnComponentDisable()
    {
        moveables.Remove(this);
    }


    public virtual void Move()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
}