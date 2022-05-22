using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeSlider : MonoBehaviour

{
    private Slider slider;
    public float Times = 0f;
    private float TimeBurn =1f;
  

    private void Awake()
    {
        GetPrefereces();
    }
    private void Update()
    {

        if(Times >= 0)
        {
              Times += TimeBurn * Time.deltaTime;
            slider.value = Times;
        }
    }
    void GetPrefereces()
    {

        //gui ui
 
        slider = GameObject.Find("Time Slider").GetComponent<Slider>();
        slider.minValue = Times;
        //slider.maxValue = Times;
        slider.value = slider.minValue;
        

    }

}
