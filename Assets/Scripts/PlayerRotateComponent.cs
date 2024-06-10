


using UnityEngine;

public class PlayerRotateComponent: EntityRotateComponent
{
    public float speedInDegreesPerSecond;
    private void Update()
    {
        Rotate();
    }
    public override void Rotate()
    {
        Vector2 direction = InputSystem.Instance.mousePosition - (Vector2)transform.position;

        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, direction );
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, speedInDegreesPerSecond * Time.deltaTime);

        transform.rotation = rotation;
    }
}