using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    float speed = 1;
    float attack = 0;
    Rigidbody2D rb;
    public void Initialize(float speed, float attack){
        this.speed = speed;
        this.attack = attack;
    }
    void Start() {
        rb = GetComponent<Rigidbody2D>();  
    }
    void OnEnable()
    {
        transform.rotation = Quaternion.Euler(Vector2.up);
        StartCoroutine(ReturnToPool(2f));
    }

    private void OnDisable() {
  
    }

    void Update()
    {
        rb.velocity = new Vector2(0f,1f*speed);
    }

    void OnCollisionEnter2D(Collision2D other) {
        StartCoroutine(ReturnToPool(0.2f));
    }

    IEnumerator ReturnToPool(float time){
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }

}
