using UnityEngine;

public class ObjectsMovement : MonoBehaviour
{
    private Vector3 direction;
    private float speed;

    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, direction, Time.deltaTime * speed);
    }

    public void Move(Vector3 movementDirection, float movementSpeed)
    {
        direction = movementDirection;
        speed = movementSpeed;
    }

    public void MoveCancel()
    {
        direction = transform.position;
    }
}
