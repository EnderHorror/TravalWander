using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComposeField : MonoBehaviour
{
    public List<ItemDate.ItemID> ObjectSet = new List<ItemDate.ItemID>();
    public HashSet<GameObject> Set = new HashSet<GameObject>();

    private int currentChildren;
    private ItemBagHead bagHead;
    void Start()
    {
        bagHead = GameObject.Find("BagHead").GetComponent<ItemBagHead>();
        currentChildren = bagHead.transform.parent.childCount;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<SingleObjectPick>() != null)
        {
            if (Set.Add(other.gameObject))
            {
                ObjectSet.Add(other.gameObject.GetComponent<SingleObjectPick>().item);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<SingleObjectPick>() != null)
        {
            if (Set.Remove(other.gameObject))
            {
                ObjectSet.Remove(other.gameObject.GetComponent<SingleObjectPick>().item);
            }
        }
    }
}
