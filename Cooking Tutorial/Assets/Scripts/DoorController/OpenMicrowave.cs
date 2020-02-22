using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMicrowave : MonoBehaviour
{
    public bool open = false; 

    // Start is called before the first frame update
    void Start()
    {
        print(transform.eulerAngles.y);  
    }

    // Update is called once per frame
    void Update()
    {
        if (open && (transform.eulerAngles.y != 0)){
            // ROTATION = SMOOTH MOVE (FROM, TO, TIME)
            transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler(0,0,0), 2 * Time.deltaTime);            
            print(transform.eulerAngles.y); 
        }
        else if (!open && (transform.eulerAngles.y != 270)) {
             transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler(0,-90,0), 2 * Time.deltaTime);            
             print(transform.eulerAngles.y); 
        }
        
    }
}
