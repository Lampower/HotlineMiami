

using System.Collections.Generic;

public class HolderComponent<TObj>: Component
{
    public static List<HolderComponent<TObj>> holders { get; private set; } = new List<HolderComponent<TObj>>();

    private TObj pickedObject;

    public override void OnComponentEnable()
    {
        holders.Add(this);
    }
    public override void OnComponentDisable()
    {
        holders.Remove(this);
    }

    public virtual TObj GetPickedObject() => pickedObject;
}