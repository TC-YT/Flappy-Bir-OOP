using UnityEngine;

public abstract class ObstacleBase : MonoBehaviour
{
    [SerializeField] protected float speed = 2f;
    [SerializeField] protected float destroyXPosition = -10f;

    public abstract void Move();

    protected void CheckDestroy()
    {
        if (transform.position.x < destroyXPosition)
        {
            Destroy(gameObject);
        }
    }

    protected virtual void Update()
    {
        Move();
        CheckDestroy();
    }
}
