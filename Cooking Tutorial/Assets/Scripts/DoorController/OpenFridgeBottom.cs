using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenFridgeBottom : MonoBehaviour
{
    public GameObject world = GameObject.Find("World");
    //public Vector3 Scale;
    public Vector3 closePosition;
    public Vector3 openPosition;
    public Vector3 moveVector;
    public float totalDeltaTime;
    public bool open = false;

    // Start is called before the first frame update
    void Start()
    {
        //Scale = world.transform.localScale;
        //moveVector = new  Vector3(world.transform.localScale .x * (-50.0f) , world.transform.localScale .y * 0.0f , world.transform.localScale .z * 0.0f );
        moveVector = new  Vector3( 0.0f, 0.0f , 50.0f );
        closePosition = transform.localPosition;
        openPosition = closePosition + moveVector;
        totalDeltaTime = 0.0f;
        Debug.Log(transform.localPosition); 
    }

    // Update is called once per frame
    void Update()
    {
        if (open && (transform.localPosition != openPosition)){
            totalDeltaTime = (totalDeltaTime >= 1.0f)? 1.0f : totalDeltaTime+Time.deltaTime;
            transform.localPosition = Vector3.Lerp(closePosition, openPosition,  totalDeltaTime);           
            Debug.Log(transform.localPosition); 
        }
        else if (!open && (transform.localPosition != closePosition)) {
            totalDeltaTime = (totalDeltaTime >= 1.0f)? 1.0f : totalDeltaTime+Time.deltaTime;
            transform.localPosition = Vector3.Lerp(openPosition, closePosition,  totalDeltaTime);            
            Debug.Log(transform.localPosition); 
        }
        else{
            totalDeltaTime = 0.0f;
        }
        
    }
}
