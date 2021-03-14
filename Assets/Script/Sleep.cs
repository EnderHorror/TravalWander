using Invector.CharacterController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleep : InteractBase
{
    public static float sleepingComsumeRate =.7f;
    public bool isSleeping = false;
    public float sleepingRecoverSpeed = 1.5f;
    private PickRayCast cast;
    private GameObject player;
    private MindControl mindControl;

    void Start()
    {
        cast = Camera.main.GetComponent<PickRayCast>();
        player = GameObject.FindGameObjectWithTag("Player");
        mindControl =GameObject.Find("Mind").GetComponent<MindControl>();
        Time.timeScale = 1;
    }

    private void FixedUpdate()
    {
        if (isSleeping) mindControl.Add(mindControl.MindReduce * sleepingRecoverSpeed);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && isSleeping)
        {
            Time.timeScale = 1;
            sleepingComsumeRate = 1;
            isSleeping = false;
            player.GetComponent<vThirdPersonInput>().lockMove = false;
            player.GetComponent<vThirdPersonInput>().lockCam = false;
            GetComponent<BoxCollider>().enabled = true;
            GetComponent<Rigidbody>().useGravity = true;
            GameObject.Find("Canvas").transform.GetChild(1).gameObject.SetActive(false);
        }

        if (cast.hit.collider != null&&!isSleeping)
        {
            
            if (cast.hit.collider.gameObject == this.gameObject&&Input.GetKeyDown(KeyCode.F)&&!isSleeping)
            {
                Time.timeScale = 8;
                isSleeping = true;
                sleepingComsumeRate = 0.7f;
                GetComponent<BoxCollider>().enabled = false;
                GetComponent<Rigidbody>().useGravity = false;
                player.GetComponent<vThirdPersonInput>().lockMove = true;
                player.GetComponent<vThirdPersonInput>().lockCam = true;
                GameObject.Find("Canvas").transform.GetChild(1).gameObject.SetActive(true);

            }
        }

    }

}
