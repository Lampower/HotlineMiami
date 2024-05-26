using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MoveAll()
    {
        foreach (var moveable in MoveComponent.moveables)
        {
            moveable.Move();
        }
    }

    void RotateAll()
    {
        foreach (var rotateable in RotationComponent.rotatables)
        {
            rotateable.Rotate();
        }
    }
}
