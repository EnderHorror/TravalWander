using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractaBale : MonoBehaviour
{
    private Transform UIGoal;
    protected void Start()
    {
        UIGoal = GameObject.Find("InteractGuid").transform;
        UIGoal.gameObject.transform.localScale = Vector3.zero;

    }


    public void InteracteState(bool stata)
    {
        if (stata)
        {
            UIGoal.gameObject.transform.localScale = Vector3.one;
        }
        else
        {
            UIGoal.gameObject.transform.localScale = Vector3.zero;
        }
    }
}
