using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Camera followCamera;

    [SerializeField] private int healthPoints;
    [SerializeField] private int damage;

    [SerializeField] private int speed;
    [SerializeField] private int rotationSpeed;
    [SerializeField] private float distance;
    [SerializeField] private Vector2 moveDirection;

    [SerializeField] private int ammo;
    
    [SerializeField] public static List<Player> Players { get; private set; }

    public Weapon weapon;

    [SerializeField] private LayerMask layerMask;

    // Player data
    Rigidbody2D rb;
    Sprite sprite;

    private void Start()
    {
        TryGetComponent<Rigidbody2D>(out rb);
        print(rb.gameObject.name);
        AddPlayer(this);
    }

    private void Update()
    {
        moveDirection = InputHandler.Instance.movementVector;
        

        if (weapon != null && InputHandler.Instance.isClicked)
        {
            weapon.Fire();
        }
        if (weapon != null && InputHandler.Instance.reloadKeyClicked)
        {
            weapon.Reload(out ammo);
        }
    }

    private void FixedUpdate()
    {
        MoveHandler(moveDirection);
        RotationHandler();
    }

    private void AddPlayer(Player player)
    {
        if (Players == null)
        {
            Players = new List<Player>();
        }
        Players.Add(player);
    }

    public void MoveHandler(Vector2 vector)
    {
        rb.velocity = vector * Time.fixedDeltaTime * speed;
        //rb?.MovePosition((Vector2)transform.position + vector * Time.fixedDeltaTime * speed);
        //print(rb.velocity);
    }

    public void RotationHandler()
    {
        Vector2 mousePos = followCamera.ScreenToWorldPoint(InputHandler.Instance.mousePos);
        Vector2 rotateTowardsVec = mousePos - (Vector2)transform.position;
        Quaternion rotateTowardsQuaternion = Quaternion.LookRotation(transform.forward, rotateTowardsVec);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotateTowardsQuaternion, rotationSpeed * Time.fixedDeltaTime);
    }

    public bool IsGoingTo(Vector2 moveVector)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, moveVector, distance, layerMask);
        if (hit.collider == null) return false;
        return true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
