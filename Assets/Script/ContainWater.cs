using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainWater : MonoBehaviour
{
    private Transform pickGroup;

    // Start is called before the first frame update
    void Start()
    {
        pickGroup = GameObject.Find("PickEnvri").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (RainControl.isRain)
        {
            StartCoroutine(CollectWater());
        }
    }

    IEnumerator CollectWater()
    {
        yield return new WaitForSeconds(10);
        Instantiate((GameObject)Resources.Load("龟壳雨水Obj"),
        transform.position, transform.rotation, pickGroup);
        Destroy(this.gameObject);
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
