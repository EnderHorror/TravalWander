using Invector.CharacterController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepInGround : MonoBehaviour
{
    public static float sleepingComsumeRate = .7f;
    public bool isSleeping = false;
    public float sleepingRecoverSpeed = 1.5f;
    private PickRayCast cast;
    private GameObject player;
    private MindControl mindControl;

    void Start()
    {
        cast = Camera.main.GetComponent<PickRayCast>();
        player = GameObject.FindGameObjectWithTag("Player");
        mindControl = GameObject.Find("Mind").GetComponent<MindControl>();
        Time.timeScale = 1;
    }

    private void FixedUpdate()
    {
        if (isSleeping) mindControl.Add(mindControl.MindReduce * sleepingRecoverSpeed);
        if (isSleeping)
        {
            player.GetComponent<vThirdPersonInput>().lockMove = true;
            player.GetComponent<vThirdPersonInput>().lockCam = true;

        }
    }
    public void SleepInstant()
    {
        if (isSleeping)
        {
            Time.timeScale = 1;
            sleepingComsumeRate = 1;
            isSleeping = false;
            GameObject.Find("Canvas").transform.GetChild(1).gameObject.SetActive(false);
        }
        else
        {           
                Time.timeScale = 8;
                isSleeping = true;
                sleepingComsumeRate = 0.7f;
            GameObject.Find("Canvas").transform.GetChild(1).gameObject.SetActive(true);

        }

    }

}
