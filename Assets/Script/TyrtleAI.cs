using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TyrtleAI : MonoBehaviour
{
    private NavMeshAgent agent;
    public float speed = 0.5f;
    public Vector3 offset;
    private Vector3 centerPos;
    private Vector3 movePos;
    public float range = 10; 
    private Animator animator;
    private RaycastHit hit;
    void Start()
    {
        centerPos = transform.position;
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        movePos = new Vector3(Random.Range(-range, range), Random.Range(.5f, 1f), Random.Range(-range, range))
            + centerPos +offset;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", agent.speed);
        if (Vector3.Distance(new Vector3(transform.position.x,0,transform.position.z),new Vector3( movePos.x,0,movePos.z)) > 1.5f)
        {
            if(Physics.Raycast(movePos, Vector3.down,out hit) &&hit.collider.name == "Terrain")
            {
                agent.SetDestination(hit.point);

            }
            else
            {
                movePos = new Vector3(Random.Range(-range, range), Random.Range(.5f, 1f), Random.Range(-range, range)) + centerPos + offset;
            }
        }
        else
        {
            movePos = new Vector3(Random.Range(-range, range), Random.Range(.5f, 1f), Random.Range(-range, range)) + centerPos + offset;
            StartCoroutine(WaitToTurn());
        }

    }

    IEnumerator WaitToTurn()
    {
        agent.speed = 0;
        yield return new WaitForSeconds(1f);
        agent.speed = speed;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(hit.point, .5f);
    }
}
