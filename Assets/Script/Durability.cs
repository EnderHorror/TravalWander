using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Durability : MonoBehaviour
{
    public float maxDurable = 100;
    public float reduceEveryTime = 10;
    public float currentDurable;
    public GameObject nowTargetUI;
    void Start()
    {
        currentDurable = maxDurable;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentDurable <= 0)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<ArmsAnimation>().nowEquip = ItemDate.ItemID.尖石;
        }
    }

    public void Damage()
    {
        currentDurable -= reduceEveryTime;
    }
}
