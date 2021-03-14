using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimalHP : HPBase
{
    public float maxHp = 100;

    private Animator animator;
    void Start()
    {
        Int(maxHp);
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        if (isDead && !deadFinished)
        {
            Destroy(GetComponent<NavMeshAgent>());
            Destroy(GetComponent<TyrtleAI>());
            GetComponent<AnimalDeadCollect>().isDead = true;
            animator.SetBool("IsDead", true);
            deadFinished = true;
        }
    }
}
