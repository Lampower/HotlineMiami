using System.Collections;
using System.Collections.Generic;
using Events;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    public static InputSystem Instance { get; private set; }
    [SerializeField] public Vector2 mousePosition { get; private set; }
    public Vector2 movementDirection { get; private set; }

    public bool isAttacking = false;
    public bool isPickup = false;


    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null) Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        isAttacking = Input.GetKey(KeyCode.F);
        isPickup = Input.GetKeyDown(KeyCode.E);
        
    }
}
