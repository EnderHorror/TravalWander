using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullShellUse : MonoBehaviour
{
    private WaterControl water;
    private ItemBagHead bagHead;
    private ComposeField field;
    public AudioClip audio;
    void Start()
    {       
        water = GameObject.Find("Drity").GetComponent<WaterControl>();
        bagHead = GameObject.Find("BagHead").GetComponent<ItemBagHead>();
        field = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<ComposeField>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Use()
    {
        Instantiate((GameObject)Resources.Load("龟壳空"), bagHead.gameObject.transform.parent);
        AudioSource.PlayClipAtPoint(audio, Camera.main.transform.position);
        if(GetComponent<Item>().ItemID == ItemDate.ItemID.龟壳海水)
        {
            water.Add(-20);
        }
        else
        {
            water.Add(40);     
        }

        Destroy(gameObject);
        
    }
}
