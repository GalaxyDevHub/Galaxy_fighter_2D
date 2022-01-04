using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    private List<GameObject> bulletPool = new List<GameObject>();
    private int poolAmount = 10, ammoCurrent;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform aim;
    [SerializeField] private Slider sliderAmmo;
    private float speed = 25f;
    private int attack = 1;

    void Start()
    {
        CreateBulletPool();
        sliderAmmo.maxValue = poolAmount;
        ammoCurrent = poolAmount;
        sliderAmmo.value = ammoCurrent;
    }

    void Update()
    {
        //ShootPC();
    }

    void ShootPC()
    {
        if(Input.GetMouseButtonDown(0)){
            Shoot();
        }
    }
    public void Shoot()
    {
        GameObject bullet = GetPooledObject();
        if(bullet){
            bullet.transform.position = new Vector3(aim.position.x, aim.position.y, 0);
            bullet.SetActive(true);
            bullet.GetComponent<PlayerBullet>().Initialize(speed, attack);
        }
        UpdateAmmoInfo();
           
    }

    void CreateBulletPool()
    {
        for(int i=0; i< poolAmount; i++){
            GameObject b = Instantiate(bulletPrefab, aim.position, aim.rotation);
            bulletPool.Add(b);
            b.SetActive(false);
        }
    }

    GameObject GetPooledObject()
    {
        for (int i = 0; i < bulletPool.Count; i++)
        {
            if (!bulletPool[i].activeInHierarchy)
            {
                return bulletPool[i];
            }
        }
        return null;
    }

    void CheckAmmoCount()
    {
        ammoCurrent = 0;
        for (int i = 0; i < bulletPool.Count; i++){
            if(bulletPool[i].gameObject.activeInHierarchy){
                ammoCurrent++;
            }
        }
    }

    public void UpdateAmmoInfo()
    {
        CheckAmmoCount();
        sliderAmmo.value = poolAmount - ammoCurrent;
    }

}
