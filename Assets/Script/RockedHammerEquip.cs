using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockedHammerEquip : MonoBehaviour,IEquipment
{
    private ArmsAnimation animation;
    public void Equip()
    {
        animation = GameObject.FindGameObjectWithTag("Player").GetComponent<ArmsAnimation>();
        animation.nowEquip = ItemDate.ItemID.石锤;
    }
    private void OnDestroy()
    {
        animation.nowEquip = ItemDate.ItemID.树叶;
    }
}
