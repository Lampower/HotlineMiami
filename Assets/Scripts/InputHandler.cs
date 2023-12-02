using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public static InputHandler Instance { get; private set; }

    public Vector2 movementVector { get; private set; }
    public float posX { get; private set; }
    public float posY { get; private set; }
    public bool isClicked { get; private set; }
    public bool isPressed { get; private set; }
    public bool isReleased { get; private set; }
    public Vector2 mousePos { get; private set; }

    public bool reloadKeyClicked {  get; private set; }

    private void Start()
    {
        if (Instance == null)
        { Instance = this; }
    }
    // Update is called once per frame
    void Update()
    {
        posX = Input.GetAxis("Horizontal");
        posY = Input.GetAxis("Vertical");

        movementVector = new Vector2 (posX, posY);

        isPressed = Input.GetMouseButton(0);
        isClicked = Input.GetMouseButtonDown(0);
        isReleased = Input.GetMouseButtonUp(0);
        mousePos = Input.mousePosition;

        reloadKeyClicked = Input.GetKeyDown(KeyCode.R);
    }
}
