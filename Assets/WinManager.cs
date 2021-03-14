using Invector.CharacterController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinManager : MonoBehaviour
{
    public bool isWin = false;

    public GameObject boat;
    public new Camera camera;
    public GameObject OldUI;
    public GameObject NewUI;
    public GameObject AirWall;

    private vThirdPersonInput vThirdPerson;
    void Start()
    {
        vThirdPerson = GameObject.FindGameObjectWithTag("Player").GetComponent<vThirdPersonInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isWin)
        {
                boat.SetActive(true);

            GameObject.FindGameObjectWithTag("Player").transform.position = transform.GetChild(2).position;
            GameObject.FindGameObjectWithTag("Player").transform.parent = boat.transform;
            Camera.main.enabled = false;
            camera.targetDisplay = 0;
            OldUI.SetActive(false);
            NewUI.SetActive(true);
            vThirdPerson.lockCam = true;
            vThirdPerson.lockMove = true;
            AirWall.SetActive(false);
            Destroy(this);
        }
    }
}
