using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMicrowave : MonoBehaviour
{
    //public Object microwave;
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();   
    }

    void OnTriggerEnter(Collider other)
    {
        _animator.OpenDoor???
    }

    // Update is called once per frame
    void Update()
    {
        //microwave.transform.position = ();
    }
}
