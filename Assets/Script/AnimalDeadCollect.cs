using Invector.CharacterController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalDeadCollect : InteractBase
{
    public List<ItemDate.ItemID> items;

    public bool isDead = false;
    private bool isPicking = false;
    private ItemBagHead bagHead;
    private Animator animator;
    private PickRayCast cast;
    private vThirdPersonInput controller;
    void Start()
    {
        animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<vThirdPersonInput>();
        bagHead = GameObject.Find("BagHead").GetComponent<ItemBagHead>();
        cast = Camera.main.GetComponent<PickRayCast>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPicking) controller.lockMove = true;
        if (cast.hit.collider != null&& cast.hit.collider.gameObject == this.gameObject && isDead)
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
    /// <summary>
    /// 捡完之后执行
    /// </summary>
    public void EndPick()
    {
        foreach (var item in items)
        {
            Instantiate((GameObject)Resources.Load(item.ToString() + "Obj"),
                transform.position+new Vector3(Random.Range(-1,1), Random.Range(.1f, 1), Random.Range(-1, 1)), Quaternion.identity);
        }
        canInteract = false;
        controller.lockMove = false;
        animator.SetTrigger("PickExit");
        animator.ResetTrigger("PickEnter");
        isPicking = false;
        Destroy(this.gameObject);
    }
}
