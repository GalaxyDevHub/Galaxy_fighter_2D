using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hp : MonoBehaviour
{
    [SerializeField] private int hp = 5;
    void Start()
    {
        
    }

    public void TakeDamage(int attack)
    {
        hp -= attack;
        if(hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
