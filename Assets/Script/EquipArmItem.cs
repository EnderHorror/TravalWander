using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipArmItem : MonoBehaviour
{
    public ItemDate.ItemID Arm;
    private new ArmsAnimation animation;
    public float Druable = 100;
    private Durability durability;
    private ComposeField field;
    private void Start()
    {
        animation = GameObject.FindGameObjectWithTag("Player").GetComponent<ArmsAnimation>();
        field = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<ComposeField>();
    }
    public void Equip()
    {
        animation.nowEquip = Arm;
        foreach (var item in animation.arm)
        {
            if(item.Equip == Arm)
            {
                durability = item.GetComponent<Durability>();
                durability.currentDurable = Druable;
                durability.nowTargetUI = this.gameObject;
            }
        }
    }

    private void Update()
    {
        foreach (var item in animation.arm)
        {
            if(durability!=null)
            if (item.Equip == Arm&&durability.nowTargetUI == this.gameObject)
            {
                Druable = durability.currentDurable;
            }
        }
        if (Druable <= 0) Destroy(gameObject);
    }
    private void OnDestroy()
    {
        field.ObjectSet.Remove(Arm);
        field.Set.Remove(gameObject);
        animation.nowEquip = ItemDate.ItemID.树叶;
    }
}
