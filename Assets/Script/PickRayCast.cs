using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickRayCast : MonoBehaviour
{
    public float detectDis = 3f;
    public LayerMask mask;
    public RaycastHit hit;
    private Transform m_Player;
    private InteractaBale interacta;
    private ItemBagHead bagHead;
    private GameObject fulltitil;

    public AudioClip clip;
    void Start()
    {

        interacta = GetComponent<InteractaBale>();
        fulltitil = GameObject.Find("Full");
        bagHead = GameObject.Find("BagHead").GetComponent<ItemBagHead>();
        m_Player = GameObject.FindWithTag("Player").transform;

        fulltitil.SetActive(false);

    }
    // Update is called once per frame
    void Update()
    {
        Vector3 dir = m_Player.position + Vector3.up - transform.position;
        Ray ray = new Ray(transform.position, dir);
        if(Physics.Raycast(ray, out hit, detectDis, mask))
        {
            if (hit.collider.GetComponent<SingleObjectPick>() != null)
            {
                interacta.InteracteState(true);
                if (Input.GetKeyDown(KeyCode.F) && bagHead.isFull == false)
                {
                    hit.collider.SendMessage("PickItemEvent");
                    AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
                }
                if ( bagHead.isFull == true)
                {
                    fulltitil.SetActive(true);
                }
                else
                {
                    fulltitil.SetActive(false);
                }
            }
            else if (hit.collider.GetComponent<InteractBase>() != null)
            {
                    if (hit.collider.GetComponent<InteractBase>().canInteract)
                        interacta.InteracteState(true);               
            }
            else
            {
                interacta.InteracteState(false);
            }
        }
        else
        {
            interacta.InteracteState(false);
        }

    }
}
