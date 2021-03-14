using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurtleShellUse : MonoBehaviour
{
    private PickRayCast cast;
    private ItemBagHead bagHead;
    private GameObject pannel;

    void Start()
    {
        cast = Camera.main.GetComponent<PickRayCast>();
        bagHead = GameObject.Find("BagHead").GetComponent<ItemBagHead>();

    }

    // Update is called once per frame
    void Update()
    {
        if (cast.hit.collider != null)
        {
            if (cast.hit.collider.gameObject.name == "Water")
            {
                GetComponent<Item>().type = ItemDate.ItemType.可以使用;
            }
            else
            {
                GetComponent<Item>().type = ItemDate.ItemType.材料;
            }

        }
    }

    public void Use()
    {
        if (cast.hit.collider != null)
        {
            if (cast.hit.collider.gameObject.name == "Water")
            {               
                Instantiate((GameObject)Resources.Load("龟壳海水"), bagHead.gameObject.transform.parent);
                Destroy(gameObject);
            }
            else
            {
                GetComponent<Item>().type = ItemDate.ItemType.材料;
                pannel = GameObject.Find("InteractPanel");
                pannel.transform.GetChild(0).GetComponent<Button>().interactable = false;
            }

        }
        
    }
}
