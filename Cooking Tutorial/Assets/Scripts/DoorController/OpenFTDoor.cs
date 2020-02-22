using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenFTDoor : MonoBehaviour
{
    public bool open = false;
    public GameObject Object;


    // Start is called before the first frame update
    void Start()
    {
        //print(transform.eulerAngles.y); 
    }

    // Update is called once per frame
    void Update()
    {
        if (open && (Object.transform.eulerAngles.y != 180))
        {
            // ROTATION = SMOOTH MOVE (FROM, TO, TIME)
            Object.transform.rotation = Quaternion.Slerp(Object.transform.rotation, Quaternion.Euler(0, 180, 0), 2 * Time.deltaTime);
            print(transform.eulerAngles.y); 
        }
        else if (!open && (Object.transform.eulerAngles.y != 270))
        {
            Object.transform.rotation = Quaternion.Slerp(Object.transform.rotation, Quaternion.Euler(0, 270, 0), 2 * Time.deltaTime);
            print(transform.eulerAngles.y); 
        }

    }
}
