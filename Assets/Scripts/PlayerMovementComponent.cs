


using UnityEngine;

public class PlayerMovementComponent : EntityMovementComponent
{
    public Rigidbody2D rb;

    public int speed = 5;

    public override void Move()
    {
        Vector2 dir = InputSystem.Instance.movementDirection.normalized;

        rb.velocity = dir * speed;
    }

    private void Update()
    {
        Move();
    }
}