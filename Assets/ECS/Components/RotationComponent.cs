
using System.Collections.Generic;
using UnityEngine;

public class RotationComponent : Component
{
    public static List<RotationComponent> rotatables = new List<RotationComponent>();

    public Vector3 towards = Vector3.zero;

    public RotationComponent()
    {
        rotatables.Add(this);
    }
    public virtual void Rotate()
    {
        transform.Rotate(towards);
    }
}
