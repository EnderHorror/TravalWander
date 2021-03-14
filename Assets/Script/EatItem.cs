using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatItem : MonoBehaviour
{
    public float EatAdd = 40f;
    public AudioClip audio;
    private FoodControl food;
    private ItemBagHead bagHead;

    void Start()
    {
        food = GameObject.Find("Food").GetComponent<FoodControl>();
        bagHead = GameObject.Find("BagHead").GetComponent<ItemBagHead>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Use()
    {
        food.AddFood(40);
        AudioSource.PlayClipAtPoint(audio, Camera.main.transform.position);
        Destroy(gameObject);

    }

}
