using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    List<GameObject> bulletPool = new List<GameObject>();
    int poolAmount = 10;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform aim;
    float speed = 25f, attack = 1f;
    void Start()
    {
        CreateBulletPool();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Shoot();
        }
    }

    public void Shoot(){
            GameObject bullet = GetPooledObject();
            if(bullet){
                bullet.transform.position = new Vector3(aim.position.x, aim.position.y, 0);
                bullet.SetActive(true);
                bullet.GetComponent<PlayerBullet>().Initialize(speed, attack);
            }
    }

    void CreateBulletPool(){
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

}
