using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodControl : MonoBehaviour
{
    public float maxHunger = 100;
    [Range(0,100)]
    public float hunger = 100;
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
        hunger = Mathf.Clamp(hunger, 0, maxHunger);
        if(hunger > 0)
        {
            hunger -= hungerReduce*Sleep.sleepingComsumeRate;
            slider.value = hunger / maxHunger;
        }
        else
        {
            HpSControl.HpAdd(-hungerReduce);
        }
    }

    public void AddFood(float value)
    {
        hunger += value;
    }
}
