using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    ObjectsMovement movement;
    [SerializeField] float speed;
    public float movementLimit;

    void Start()
    {
        movement = transform.GetComponent<ObjectsMovement>();
    }

    public void MoveLeft()
    {
        movement.Move(new Vector3(-movementLimit,transform.position.y,0), speed);
    }

    public void MoveRight()
    {
        movement.Move(new Vector3(movementLimit, transform.position.y, 0), speed);
    }

    public void MoveCancel()
    {
        movement.MoveCancel();
    }
}
