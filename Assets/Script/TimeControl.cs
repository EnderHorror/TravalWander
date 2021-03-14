using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeControl : MonoBehaviour
{
    public Material day;
    public Material night;
    public Color nightColor;
    public int nowDay = 1;
    public float speed = 0.5f;
    private float nowTime = 12f;
    public int timePerDay_s = 300;
    public GameObject[] Refresh;
    private Light light;
    private int step = 0;
    private int halfDayCount = 2;
    void Start()
    {
        light = GetComponent<Light>();
        speed = 360 / (float)(50 * timePerDay_s);
        step = timePerDay_s/2 * 50;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        step++;
        nowTime = (float)step / 50;
        nowDay = (int)nowTime / timePerDay_s +1;
        transform.Rotate(new Vector3(speed, 0, 0));
        if(180<transform.localEulerAngles.x)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            if (halfDayCount%2!=0)
            {
                RenderSettings.skybox = day;
                light.color = Color.white;
                light.shadows = LightShadows.Hard;
            }
            else
            {
                RenderSettings.skybox = night;
                light.shadows = LightShadows.None;
            }
            halfDayCount++;
        }

        switch (nowDay)
        {
            case 2:
                Refresh[0].SetActive(true);
                break;
            case 3:
                Refresh[1].SetActive(true);
                print(nowDay);
                break;
            case 4:
                Refresh[2].SetActive(true);
                print(nowDay);
                break;
            case 5:
                Refresh[3].SetActive(true);
                print(nowDay);
                break;
            default:
                break;
        }
    }
}
