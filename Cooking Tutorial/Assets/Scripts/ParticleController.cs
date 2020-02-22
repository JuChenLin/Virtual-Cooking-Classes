using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public ParticleSystem particleLauncger;
    public bool isTriggered = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(isTriggered)
        {
            particleLauncger.Play();
        }
        else
        {
            particleLauncger.Stop();
        }
    }
}
