


using UnityEngine;

public abstract class Weapon: MonoBehaviour
{
    public int damage = 1;
    public float flyTime;
    public float flySpeed;

    public float shotsPerSecond = 20;
    public float FireRate { get { return 1/shotsPerSecond; } }
    public abstract void Attack();
}