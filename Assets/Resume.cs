using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume : MonoBehaviour
{

    public void Back()
    {
        transform.parent.gameObject.SetActive(false);
    }
}
