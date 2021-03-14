using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Level:int
{
    Start,Main
}

public class SwitchScenen : MonoBehaviour
{
    public Level level;
    void Start()
    {
        
    }


    public void Switch()
    {
        SceneManager.LoadSceneAsync((int)level);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
