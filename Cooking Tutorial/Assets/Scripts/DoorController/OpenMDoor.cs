using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMDoor : MonoBehaviour
{
    public bool open = false;
    public GameObject Object;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (open && (Object.transform.eulerAngles.y != 360))
        {

            Object.transform.rotation = Quaternion.Slerp(Object.transform.rotation, Quaternion.Euler(0, 0, 0), 2 * Time.deltaTime);
        }
        else if (!open && (Object.transform.eulerAngles.y != 270))
        {
            Object.transform.rotation = Quaternion.Slerp(Object.transform.rotation, Quaternion.Euler(0, -90, 0), 2 * Time.deltaTime);
        }

    }
}
