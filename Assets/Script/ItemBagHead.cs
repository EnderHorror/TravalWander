using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBagHead : MonoBehaviour
{
    public float maxLoad = 5;
    public bool isFull = false;

    private Text text;
    private float currentLoad;
    private float tem;
    void Start()
    {
        text = GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        isFull = currentLoad >= maxLoad ? true : false;
        var item = transform.parent.GetComponentsInChildren<Item>();
        foreach (var go in item)
        {
            tem += go.itemWeight;
        }
        if (tem != currentLoad) { currentLoad = tem;}
        tem = 0;
        text.text = $"Space{System.Math.Round(currentLoad,2)}/{maxLoad}";       
    }
}
