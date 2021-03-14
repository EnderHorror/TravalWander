using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IUse
{
    void Use();
}
public class Use : MonoBehaviour
{
    private GameObject pannel;

    private void Start()
    {
        pannel = GameObject.Find("InteractPanel");
    }

    /// <summary>
    /// 像目标物体发送调用使用物体的指令
    /// </summary>
    public void UseItem()
    {
        var go = GetComponentInParent<PannelControl>().target;
        if (go != null)
        {
            go.SendMessage("Use");
            pannel.GetComponent<PannelControl>().CanPannelOpen = false;
        }
    }
}
