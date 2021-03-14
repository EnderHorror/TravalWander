using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IEquipment
{
    void Equip();
}
public class ChangeArm : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject pannel;

    private void Start()
    {
        pannel = GameObject.Find("InteractPanel");
    }

    /// <summary>
    /// 像目标物体发送调用装备物体的指令
    /// </summary>
    public void EquipItem()
    {
        var go = GetComponentInParent<PannelControl>().target;
        if (go != null)
        {
            go.SendMessage("Equip");
            pannel.GetComponent<PannelControl>().CanPannelOpen = false;
        }
    }
}
