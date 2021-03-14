using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPManager : MonoBehaviour
{
    [Range(0,100)]
    public float hp = 100;

    public GameObject DeadUI;
    private float maxHp = 100;
    private Slider Slider;
    private float currentHp;
    private AudioSource source;
    void Start()
    {
        Slider = GetComponent<Slider>();
        source = GetComponent<AudioSource>();
        currentHp = maxHp;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        hp = Mathf.Clamp(hp, 0, maxHp);
        if (hp > 0)
        {
            Slider.value = hp / maxHp;
        }
        else
        {
            DeadUI.SetActive(true);
            Destroy(transform.parent.gameObject);
        }

        if(hp<currentHp)
        {
            if (!source.isPlaying)
                source.Play();
            currentHp = hp;
        }
        else
        {
            source.Stop();
        }

    }

    public void HpAdd(float value)
    {
        hp += value;
    }
}
