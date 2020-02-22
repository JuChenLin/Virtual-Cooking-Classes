using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenFBDoor : MonoBehaviour
{
    public Vector3 closePosition;
    public Vector3 openPosition;
    public Vector3 moveVector;
    public float totalDeltaTime;
    public bool open = false;
    public GameObject Object;

    // Start is called before the first frame update
    void Start()
    {
        moveVector = new Vector3(0.0f, 0.0f, 50.0f);
        closePosition = Object.transform.localPosition;
        openPosition = closePosition + moveVector;
        totalDeltaTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (open && (Object.transform.localPosition != openPosition))
        {
            totalDeltaTime = (totalDeltaTime >= 1.0f) ? 1.0f : totalDeltaTime + Time.deltaTime;
            Object.transform.localPosition = Vector3.Lerp(closePosition, openPosition, totalDeltaTime);
        }
        else if (!open && (Object.transform.localPosition != closePosition))
        {
            totalDeltaTime = (totalDeltaTime >= 1.0f) ? 1.0f : totalDeltaTime + Time.deltaTime;
            Object.transform.localPosition = Vector3.Lerp(openPosition, closePosition, totalDeltaTime);
        }
        else
        {
            totalDeltaTime = 0.0f;
        }
    }
}
