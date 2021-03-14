using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;
using Invector.CharacterController;
using UnityEngine.SceneManagement;

public class CursorManager : MonoBehaviour
{
    private NeedCursor[] neededCount;
    public bool canShow = false;
    private vThirdPersonInput input;
    private int current;
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            input = FindObjectOfType<vThirdPersonInput>().GetComponent<vThirdPersonInput>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        neededCount = FindObjectsOfType<NeedCursor>();
        
        if(neededCount.Length != current)
        {
            if (neededCount.Length > 0)
                canShow = true;
            else
                canShow = false;

            if (canShow)
            {
                ShowCursor();
            }
            else
            {
                HideCursor();
            }
            current = neededCount.Length;
        }
    }

    private void ShowCursor()
    {
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            input.lockCam = true;
            input.lockMove = true;
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    private void HideCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            input.lockCam = false;
            input.lockMove = false;
        }
    }
}
