using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleObjectPick : MonoBehaviour
{
    public ItemDate.ItemID item;
    public bool canReuse = false;

    private ComposeField field;
    private ItemBagHead bagHead;
    void Start()
    {
        field = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<ComposeField>();
        bagHead = GameObject.Find("BagHead").GetComponent<ItemBagHead>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickItemEvent()
    {
        Instantiate((GameObject)Resources.Load(item.ToString()), bagHead.gameObject.transform.parent);
        Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
        if (field.Set.Remove(gameObject))
        {
            field.ObjectSet.Remove(gameObject.GetComponent<SingleObjectPick>().item);
        }
    }

}
