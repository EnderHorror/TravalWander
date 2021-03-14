using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.CharacterController;

public class PickField : MonoBehaviour
{
    public List<GameObject> containObject;
    private InteractaBale interacta;
    private Transform ItemMenu;
    private bool canInteract = false;
    private bool opening = false;
    void Start()
    {
        ItemMenu = GameObject.Find("ItemMenuParent").transform.GetChild(0);
        interacta = GetComponent<InteractaBale>();
        ItemMenu.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            interacta.InteracteState(true);
            canInteract = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (canInteract)
            {
                if (Input.GetKeyDown(KeyCode.F) && ItemMenu.gameObject.activeSelf == false)
                {
                    OpenItemMenu();
                }
                else if (Input.GetKeyDown(KeyCode.F) && ItemMenu.gameObject.activeSelf == true)
                {
                    CloseItemMenu();
                }
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            interacta.InteracteState(false);
            canInteract = false;
            if (opening)
            {
                CloseItemMenu();
            }
        }
    }

    private void OpenItemMenu()
    {
        ItemMenu.gameObject.SetActive(true);
        
        foreach (var item in containObject)
        {
             if(item != null)
             {
                Instantiate(item, ItemMenu.GetChild(0).GetChild(0));
             }
        }        
        containObject = null;
        opening = true;
    }

    private void CloseItemMenu()
    {
        containObject = new List<GameObject>();
        Item[] go = ItemMenu.GetComponentsInChildren<Item>();
        if (go != null)
        {
            foreach (var item in go)
            {
                containObject.Add((GameObject)Resources.Load(item.ItemID.ToString()));
            }

            foreach (var item in go)
            {
                Destroy(item.gameObject);
            }

        }
        ItemMenu.gameObject.SetActive(false);
        opening = false;
    }
}
