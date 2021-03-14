using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PannelControl : MonoBehaviour
{
    public GameObject target;
    public float tranzition = 5f;
    private bool canPannelOpen = false;
    private PakageManager pakage;

    public bool CanPannelOpen { get => canPannelOpen;
        set
        {
            canPannelOpen = value;
            transform.localScale = Vector3.zero;
        }
    }

    void Start()
    {
        pakage = GetComponentInParent<PakageManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            canPannelOpen = false;
        }
        if(pakage.transform.localScale == Vector3.zero)
        {
            canPannelOpen = false;
        }
        if (canPannelOpen)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one, tranzition*Time.deltaTime);
        }
        else
        {
            transform.localScale = Vector3.zero;
        }
    }
}
