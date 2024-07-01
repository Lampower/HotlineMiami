

using UnityEngine;

public class PlayerRotation: MonoBehaviour
{
    public float rotateSpeed = 10;

    private void Update()
    {
        Rotate();
    }

    public void Rotate()
    {
        Quaternion rotation = Quaternion.LookRotation(transform.forward, InputSystem.Instance.mousePosition - (Vector2)transform.position);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotateSpeed * Time.deltaTime);
    }
}