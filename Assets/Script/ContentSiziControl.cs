using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContentSiziControl : MonoBehaviour
{
    private int currentChilren;
    private RectTransform rectTransform;
    private GridLayoutGroup grid;
    void Start()
    {
        currentChilren = transform.childCount;
        rectTransform = GetComponent<RectTransform>();
        grid = GetComponent<GridLayoutGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        
            rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, transform.childCount * grid.cellSize.y);
            currentChilren = transform.childCount;
        
    }
}
