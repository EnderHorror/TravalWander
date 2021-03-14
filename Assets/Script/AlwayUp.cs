using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//让物体初始朝一个方向
public class AlwayUp : MonoBehaviour
{
    public Vector3 angel;
    void Start()
    {
        transform.rotation = Quaternion.Euler(angel);
    }
     
    // Update is called once per frame
    void Update()
    {
        
    }
}
