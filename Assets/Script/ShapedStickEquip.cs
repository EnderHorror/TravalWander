using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapedStickEquip : MonoBehaviour,IEquipment
{
    private ArmsAnimation animation;
    public void Equip()
    {
        animation = GameObject.FindGameObjectWithTag("Player").GetComponent<ArmsAnimation>();
        animation.nowEquip = ItemDate.ItemID.削尖树枝;
    }
    
}
