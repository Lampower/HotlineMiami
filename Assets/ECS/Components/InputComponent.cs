


using System.Collections.Generic;
using UnityEngine;

public class InputComponent: Component
{
    public static List<InputComponent> inputComponents = new List<InputComponent>();

    public bool isMoving;
    public Vector3 direction;

    public override void OnComponentEnable()
    {
        inputComponents.Add(this);
    }
    public override void OnComponentDisable()
    {
        inputComponents.Remove(this);
    }
}