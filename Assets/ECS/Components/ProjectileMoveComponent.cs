

using UnityEngine;

public class ProjectileMoveComponent: MoveComponent
{
    public Rigidbody rb;
    


    public override void Move()
    {
        rb.velocity = direction;      
    }
}