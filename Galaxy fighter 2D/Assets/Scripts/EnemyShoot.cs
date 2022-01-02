using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] GameObject enemyBulletPrefab;
    [SerializeField] Transform aim;
    void Start()
    {
        InvokeRepeating(nameof(Shoot),1f, 1f);
    }

    void Shoot(){
        GameObject b = Instantiate(enemyBulletPrefab, aim.position, Quaternion.identity);
    }
}
