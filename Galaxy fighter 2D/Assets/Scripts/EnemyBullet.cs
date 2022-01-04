using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    void OnEnable()
    {
        transform.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -20f);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        other.gameObject.GetComponent<IDamageable>()?.TakeDamage(1);
        EnemyBulletPool.Instance.ReturnToPool(this);
    }
}
