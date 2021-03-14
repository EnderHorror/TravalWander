using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterControl : MonoBehaviour
{
    public float maxWater = 100;
    [Range(0, 100)]
    public float water = 100;
    public float hungerReduce = 0.0001f;

    private Slider slider;
    private HPManager HpSControl;
    void Start()
    {
        slider = GetComponent<Slider>();
        HpSControl = transform.parent.Find("HP").GetComponent<HPManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        water = Mathf.Clamp(water, 0, maxWater);
        if (water > 0)
        {
            water -= hungerReduce * Sleep.sleepingComsumeRate;
            slider.value = water / maxWater;
        }
        else
        {
            HpSControl.HpAdd(-hungerReduce);
        }
    }


    public void Add(float value)
    {
        water += value;
    }
}
