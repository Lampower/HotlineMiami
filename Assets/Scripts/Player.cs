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

    [SerializeField] private int ammo;
    
    [SerializeField] public static List<Player> Players { get; private set; }

    public Weapon weapon;

    [SerializeField] private LayerMask layerMask;

    private void Start()
    {
        AddPlayer(this);
    }

    private void Update()
    {
        MoveHandler();
        RotationHandler();

        if (weapon != null && InputHandler.Instance.isClicked)
        {
            weapon.Fire();
        }
        if (weapon != null && InputHandler.Instance.reloadKeyClicked)
        {
            weapon.Reload(out ammo);
        }
    }

    private void AddPlayer(Player player)
    {
        if (Players == null)
        {
            Players = new List<Player>();
        }
        Players.Add(player);
    }

    public void MoveHandler()
    {
        
        Vector2 vector = InputHandler.Instance.movementVector;
        //if (!IsGoingTo(vector))
        //{
        //    transform.position += (Vector3)(vector * speed * Time.deltaTime);
        //}
        transform.position += (Vector3)(vector * speed * Time.deltaTime);

    }

    public void RotationHandler()
    {
        Vector2 mousePos = followCamera.ScreenToWorldPoint(InputHandler.Instance.mousePos);
        Vector2 rotateTowardsVec = mousePos - (Vector2)transform.position;
        Quaternion rotateTowardsQuaternion = Quaternion.LookRotation(transform.forward, rotateTowardsVec);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotateTowardsQuaternion, rotationSpeed * Time.deltaTime);
    }

    public bool IsGoingTo(Vector2 moveVector)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, moveVector, distance, layerMask);
        if (hit.collider == null) return false;
        return true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision.collider);
    }
}
