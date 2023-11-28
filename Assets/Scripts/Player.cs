using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Camera camera;

    [SerializeField] private int healthPoints;
    [SerializeField] private int damage;

    [SerializeField] private int speed;
    [SerializeField] private int rotationSpeed;

    [SerializeField] private int ammo;

    [SerializeField] public static List<Player> Players { get; private set; }
    private void Start()
    {
        AddPlayer(this);

        
    }

    private void Update()
    {
        MoveHandler();
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

    public void MoveHandler()
    {
        Vector2 vector = InputHandler.Instance.movementVector;

        transform.position += (Vector3)(vector * speed * Time.deltaTime);
    }

    public void RotationHandler()
    {
        Vector2 rotateTowardsVec = InputHandler.Instance.mousePos - (Vector2)transform.position;
        Quaternion rotateTowardsQuaternion = Quaternion.LookRotation(transform.forward, rotateTowardsVec);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotateTowardsQuaternion, rotationSpeed * Time.deltaTime);
        
    }
    
}
