using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    float moveX = 0f, speedX = 5f;
    ObjectsMovement movement;
    [SerializeField] float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movement = transform.GetComponent<ObjectsMovement>();
    }

    void Update()
    {  
       //moveX = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate() 
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        rb.velocity = new Vector2(moveX*speedX, 0f);
        //transform.position = transform.position += new Vector3(moveX * 0.1f, 0, 0);
    }

    public void MoveX(float value)
    {
        moveX = value;
    }

    public void MoveLeft()
    {
        movement.Move(-transform.right, speed);
    }

    public void MoveRight()
    {
        movement.Move(transform.right, speed);
    }

    public void MoveCancel()
    {
        movement.MoveCancel();
    }
}
