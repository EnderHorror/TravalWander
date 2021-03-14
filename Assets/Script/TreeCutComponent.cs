using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCutComponent :ToolLim
{
    public List<ItemDate.ItemID> DropItemList;
    public float treeMaxHp = 300;
    public bool isRoot = false;
    private Transform pickGroup;
    private DetectCube detect;

    void Start()
    {
        hp = treeMaxHp;
        if(transform.childCount != 0)
        {
            MeshRenderer[] gos = GetComponentsInChildren<MeshRenderer>();
            foreach (var go in gos)
            {
                var comp = go.gameObject.AddComponent<TreeCutComponent>();
                    comp.isRoot =false;
                comp.DropItemList = this.DropItemList;
                comp.treeMaxHp = this.treeMaxHp;
                
            }
        }
        pickGroup = GameObject.Find("PickEnvri").transform;
        detect = GameObject.Find("DropField").GetComponent<DetectCube>();

    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        if (isDead && isRoot)
        {
            Generate();
            Destroy(gameObject);
        }
        else if (isDead && !isRoot)
        {
            TreeCutComponent[] parents = GetComponentsInParent<TreeCutComponent>();
            foreach (var item in parents)
            {
                if (item.isRoot)
                {
                    Generate();
                    Destroy(item.gameObject);
                }
            }

        }
    }

    private void Generate()
    {
        foreach (var item in DropItemList)
        {
            Instantiate((GameObject)Resources.Load(item.ToString() + "Obj"),
          detect.transform.position, Quaternion.identity, pickGroup);
        }
    }
}
