using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmsAnimation : MonoBehaviour
{
    public ItemDate.ItemID nowEquip;
    public GameObject[] hitFX;
    public AudioClip[] audios;
    public float damage;
    public LayerMask mask;
    private Animator animator;
    private MindControl mindControl;
    private RaycastHit hit;
    private CursorManager manager;
    public Arms[] arm;
    int FxIndex = 0;


    void Start()
    {
        animator = GetComponent<Animator>();
        mindControl = GameObject.Find("Mind").GetComponent<MindControl>();
        manager = GameObject.Find("CursorManager").GetComponent<CursorManager>();
        arm = GetComponentsInChildren<Arms>();
        foreach (var item in arm)
        {
            item.gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position + Vector3.up*0.5f, transform.forward);
        Physics.Raycast(ray,out hit, 3f, mask);
        Action(ItemDate.ItemID.石锤);
        Action(ItemDate.ItemID.削尖树枝);
        Action(ItemDate.ItemID.石锤);

    }
    private void Action(ItemDate.ItemID Arm)
    {
        if (nowEquip == Arm)
        {
            foreach (var item in arm)
            {
                if (item.Equip == Arm)
                {                 
                    item.gameObject.SetActive(true);
                }
            }
            if (animator.GetBool("IsGrounded") && Input.GetButtonDown("Fire1") && !manager.canShow)
            {
                animator.SetLayerWeight(1, .75f);
                animator.SetTrigger("Attack");

            }
        }
        else
        {
            foreach (var item in arm)
            {
                if (item.Equip == Arm)
                {
                    item.gameObject.SetActive(false);
                }
            }
        }
    }

    private void PlaySound()
    {
        AudioSource.PlayClipAtPoint(audios[FxIndex],Camera.main.transform.position);
        mindControl.mind--;
    }
    private void DagmageJudge()
    {
        if(hit.collider != null)
        {
            if (hit.collider.GetComponent<HPBase>() != null)
            {
                if ( hit.collider != null &&  hit.collider.GetComponent<TreeCutComponent>() != null) { FxIndex = 1; }
                else if ( hit.collider != null &&  hit.collider.GetComponent<MineRock>() != null) { FxIndex = 2; }
                else if(hit.collider.GetComponent<AnimalHP>() != null) { FxIndex = 3; }
                else { FxIndex = 0; }
                if ( hit.collider.GetComponent<ToolLim>()!=null&&  hit.collider.GetComponent<ToolLim>().needed == nowEquip)
                     hit.collider.GetComponent<HPBase>().TakeDamage(damage);
                else if( hit.collider.GetComponent<ToolLim>() ==null)
                     hit.collider.GetComponent<HPBase>().TakeDamage(damage);
                    PlaySound();
                    Instantiate(hitFX[FxIndex],
                        transform.position + transform.forward
                        , Random.rotation, hit.collider.transform).AddComponent<Dispose>();
                foreach (var item in arm)
                {
                    if(item.Equip == nowEquip)
                    {
                        item.GetComponent<Durability>().Damage();
                    }
                }
                animator.ResetTrigger("Attack");
            }
            else
            {
                AudioSource.PlayClipAtPoint(audios[0], Camera.main.transform.position);
            }


        }
        else
        {
            AudioSource.PlayClipAtPoint(audios[0], Camera.main.transform.position);
        }
    }
}
