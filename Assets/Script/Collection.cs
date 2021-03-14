using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.CharacterController;

public class Collection : InteractBase
{
    public ItemDate.ItemID item;

    private InteractaBale interacta;
    private bool isPicking = false;
    private ItemBagHead bagHead;
    private PickRayCast cast;
    private Animator animator;
    private vThirdPersonInput controller;
    void Start()
    {
        animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<vThirdPersonInput>();
        interacta = Camera.main.GetComponent<InteractaBale>();
        bagHead = GameObject.Find("BagHead").GetComponent<ItemBagHead>();
        cast = Camera.main.GetComponent<PickRayCast>();

    }

    // Update is called once per frame
    void Update()
    {
        if (isPicking) controller.lockMove = true;
        if (cast.hit.collider != null && cast.hit.collider.gameObject == this.gameObject)
        {
            canInteract = true;
            if (Input.GetKeyDown(KeyCode.F) && bagHead.isFull == false)
            {
                if (animator.GetBool("IsGrounded") && !isPicking && animator.GetCurrentAnimatorClipInfo(0)[0].clip.name != "Pick Fruit")
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<CollectionAnimator>().nowPicking = gameObject;
                    animator.SetTrigger("PickEnter");
                    isPicking = true;
                }
            }
        }
        else
        {
            canInteract = false;
        }

        if (Input.GetKeyDown(KeyCode.F) && isPicking && animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "Pick Fruit")
        {
            animator.SetTrigger("PickExit");
            animator.ResetTrigger("PickEnter");
            isPicking = false;
            controller.lockMove = false;
        }
    }

    public void  EndPick()
    {
        Instantiate((GameObject)Resources.Load(item.ToString()), bagHead.gameObject.transform.parent);
        interacta.InteracteState(false);
        canInteract = false;
        controller.lockMove = false;
        animator.SetTrigger("PickExit");
        animator.ResetTrigger("PickEnter");
        isPicking = false;
        GetComponent<Animation>().Play();
        GetComponent<BoxCollider>().enabled = false;
        Destroy(this.gameObject,1f);
    }  
}
