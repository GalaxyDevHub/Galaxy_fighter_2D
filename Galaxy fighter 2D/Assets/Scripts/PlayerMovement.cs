using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveX = 0f, speedX = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {  
       //moveX = Input.GetAxisRaw("Horizontal");
    }

    public void MoveX(float value){
        moveX = value;
    }

    void FixedUpdate() 
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        rb.velocity = new Vector2(moveX*speedX, 0f);
    }
}
