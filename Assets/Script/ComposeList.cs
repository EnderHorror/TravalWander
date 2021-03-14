using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Diagnostics;
using UnityEngine.UI;

public class ComposeList : MonoBehaviour
{
    public List<ItemDate.ItemID> itemIDs;
    public HashSet<ItemDate.ItemID> ItemSetList = new HashSet<ItemDate.ItemID>();
    public GameObject button;
    private Transform child;
    private ComposeField field;
    private List<GameObject> MatList = new List<GameObject>();
    private GameObject go;
    void Start()
    {
        field = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<ComposeField>();
        child = transform.Find("Panel");       
        foreach (var item in itemIDs)
        {
            if (ItemSetList.Add(item))
            {
                go = Instantiate(button, child);
                go.GetComponent<MatState>().ItemID = item;
                MatList.Add(go);
                go.GetComponent<MatState>().needs++;               
            }
            else
            {
                foreach (var i in MatList)
                {
                    if(i.GetComponent<MatState>().ItemID == item)
                    {
                        i.GetComponent<MatState>().needs++;
                    }
                }
            }


        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void CheckCompose()
    {
        foreach (var item in field.ObjectSet)
        {
            if (ItemSetList.Contains(item))
            {
                for (int i = 0; i < MatList.Count; i++)
                {
                    if (MatList[i].GetComponent<MatState>().ItemID == item)
                    {
                        MatList[i].GetComponent<MatState>().now++;
                    }
                }
                
            }            
        }
    }

}
