using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private GameObject enemyBulletPrefab;
    [SerializeField] private Transform aim;
    [SerializeField] private float fireRate;
    private float nextTimeToFire = 0f;

    void Start()
    {
        //InvokeRepeating(nameof(Shoot),1f, 1f);
    }

    private void Update()
    {
        if (Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    private void Shoot()
    {
        var bullet = EnemyBulletPool.Instance.Get();
        bullet.transform.rotation = Quaternion.identity;
        bullet.transform.position = aim.position;
        bullet.gameObject.SetActive(true);
    }
}
