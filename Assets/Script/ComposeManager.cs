using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComposeManager : MonoBehaviour
{
    public bool isOpen =false;
    public AudioClip audio;

    private void Start()
    {
        transform.localScale = Vector3.zero;
    }
    private void Update()
    {
        BroadcastMessage("ReSet");
        BroadcastMessage("CheckCompose");
        if (Input.GetKeyDown(KeyCode.C) &&!isOpen)
        {
            isOpen = true;
            gameObject.AddComponent<NeedCursor>();
            AudioSource.PlayClipAtPoint(audio, Camera.main.transform.position);
            
        }
        else if (Input.GetKeyDown(KeyCode.C) && isOpen)
        {
            isOpen = false;
            Destroy(GetComponent<NeedCursor>());
            
        }

        if(isOpen)transform.localScale = Vector3.one*.7f;
        else transform.localScale = Vector3.zero;
    }
}
