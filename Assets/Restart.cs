using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public Level level;
    public GameObject BGM;
    public AudioClip falil;
    void Start()
    {
        Destroy(BGM);
        gameObject.AddComponent<AudioSource>().clip = falil;
        GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene((int)level);
        }
    }
}
