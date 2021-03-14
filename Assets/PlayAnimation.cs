using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour
{
    public GameObject PassUI;
    private void OnEnable()
    {
        GetComponent<Animation>().Play();
    }
    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<Animation>().isPlaying)
        {
            PassUI.SetActive(true);
        }
    }
}
