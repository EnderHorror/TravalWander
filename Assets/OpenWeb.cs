using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenWeb : MonoBehaviour
{
    // Start is called before the first frame update

    public void Open(string n)
    {
        Application.OpenURL(n);
    }
}
