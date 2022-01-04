using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHp : MonoBehaviour, IDamageable
{
    [SerializeField] private Slider sliderHp;
    private int hpMax = 10;
    private int hpCurrent;

    void Start()
    {
        hpCurrent = hpMax;
        sliderHp.maxValue = hpMax;
        sliderHp.value = hpCurrent;
    }

    void UpdateSliderHp()
    {
        sliderHp.value = hpCurrent;
    }

    public void TakeDamage(int damage)
    {
        if (hpCurrent > 0)
        {
            hpCurrent--;
            UpdateSliderHp();
            return;
        }

        SceneManager.LoadScene(0);
    }
}
