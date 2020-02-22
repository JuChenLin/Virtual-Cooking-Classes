using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 3.0f;
	public float speedH = 2.0f;
	public float speedV = 2.0f;

	private float yaw = 0.0f;
	private float pitch = 0.0f;

    bool isTrigger;
    public GameObject simViveLeft;
    public GameObject simViveRight;

    // Start is called before the first frame update
    void Start()
    {
        //isTrigger = GameObject.FindGameObjectWithTag("micorwaveWorking").GetComponent<SimViveController>().triggerButton;
    }

    // Update is called once per frame
    void Update()
    {
		transform.Translate(speed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, speed * Input.GetAxis("Vertical") * Time.deltaTime);

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Translate(0f, speed * Time.deltaTime, 0f);
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.Translate(0f, -speed * Time.deltaTime, 0f);
        }

        yaw += speedH * Input.GetAxis("Mouse X");
		pitch -= speedV * Input.GetAxis("Mouse Y");

		transform.rotation = Quaternion.Euler(pitch, yaw, 0.0f);


        simViveLeft.GetComponent<SimViveController>().triggerButton = Input.GetKey(KeyCode.Space);
        simViveRight.GetComponent<SimViveController>().triggerButton = Input.GetKey(KeyCode.Space);
        simViveRight.GetComponent<SimViveController>().touchpadButton = Input.GetKey(KeyCode.LeftControl);
        //print(Input.GetKey(KeyCode.Space));
        //print(target);
    }


}
