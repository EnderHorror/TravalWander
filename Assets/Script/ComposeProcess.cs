using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComposeProcess : MonoBehaviour
{
    public List<ItemDate.ItemID> item;
    public AudioClip audio;
    private bool canCompose = true;
    private List<ItemDate.ItemID> ComposeList = new List<ItemDate.ItemID>();
    private ComposeField field;
    private DetectCube detect;
    private Transform pickGroup;

    void Start()
    {
        field = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<ComposeField>();
        detect = GameObject.Find("DropField").GetComponent<DetectCube>();
        pickGroup = GameObject.Find("PickEnvri").transform;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Compose()
    {
        MatState[] state = GetComponentsInChildren<MatState>();
        canCompose = true;
        foreach (var item in state)
        {
            if (!item.isMeet) canCompose = false;
        }
        if (canCompose)
        {
                foreach (var item in item)
                {
                    Instantiate(
    (GameObject)Resources.Load(item.ToString() + "Obj"),
    detect.transform.position, Quaternion.identity, pickGroup);

                }
                AudioSource.PlayClipAtPoint(audio, Camera.main.transform.position);
                DeleteObject();           
        }

    }
    /// <summary>
    /// 清除被消耗的物品
    /// </summary>
    private void DeleteObject()
    {
        ComposeList = GetComponent<ComposeList>().itemIDs;

        for (int j = 0; j < ComposeList.Count; j++)
        {
            if (field.ObjectSet.Contains(ComposeList[j]))
            {
                foreach (var i in field.Set)
                {
                    if(i!=null)
                    if (i.GetComponent<SingleObjectPick>() != null)
                    {
                        if (i.GetComponent<SingleObjectPick>().item == ComposeList[j]&& !i.GetComponent<SingleObjectPick>().canReuse)
                        {
                            field.ObjectSet.Remove(ComposeList[j]);
                            field.Set.Remove(i);
                            Destroy(i);
                            break;
                        }
                    }
                    else
                    {
                        if (i.GetComponent<Item>().ItemID == ComposeList[j])
                        {
                            field.ObjectSet.Remove(ComposeList[j]);
                            field.Set.Remove(i);
                            Destroy(i);
                            break;
                        }
                    }

                }
            }

        }

        
    }

    /// <summary>
    /// 生成火堆的方法
    /// </summary>
    private void FirePile()
    {       
        foreach (var goal in field.Set)
        {
            if (goal.GetComponent<SingleObjectPick>() != null)
            {
                if (goal.GetComponent<SingleObjectPick>().item == ItemDate.ItemID.篝火堆)
                {
                    GameObject go =Instantiate(
                (GameObject)Resources.Load(item[0].ToString() + "Obj"),
                detect.transform.position, Quaternion.identity, pickGroup);
                    go.transform.position = goal.transform.position;
                    go.transform.rotation = goal.transform.rotation;
                    DeleteObject();
                }
            }
        }
    }
}
