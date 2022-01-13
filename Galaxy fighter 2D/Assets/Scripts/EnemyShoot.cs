using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] Transform bulletSpawner;
    [SerializeField] float fireRate;
    [SerializeField] EnemyBulletPool bulletPool;
    float nextTimeToFire = 0f;

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
        var bullet = bulletPool.Get();
        if (bullet == null)
            return;

        bullet.transform.rotation = bulletSpawner.rotation;
        bullet.transform.position = bulletSpawner.position;
        bullet.gameObject.SetActive(true);
    }
}
