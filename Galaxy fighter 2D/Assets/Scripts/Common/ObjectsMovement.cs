using UnityEngine;

public class ObjectsMovement : MonoBehaviour
{
    private Vector3 MovementDirection;

    void FixedUpdate()
    {
        transform.Translate(MovementDirection);
    }

    public void Move(Vector3 direction, float speed)
    {
        MovementDirection = direction * speed;
    }

    public void MoveCancel()
    {
        MovementDirection = new Vector3();
    }
}
