using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Success : InteractBase
{
    private PickRayCast cast;
    private InteractaBale interacta;

    // Start is called before the first frame update
    void Start()
    {
        cast = Camera.main.GetComponent<PickRayCast>();
        interacta = Camera.main.GetComponent<InteractaBale>();

    }

    // Update is called once per frame
    void Update()
    {
        if(cast.hit.collider != null &&cast.hit.collider.gameObject == gameObject && Input.GetKeyDown(KeyCode.F))
        {
            GameObject.Find("WinScene").GetComponent<WinManager>().isWin = true;
            Destroy(gameObject);
        }
    }
}
