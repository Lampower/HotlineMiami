
using UnityEngine;

public class PlayerMoveComponent: MoveComponent
{
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] public InputComponent input;

    public override void OnComponentEnable()
    {
        base.OnComponentEnable();
    }

    public override void Move()
    {
        if (input.isMoving)
            rb.velocity = input.direction * speed;
        else
            rb.velocity = Vector2.zero;
    }
}