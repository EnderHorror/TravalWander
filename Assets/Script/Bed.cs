using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour
{
    public float timeFlowSpeed = 1;

    private bool canInteract;
    private InteractaBale interacta;
    private GameObject sun;
    private bool sleeping;

    // Start is called before the first frame update
    void Start()
    {
        interacta = GetComponent<InteractaBale>();
        sun = GameObject.Find("Sun");
    }

    // Update is called once per frame
    void Update()
    {
        if (sleeping)
        {
            sun.transform.Rotate(new Vector3(timeFlowSpeed, 0, 0));
        }
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
                if (Input.GetKeyDown(KeyCode.F) &&!sleeping)
                {
                    Sleep(true);
                }
                else if(Input.GetKeyDown(KeyCode.F) && sleeping)
                {
                    Sleep(false);
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
        }
    }


    private void Sleep( bool state)
    {
        sleeping = state;
    }
}
