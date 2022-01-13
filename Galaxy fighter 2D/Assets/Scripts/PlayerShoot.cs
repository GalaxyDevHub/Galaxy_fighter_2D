using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] Slider sliderAmmo;
    [SerializeField] PlayerBulletPool bulletPool;
    Transform bulletSpawner;
    float speed = 25f;
    int attack = 1;
    int poolAmount = 10;
    int ammoCurrent;

    void Start()
    {
        bulletSpawner = transform.Find("BulletSpawner");
        sliderAmmo.maxValue = poolAmount;
        ammoCurrent = poolAmount;
        sliderAmmo.value = ammoCurrent;
    }

    void CheckAmmoCount()
    {
        ammoCurrent = 0;
    }
    public void Shoot()
    {
        var bullet = bulletPool.Get();
        if (bullet == null)
            return;

        bullet.transform.rotation = bulletSpawner.rotation;
        bullet.transform.position = bulletSpawner.position;
        bullet.gameObject.SetActive(true);

    }

    public void UpdateAmmoBar()
    {
        CheckAmmoCount();
        sliderAmmo.value = poolAmount - ammoCurrent;
    }

}
