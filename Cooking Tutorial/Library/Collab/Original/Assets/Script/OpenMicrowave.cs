using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMicrowave : MonoBehaviour
{
    //public Object microwave;
    private Animator doorAnimator;
    public bool open = false; 

    // Start is called before the first frame update
    void Start()
    {
        doorAnimator = GetComponent<Animator>();   
    }

    // void collisionOngoing(Collider other)
    // {
    //     _animator.SetBool("open", true);
    // }

    // Update is called once per frame
    void Update()
    {
        if (open){
            doorAnimator.SetBool("open", true);
            //transform.rotation = Quaterion.Slerp (transform.rotation, Quaterion.Euler(0,45,0), 2 * Time.deltaTime);
        }
        else {

        }
    }
}
