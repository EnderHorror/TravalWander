using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    public AudioClip audio;

    private GameObject panel;
    private Transform pickGroup;
    private DetectCube detect;
    private ComposeField field;

    void Start()
    {
        field = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<ComposeField>();
        panel = GameObject.Find("InteractPanel");
        pickGroup = GameObject.Find("PickEnvri").transform;
        detect = GameObject.Find("DropField").GetComponent<DetectCube>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void DropItemMe()
    {
        if (!detect.isBlocked)
        {          
          GameObject gaol = panel.GetComponent<PannelControl>().target;
          Instantiate((GameObject)Resources.Load(gaol.GetComponent<Item>().ItemID.ToString() + "Obj"),
          detect.transform.position, Quaternion.identity, pickGroup);
          panel.GetComponent<PannelControl>().CanPannelOpen = false;
          field.ObjectSet.Remove(gaol.GetComponent<Item>().ItemID);
          field.Set.Remove(gaol);
          Destroy(gaol);        
        }
        else
        {
            AudioSource.PlayClipAtPoint(audio, Camera.main.transform.position);
        }
    }


}
