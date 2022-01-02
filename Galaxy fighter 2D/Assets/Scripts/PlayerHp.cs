using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHp : MonoBehaviour
{
    [SerializeField] Slider sliderHp;
    int hpMax = 10;
    int hpCurrent;
    void Start()
    {
        hpCurrent = hpMax;
        sliderHp.maxValue = hpMax;
        sliderHp.value = hpCurrent;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Walls")){
            return;
        }else{
            if(hpCurrent > 0){
                hpCurrent--;
                UpdateSliderHp();
            }else{
                SceneManager.LoadScene(0);
            }
        }
    }

    void UpdateSliderHp(){
        sliderHp.value = hpCurrent;
    }
}
