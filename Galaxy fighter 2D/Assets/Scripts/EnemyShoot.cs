using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] GameObject enemyBulletPrefab;
    [SerializeField] Transform aim;
    [SerializeField] float fireRate;
    float nextTimeToFire = 0f;

    void Start()
    {
        //InvokeRepeating(nameof(Shoot),1f, 1f);
    }

    void Update()
    {
        if (Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        var bullet = EnemyBulletPool.Instance.Get();
        bullet.transform.rotation = Quaternion.identity;
        bullet.transform.position = aim.position;
        bullet.gameObject.SetActive(true);
    }
}
