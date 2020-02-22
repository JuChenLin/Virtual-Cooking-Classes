using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrowavePanelOpener : MonoBehaviour
{
    public GameObject Panel;
    public bool isOperating = false;

    // Start is called before the first frame update
    void Start()
    {
        Panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isOperating && (Panel != null)) 
        {
            Panel.SetActive(true);
        }
        // else 
        // {
        //     Panel.SetActive(false);
        // }
    }
}
