using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveManager : MonoBehaviour
{
    public bool isOn = false;
    public GameObject obj;
    public Material Standby;
    public Material Heating;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isOn)
        {
            obj.GetComponent<MeshRenderer>().material = Heating;
            //Standby.color = Color.red;
        }
        else
        {
            obj.GetComponent<MeshRenderer>().material = Standby;
            //Standby.color = Color.white;
        }
        
    }
}
