using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineRock : ToolLim
{
    public ItemDate.ItemID MineDrop;

    private float currentHp;
    private DetectCube detect;
    private Transform pickGroup;

    void Start()
    {
        detect = GameObject.Find("DropField").GetComponent<DetectCube>();
        pickGroup = GameObject.Find("PickEnvri").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(hp!=currentHp)
        {
            if (Random.Range(0f, 1f) < .7f)
            {
                Instantiate((GameObject)Resources.Load(MineDrop.ToString() + "Obj"),
                detect.transform.parent.position + Vector3.up, Quaternion.identity, pickGroup);
                
            }
            currentHp = hp;
        }
    }
}
