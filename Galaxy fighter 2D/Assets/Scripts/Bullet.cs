using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] int speed;
    [SerializeField] int damage;
    [SerializeField] int timeToDestroy;
    [SerializeField] ObjectPool<Bullet> pool;
    float currentTimeToDestroy;

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

    void FixedUpdate()
    {
        transform.Translate(new Vector3(0, -1f) * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        other.transform.root.GetComponent<IDamageable>()?.TakeDamage(damage);
        pool.ReturnToPool(this);
    }
}
