using DigitalRuby.RainMaker;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainControl : MonoBehaviour
{
    public float rainRateFacter = 0;
    public static bool isRain = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float rainRat = Random.Range(0, 5f);
        if (rainRat < rainRateFacter&&!isRain)
        {
            GetComponent<RainScript>().RainIntensity = Random.Range(0.3f,1);
            isRain = true;
            rainRateFacter = 0;
        }
        else if(!isRain)
        {
            rainRateFacter += 0.0000001f;
        }

        if (GetComponent<RainScript>().RainIntensity < 0.01f) isRain = false;
        GetComponent<RainScript>().RainIntensity -= 0.01f/50;
    }
}
