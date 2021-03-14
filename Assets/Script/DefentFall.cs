using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefentFall : MonoBehaviour
{
    public LayerMask ItemLayer;
    RaycastHit Hit;
    private void OnCollisionEnter(Collision collision)
    {
        Ray ray = new Ray(collision.transform.position + Vector3.up * 100, Vector3.down);
        Physics.Raycast(ray, out Hit,200,ItemLayer);
        if (collision.gameObject.GetComponent<SingleObjectPick>() != null)
        {
            if(Hit.collider !=null&&Hit.collider.gameObject.tag !="Water")
            {

                collision.gameObject.transform.position = Hit.point + Vector3.up;

            }
        }
    }
}
