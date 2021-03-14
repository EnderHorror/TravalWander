using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCube : MonoBehaviour
{
    public string maskTag;
    public bool isBlocked = false;
    public HashSet<GameObject> nowEnter = new HashSet<GameObject>();
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var item in nowEnter)
        {
            if (item == null)
            {
                nowEnter.Remove(item);
            }
        }
        if(nowEnter.Count==0)
        {
            isBlocked = false;
        }
        else
        {
            isBlocked = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != maskTag)
        {
            nowEnter.Add(other.gameObject);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != maskTag)
        {
            nowEnter.Remove(other.gameObject);
        }

    }
}
