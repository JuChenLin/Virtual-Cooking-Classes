/*
Copyright ©2017. The University of Texas at Dallas. All Rights Reserved. 

Permission to use, copy, modify, and distribute this software and its documentation for 
educational, research, and not-for-profit purposes, without fee and without a signed 
licensing agreement, is hereby granted, provided that the above copyright notice, this 
paragraph and the following two paragraphs appear in all copies, modifications, and 
distributions. 

Contact The Office of Technology Commercialization, The University of Texas at Dallas, 
800 W. Campbell Road (AD15), Richardson, Texas 75080-3021, (972) 883-4558, 
otc@utdallas.edu, https://research.utdallas.edu/otc for commercial licensing opportunities.

IN NO EVENT SHALL THE UNIVERSITY OF TEXAS AT DALLAS BE LIABLE TO ANY PARTY FOR DIRECT, 
INDIRECT, SPECIAL, INCIDENTAL, OR CONSEQUENTIAL DAMAGES, INCLUDING LOST PROFITS, ARISING 
OUT OF THE USE OF THIS SOFTWARE AND ITS DOCUMENTATION, EVEN IF THE UNIVERSITY OF TEXAS AT 
DALLAS HAS BEEN ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

THE UNIVERSITY OF TEXAS AT DALLAS SPECIFICALLY DISCLAIMS ANY WARRANTIES, INCLUDING, BUT 
NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR 
PURPOSE. THE SOFTWARE AND ACCOMPANYING DOCUMENTATION, IF ANY, PROVIDED HEREUNDER IS 
PROVIDED "AS IS". THE UNIVERSITY OF TEXAS AT DALLAS HAS NO OBLIGATION TO PROVIDE 
MAINTENANCE, SUPPORT, UPDATES, ENHANCEMENTS, OR MODIFICATIONS.
*/

using UnityEngine;
using System.Collections;

public class VirtualHand : MonoBehaviour
{

    // Enumerate states of virtual hand interactions
    public enum VirtualHandState
    {
        Open,
        Touching,
        Holding
    };

    // Inspector parameters
    [Tooltip("The tracking device used for tracking the real hand.")]
    public CommonTracker tracker;

    [Tooltip("The interactive used to represent the virtual hand.")]
    public Affect hand;

    [Tooltip("The button required to be pressed to grab objects.")]
    public CommonButton button;


    public CommonButton trigger;

    [Tooltip("The speed amplifier for thrown objects. One unit is physically realistic.")]
    public float speed = 1.0f;

    // Private interaction variables
    VirtualHandState state;
    FixedJoint grasp;

    // Called at the end of the program initialization
    void Start()
    {

        // Set initial state to open
        state = VirtualHandState.Open;

        // Ensure hand interactive is properly configured
        hand.type = AffectType.Virtual;
    }

    // FixedUpdate is not called every graphical frame but rather every physics frame
    void FixedUpdate()
    {

        // If state is open
        if (state == VirtualHandState.Open)
        {

            // If the hand is touching something
            if (hand.triggerOngoing)
            {

                // Change state to touching
                Debug.Log("Touching");
                state = VirtualHandState.Touching;
            }

            // Process current open state
            else
            {

                // Nothing to do for open
            }
        }

        // If state is touching
        else if (state == VirtualHandState.Touching)
        {

            // If the hand is not touching something
            if (!hand.triggerOngoing)
            {

                // Change state to open
                Debug.Log("Open");
                state = VirtualHandState.Open;
            }

            // If the hand is touching something and the button is pressed
            else if (hand.triggerOngoing && button.GetPress())
            {

                // Fetch touched target
                Collider target = hand.ongoingTriggers[0];
                // Create a fixed joint between the hand and the target
                grasp = target.gameObject.AddComponent<FixedJoint>();
                // Set the connection
                grasp.connectedBody = hand.gameObject.GetComponent<Rigidbody>();

                // Change state to holding
                state = VirtualHandState.Holding;
            }

            else if (hand.triggerOngoing && trigger.GetPressDown())
            {

                Collider target = hand.ongoingTriggers[0];

                if (target.GetComponent<OpenMDoor>())
                {
                    bool status = target.GetComponent<OpenMDoor>().open;
                    int yAxis = Mathf.RoundToInt(target.GetComponent<OpenMDoor>().transform.eulerAngles.y);

                    if (status == true && yAxis == 0)
                    {
                        Debug.Log("TurnOff");
                        status = false;
                        target.GetComponent<OpenMDoor>().open = status;

                    }
                    else if (status == false && yAxis == 270)
                    {
                        Debug.Log("TurnOn");
                        status = true;
                        target.GetComponent<OpenMDoor>().open = status;
                    }
                }

                if (target.GetComponent<OpenFTDoor>())
                {
                    bool status = target.GetComponent<OpenFTDoor>().open;
                    int yAxis = Mathf.RoundToInt(target.GetComponent<OpenFTDoor>().transform.eulerAngles.y);

                    if (status == true && yAxis == 180)
                    {
                        status = false;
                        target.GetComponent<OpenFTDoor>().open = status;

                    }
                    else if(status == false && yAxis == 270)
                    {
                        status = true;
                        target.GetComponent<OpenFTDoor>().open = status;
                    }
                }

                if (target.GetComponent<OpenFBDoor>())
                {
                    bool status = target.GetComponent<OpenFBDoor>().open;
                    float position = target.GetComponent<OpenFBDoor>().Object.transform.localPosition.z;
                    Debug.Log(position);

                    if (status == true && position >= 83)
                    {
                        status = false;
                        target.GetComponent<OpenFBDoor>().open = status;

                    }
                    else if (status == false && position <= 34)
                    {
                        status = true;
                        target.GetComponent<OpenFBDoor>().open = status;
                    }
                }

                if (target.GetComponent<MicrowavePanelOpener>())
                {
                    bool status = target.GetComponent<MicrowavePanelOpener>().isOperating;
                    Debug.Log("Control Panel operating:" + status);

                    if (status == false)
                    {
                        status = true;
                        target.GetComponent<MicrowavePanelOpener>().isOperating = status;
                    }
                    else { }
                    //else if (status == false)
                    //{
                    //    status = true;
                    //    target.GetComponent<MicrowavePanelOpener>().isOperating = status;
                    //}
                }

                if (target.GetComponent<ButtonHandler>())
                {
                    bool status = target.GetComponent<ButtonHandler>().isPressed;
                    Debug.Log("Button pressed:" + status);

                    if (status == true)
                    {
                        status = false;
                        target.GetComponent<ButtonHandler>().isPressed = status;
                    }
                    else if (status == false)
                    {
                        status = true;
                        target.GetComponent<ButtonHandler>().isPressed = status;
                    }
                }

                if (target.GetComponent<StoveManager>())
                {
                    bool status = target.GetComponent<StoveManager>().isOn;

                    if (status == true)
                    {
                        status = false;
                        target.GetComponent<StoveManager>().isOn = status;

                    }
                    else if (status == false)
                    {
                        status = true;
                        target.GetComponent<StoveManager>().isOn = status;
                    }
                }

                if (target.GetComponent<ParticleController>())
                {
                    bool status = target.GetComponent<ParticleController>().isTriggered;

                    if (status == true)
                    {
                        status = false;
                        target.GetComponent<ParticleController>().isTriggered = status;

                    }
                    else if (status == false)
                    {
                        status = true;
                        target.GetComponent<ParticleController>().isTriggered = status;
                    }
                }

                // Process current touching state
                else
                {

                    // Nothing to do for touching
                }
            }
        }

        // If state is holding
        else if (state == VirtualHandState.Holding)
        {

            // If grasp has been broken
            if (grasp == null)
            {

                // Update state to open
                state = VirtualHandState.Open;
            }

            // If button has been released and grasp still exists
            else if (!button.GetPress() && grasp != null)
            {

                // Get rigidbody of grasped target
                Rigidbody target = grasp.GetComponent<Rigidbody>();
                // Break grasp
                DestroyImmediate(grasp);

                // Apply physics to target in the event of attempting to throw it
                target.velocity = hand.velocity * speed;
                target.angularVelocity = hand.angularVelocity * speed;

                // Update state to open
                state = VirtualHandState.Open;
            }

            // Process current holding state
            else
            {
                if( grasp != null && trigger.GetPressDown())
                if (grasp.GetComponent<ParticleController>())
                {
                    bool status = grasp.GetComponent<ParticleController>().isTriggered;

                    if (status == true)
                    {
                        status = false;
                        grasp.GetComponent<ParticleController>().isTriggered = status;

                    }
                    else if (status == false)
                    {
                        status = true;
                        grasp.GetComponent<ParticleController>().isTriggered = status;
                    }
                }
                // Nothing to do for holding
            }
        }
    }
}