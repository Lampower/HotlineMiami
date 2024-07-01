using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb;

    public float speed;
    public Vector2 dir;

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        dir = InputSystem.Instance.movementDirection;
        rb.MovePosition(rb.position + dir * speed * Time.fixedDeltaTime);
    }
}
