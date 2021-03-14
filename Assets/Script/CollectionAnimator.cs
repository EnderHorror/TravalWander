using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionAnimator : MonoBehaviour
{
    public GameObject nowPicking;

    private PickRayCast cast;
    public AnimationClip CollectionClip;
    void Start()
    {
        cast = Camera.main.GetComponent<PickRayCast>();
        AddAnimatorEvent();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void AddAnimatorEvent()
    {
        AnimationEvent animationEvent = new AnimationEvent
        {
            functionName = "Pick",
            time = CollectionClip.length
        };
        CollectionClip.AddEvent(animationEvent);
    }

    private void Pick()
    {
        if (nowPicking.GetComponent<AnimalDeadCollect>() != null){
            nowPicking.GetComponent<AnimalDeadCollect>().EndPick();
        }
        else
        {
            nowPicking.GetComponent<Collection>().EndPick();
        }
        nowPicking = null;
    }
}
