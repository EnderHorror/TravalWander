using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBase : MonoBehaviour
{
    public float hp;
    public bool isDead = false;
    public bool deadFinished = false;

    public void Update()
    {
        if (hp <= 0)
        {
            isDead = true;
        }
        
    }

    protected void Int(float maxHp)
    {
        hp = maxHp;
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;
    }
}
