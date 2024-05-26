

using System.Collections.Generic;

public class MoveSystem : EcsSystem
{
    public List<MoveComponent> moveComponents;

    private void Start()
    {
        moveComponents = MoveComponent.moveables;
    }

    private void Update()
    {
        foreach (var moveComponent in moveComponents)
        {
            moveComponent.Move();
        }
    }
}