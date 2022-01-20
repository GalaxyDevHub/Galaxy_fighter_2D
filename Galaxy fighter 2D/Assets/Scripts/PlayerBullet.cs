using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    float speed = 1;
    int attack = 1;
    Rigidbody2D rb;
    PlayerShoot playerShoot;

    public void Initialize(float speed, int attack)
    {
        this.speed = speed;
        this.attack = attack;
    }

    void Start() 
    {
        rb = GetComponent<Rigidbody2D>();  
        playerShoot = GameObject.FindObjectOfType<PlayerShoot>();

        rb.velocity = new Vector2(0f, 1f * speed);
    }

    void OnEnable()
    {
        transform.rotation = Quaternion.Euler(Vector2.up);
        StartCoroutine(ReturnToPool(2f));
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        other.gameObject.GetComponent<EnemyHp>()?.TakeDamage(attack);
        StartCoroutine(ReturnToPool(0f));
    }

    IEnumerator ReturnToPool(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
        //playerShoot.UpdateAmmoInfo();
    }

}
