using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] int damage;
    [SerializeField] int timeToDestroy;
    [SerializeField] bool isPlayerBullet;
    [SerializeField] ObjectPool<Bullet> pool;
    float currentTimeToDestroy;
    ObjectsMovement movement;

    void Start()
    {
        movement = transform.GetComponent<ObjectsMovement>();
        movement.Move(new Vector3(transform.position.x, -transform.position.y * 10), speed);
    }

    void OnEnable()
    {
        currentTimeToDestroy = Time.time + timeToDestroy;
    }

    void Update()
    {
        if (Time.time >= currentTimeToDestroy)
        {
            pool.ReturnToPool(this);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player" && isPlayerBullet == true)
            return;

        if (other.transform.tag == "Enemy" && isPlayerBullet == false)
            return;

        other.transform.root.GetComponent<IDamageable>()?.TakeDamage(damage);
        pool.ReturnToPool(this);
    }
}
