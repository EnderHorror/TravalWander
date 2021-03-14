using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterFlyMove : MonoBehaviour
{
    public float speed = 0.5f;
    public Transform centerPos;
    public float range = 10;
    private new Rigidbody rigidbody;
    private Vector3 movePos;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        movePos = new Vector3(Random.Range(-range, range), Random.Range(.5f, 1f), Random.Range(-range, range))
            + centerPos.TransformPoint(centerPos.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position,movePos ) > 1)
        {
            rigidbody.MovePosition(transform.position + (movePos - transform.position).normalized *speed*Time.deltaTime);           
            
        }
        else
        {
            movePos = new Vector3(Random.Range(-range, range), Random.Range(.5f, 1f), Random.Range(-range, range)) + centerPos.position;
            transform.rotation = Quaternion.LookRotation(movePos - transform.position, Vector3.up);
        }


    }

}
