using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AirTime : MonoBehaviour
{
    private Slider slider;
    private GameObject Player;
    public float air = 30f;
    private float airBurn = 1f;
    private void Awake()
    {
        GetPrefereces();
    }
    private void Start()
    {
        
    }
    void Update()
    {
        if (!Player)
            return;
        if (air > 0)
        {
            air -= airBurn * Time.deltaTime;
            slider.value = air;
      
        }
        else
        {
            Destroy(Player);
        }
    }
    void GetPrefereces()
    {
        Player = GameObject.Find("Sonic");
        slider = GameObject.Find("Air Time").GetComponent<Slider>();
        slider.minValue = 0f;
        slider.maxValue = air;
        slider.value = slider.maxValue;

    }
}
