



using System.Collections.Generic;
using UnityEngine;

public class InputSystem: EcsSystem
{
    public List<InputComponent> inputs;

    private void Start()
    {
        inputs = InputComponent.inputComponents;
    }

    private void Update()
    {
        Vector2 wasd = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        for (int i = 0; i < inputs.Count; i++)
        {
            inputs[i].direction = wasd;
            inputs[i].isMoving = wasd != Vector2.zero;
        }
    }
}