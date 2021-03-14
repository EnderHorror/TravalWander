using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatState : MonoBehaviour
{
    public bool isMeet = false;
    public ItemDate.ItemID ItemID;
    public int needs = 0;
    public int now = 0;

    private Image Image;
    private Text text;
    void Start()
    {
        text = GetComponentInChildren<Text>();
        Image = GetComponent<Image>();
        
    }

    // Update is called once per frame
    void Update()
    {
        now = Mathf.Clamp(now, 0, int.MaxValue);
        text.text = ItemID.ToString() + $"({now}/{needs})";
        if (now >= needs)
        {
            Image.color = Color.green;
            isMeet = true;
        }
        else
        {
            Image.color = Color.white;
            isMeet = false;
        }
    }

    void ReSet()
    {
        now = 0;
    }
}
