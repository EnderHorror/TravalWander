using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public ItemDate.ItemID ItemID;
    public ItemDate.ItemType type;
    public float itemWeight = 1;
    private GameObject pannel;
    private GameObject bag;
    private ComposeField field;
    void Start()
    {
        bag = GameObject.FindGameObjectWithTag("Bag");
        gameObject.GetComponentInChildren<Text>().text = ItemID.ToString();
        pannel = GameObject.Find("InteractPanel");
        field = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<ComposeField>();


        if (field.Set.Add(gameObject))
        {
            field.ObjectSet.Add(ItemID);
        }
    }

    private void OnDestroy()
    {
        if (field.Set.Remove(gameObject))
        {
            field.ObjectSet.Remove(ItemID);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector3.one;
    }

    public void Click()
    {
        if(transform.parent.name == "ItemMenuContent")
        {
            if (!bag.GetComponentInChildren<ItemBagHead>().isFull)
            {
                gameObject.transform.parent = bag.transform;
            }
        }
        else if(transform.parent.name == "BagContent")
        {                          
            OpenPannel();
            pannel.GetComponent<PannelControl>().target = gameObject;
        }

    }

    private void OpenPannel()
    {
        pannel.transform.position = Input.mousePosition;
        pannel.GetComponent<PannelControl>().CanPannelOpen = true;
        if(type != ItemDate.ItemType.可以使用)
        {
            pannel.transform.GetChild(0).GetComponent<Button>().interactable = false;
        }
        else
        {
            pannel.transform.GetChild(0).GetComponent<Button>().interactable = true;
        }
        if (type != ItemDate.ItemType.可以装备)
        {
            pannel.transform.GetChild(1).GetComponent<Button>().interactable = false;
        }
        else
        {
            pannel.transform.GetChild(1).GetComponent<Button>().interactable = true;
        }
    }

    private void ClosePannel()
    {
        pannel.GetComponent<PannelControl>().CanPannelOpen = false;
    }
}
