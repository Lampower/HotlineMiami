

using UnityEngine;

public abstract class Component: MonoBehaviour
{
    private void OnEnable()
    {
        OnComponentEnable();
    }
    private void OnDisable()
    {
        OnComponentDisable();
    }

    public virtual void OnComponentEnable()
    {

    }

    public virtual void OnComponentDisable()
    {

    }
    public Component()
    {

    }
}