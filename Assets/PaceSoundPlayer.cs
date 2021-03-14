using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaceSoundPlayer : MonoBehaviour
{
    public AnimationClip[] animations;
    public AudioClip[] audio;


    private Animator animator;
    private AudioSource source;
    void Start()
    {
        animator = GetComponent<Animator>();
        source = GetComponent<AudioSource>();

        AnimationEvent walk = new AnimationEvent
        {
            time = 0,
            functionName = "PlayPaceSound",
        };

        //foreach (var item in animations)
        //{
        //    item.AddEvent(walk);
        //}
    }

    private void PlayPaceSound(string nowPlaying)
    {
        if (nowPlaying == "Walk"&&animator.GetFloat("InputVertical")>0.5&& animator.GetFloat("InputVertical")<=1.1f)
        {
            source.clip = audio[Random.Range(0, 3)];
            source.pitch = Random.Range(.9f, 1.1f);
            source.Play();
        }
        else if (nowPlaying == "Run" && animator.GetFloat("InputVertical") > 1.1f)
        {
            source.clip = audio[Random.Range(0, 2)];
            source.pitch = Random.Range(.9f, 1.1f);
            source.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
