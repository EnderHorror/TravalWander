using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePileUseprocess : MonoBehaviour,IUse
{


    private GameObject panel;
    private Transform pickGroup;
    private DetectCube detect;
    void Start()
    {
        panel = GameObject.Find("InteractPanel");
        pickGroup = GameObject.Find("PickEnvri").transform;
        detect = GameObject.Find("DropField").GetComponent<DetectCube>();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void Use()
    {
        if (!detect.isBlocked)
        {
            GameObject gaol = panel.GetComponent<PannelControl>().target;
            Instantiate((GameObject)Resources.Load(gaol.GetComponent<Item>().ItemID.ToString() + "Obj"),
            detect.transform.position, Quaternion.identity, pickGroup);
            panel.GetComponent<PannelControl>().CanPannelOpen = false;
            Destroy(gaol);
        }
    }
}
