using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMove : MonoBehaviour
{
    public Transform[] wayPos;
    private int i = 1;
    private new Rigidbody rigidbody;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, wayPos[i].position) > 1)
        {
            rigidbody.MovePosition(transform.position+ (wayPos[i].position - transform.position).normalized);
            if (i == wayPos.Length - 1)
            {
                i = 0;
            }
        }
        else
        {
            i++;
            transform.rotation = Quaternion.LookRotation(wayPos[i].position - transform.position, Vector3.up);
        }
            
        
    }
}
