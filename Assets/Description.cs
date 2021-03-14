using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Description : MonoBehaviour
{
    public GameObject expliain;


    private void Start()
    {
        Time.timeScale = 1;
    }
    public void OpenAndClose()
    {
        if (expliain.activeSelf)
        {
            expliain.SetActive(false);
        }
        else
        {
            expliain.SetActive(true);
        }
    }
}
