using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PakageManager : MonoBehaviour
{
    public bool isOpen = false;
    void Start()
    {
        CloseBag();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            isOpen = isOpen == true ? false : true;
            if (isOpen)
            {
                OpenBag();
            }
            else
            {
                CloseBag();
            }
        }       
    }

    private void OpenBag()
    {       
        transform.localScale = Vector3.one;
        gameObject.AddComponent<NeedCursor>();
        GetComponent<AudioSource>().Play();//Sound
    }

    private void CloseBag()
    {        
        transform.localScale = Vector3.zero;
        Destroy(GetComponent<NeedCursor>());
    }
}
