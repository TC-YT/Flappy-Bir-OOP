using UnityEngine;

public class PipeController : ObstacleBase
{
    public override void Move()
    {
        Vector3 newPosition = transform.position;
        newPosition.x -= speed * Time.deltaTime;
        transform.position = newPosition;
    }
}

