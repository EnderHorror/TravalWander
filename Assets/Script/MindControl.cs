using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MindControl : MonoBehaviour
{
    public float maxMind = 100;
    [Range(0, 100)]
    public float mind = 100;
    public float MindReduce = 0.0001f;

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
        mind = Mathf.Clamp(mind, 0, maxMind);
        if (mind > 0)
        {
            mind -= MindReduce;
            slider.value = mind / maxMind;
        }
        else
        {
            HpSControl.HpAdd(-MindReduce);
        }
    }


    public void Add(float value)
    {
        mind += value;
    }
}
