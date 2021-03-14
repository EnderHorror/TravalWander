using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlipOut : MonoBehaviour
{
    public float Speed = 1;
    public float wait = 5;

    private float nowTime;
    // Start is called before the first frame update
    void Start()
    {
        nowTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >nowTime + wait)
        transform.Translate(new Vector3(0, 1, 0)*Speed);
    }
}
