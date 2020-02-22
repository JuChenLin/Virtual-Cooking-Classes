using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MicrowavePanelOperation : MonoBehaviour
{
    // Button
    public GameObject btn_start, btn_stop, btn_add30s;
    public GameObject btn_time, btn_power;
    public GameObject[] btn_function;
    public GameObject[] btn_number;
    
    // Running Behavior
    public GameObject Light, Sound;

    string state_initial = "initial";
    string state_functionselected = "functionselected";
    string state_timeselected = "timeselected";
    string state_powerelected = "powerelected";
    string state_started = "started";
    


    // Check Button pressed
    bool btnOn_start, btnOn_stop, btnOn_add30s, btnOn_time, btnOn_power;
    bool[] btnOn_function, btnOn_number;
    
    float[] function_time;
    int[] number_value;

    // state
    string state;

    // 
    //private GameObject btn_pressed;
    private float cook_time;
    private float cook_power;
    private int[] number_setted;
    private int time_value;
    private int power_value;
    private int num_press_count;

    void Start()
    {
        btn_start = GameObject.Find("button_Start");
        btn_stop = GameObject.Find("button_Stop");
        btn_add30s = GameObject.Find("button_Add30Sec");
        btn_time = GameObject.Find("button_Cooktime");
        btn_power = GameObject.Find("button_PowerLevel");

        //parentObject = GameObject.Find("Microwave");
        //Light = parentObject.transform.Find("Point Light").gameObject;
        //Sound = parentObject.transform.Find("Working Sound").gameObject;

        btn_function = GameObject.FindGameObjectsWithTag("functionBtn");
        btn_number = GameObject.FindGameObjectsWithTag("numberBtn");
        Debug.Log("btnFunction length: " + btn_function.Length);
        Debug.Log("btnNumber length: " + btn_number.Length);

        btnOn_function = new bool[btn_function.Length];
        btnOn_number = new bool[btn_number.Length];
        function_time = new float[8] {0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f};
        number_value = new int[10] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        number_setted = new int[4] {0, 0, 0, 0};
        num_press_count = 0;
        cook_time = 0;
        cook_power = 0;

        for (int i = 0; i < btn_function.Length; i++)
        {
            btnOn_function[i] = btn_function[i].GetComponent<FunctionBtnHandler>().isPressed;
            function_time[i] = btn_function[i].GetComponent<FunctionBtnHandler>().cookTime;
        }

        for (int i = 0; i < btn_number.Length; i++)
        {
            btnOn_number[i] = btn_number[i].GetComponent<NumberBtnHandler>().isPressed;
            number_value[i] = btn_number[i].GetComponent<NumberBtnHandler>().value;
        }

        state = "initial";
    }

    void Update()
    {
        btnOn_start = btn_start.GetComponent<ButtonHandler>().isPressed;
        btnOn_stop = btn_stop.GetComponent<ButtonHandler>().isPressed;
        btnOn_add30s = btn_add30s.GetComponent<ButtonHandler>().isPressed;
        btnOn_time = btn_time.GetComponent<ButtonHandler>().isPressed;
        btnOn_power = btn_power.GetComponent<ButtonHandler>().isPressed;
        for (int i = 0; i < btn_function.Length; i++)
        {
            btnOn_function[i] = btn_function[i].GetComponent<FunctionBtnHandler>().isPressed;
        }

        for (int i = 0; i < btn_number.Length; i++)
        {
            btnOn_number[i] = btn_number[i].GetComponent<NumberBtnHandler>().isPressed;
        }

        Debug.Log("BTN start: " + btnOn_start);
        Debug.Log("BTN stop:" + btnOn_stop);
        Debug.Log("BTN stop:" + btnOn_add30s);
        Debug.Log("BTN stop:" + btnOn_time);
        Debug.Log("BTN stop:" + btnOn_power);
        
        Debug.Log("state : " + state);

        switch (state) 
        { 
        case "initial": 
        //case state_initial:
            Debug.Log("Initial State");
            Debug.Log(btnOn_function[0] + "" + btnOn_function[1] + "" + btnOn_function[2] + "" + btnOn_function[3] + "" + btnOn_function[4] 
                        + "" + btnOn_function[5] + "" + btnOn_function[6] + "" + btnOn_function[7]);

            if ( btnOn_function[0] || btnOn_function[1] || btnOn_function[2] || btnOn_function[3] || 
                 btnOn_function[4] || btnOn_function[5] || btnOn_function[6] || btnOn_function[7] ) 
            {
                Debug.Log("Microwave functionselected");

                int index = System.Array.IndexOf(btnOn_function, true);
                cook_time = function_time[index];
                //goto case "functionselected";
                //state = "functionselected";
                state = state = state_functionselected;
            }
            else if ( btnOn_time )
            {
                Debug.Log("Microwave time selected");

                NumberReset();

                //state = "timeselected";
                state = state_timeselected;
            }
            else if ( btnOn_power )
            {
                Debug.Log("Microwave power selected");

                NumberReset();

                //state = "powerelected";
                state = state_powerelected;
            }
            else if ( btnOn_add30s )
            {
                Debug.Log("Microwave add 30 sec");

                cook_time = 30.0f;
                MicrowaveStart();

                state = "started";
                //state = state_started;
            }

            break; 
  
        case "functionselected": 
        //case  state_functionselected:
            Debug.Log("Functionselected state");

            // Press another function button, change "btn_pressed"
            if ( btnOn_function[0] || btnOn_function[1] || btnOn_function[2] || btnOn_function[3]
              || btnOn_function[4] || btnOn_function[5] || btnOn_function[6] || btnOn_function[7] ) 
            {
                Debug.Log("Microwave functionselected again");

                int index = System.Array.IndexOf(btnOn_function, true);
                cook_time = function_time[index];

                //goto case "functionselected";
                //state = "functionselected";
                state = state_functionselected;
            }

            if (btnOn_start) 
            {
                Debug.Log("Microwave started");

                MicrowaveStart();

                //goto case "initial";
                //state = "started";
                state = state_started;
            }
            break; 
  
        case "timeselected": 
        //case state_timeselected: 

            if ( (btnOn_number[0] || btnOn_number[1] || btnOn_number[2] || btnOn_number[3] || btnOn_number[4]
               || btnOn_number[5] || btnOn_number[6] || btnOn_number[7] || btnOn_number[8] || btnOn_number[9] ) && ( num_press_count < 4) )
            {
                num_press_count += 1;

                if(num_press_count==0) Debug.Log("Microwave time number pressed, " + "num_press_count = " + num_press_count);
                else Debug.Log("Microwave time number pressed again, " + "num_press_count = " + num_press_count);

                int index = System.Array.IndexOf(btnOn_number, true);

                for (int i = 3; i > 0; i--){
                    number_setted[i+1] = number_setted[i];
                }
                number_setted[0] = number_value[index];
                
                //goto case "timeselected";
                //state = "timeselected";
                state = state_timeselected;
            }
            else if (btnOn_start) 
            {
                Debug.Log("Microwave started");

                TimeCalculate(number_setted);
                MicrowaveStart();

                //goto case "initial";
                //state = "started";
                state = state_started;
            }

            break; 

        case "powerelected": 

            if ( (btnOn_number[0] || btnOn_number[1] || btnOn_number[2] || btnOn_number[3] || btnOn_number[4]
               || btnOn_number[5] || btnOn_number[6] || btnOn_number[7] || btnOn_number[8] || btnOn_number[9] ) && ( num_press_count < 4) )
            {
                if(num_press_count==0) Debug.Log("Microwave power number pressed, " + "num_press_count = " + num_press_count);
                else Debug.Log("Microwave power number pressed again, " + "num_press_count = " + num_press_count);

                // int index = ArrayUtility.IndexOf(btnOn_time, true);
                int index = System.Array.IndexOf(btnOn_number, true);

                for (int i = 3; i > 0; i--){
                    number_setted[i+1] = number_setted[i];
                }
                number_setted[0] = number_value[index];
                
                num_press_count += 1;

                //goto case "timeselected";
                //state = "powerselected";
                state = state_powerelected;
            }
            else if (btnOn_start) 
            {
               Debug.Log("Microwave started");

                PowerCalculate(number_setted);
                TimeCalculate(number_setted);
                MicrowaveStart();

                //state = "started";
                state = state_started;
            }

            break; 

        case "started": 
        //case state_started: 
            Debug.Log("Started state");
            cook_time -= Time.deltaTime;
            Debug.Log("Cook Time left" + cook_time);

            if (btnOn_stop) 
            {
                Debug.Log("Microwave Stopped: stop button pressed");
                MicrowaveStop();
                //goto case "initial";
                state = state_initial;
            }
            else if (cook_time <= 0){
                
                Debug.Log("Microwave Stopped: time's up");

                MicrowaveStop();
                state = state_initial;
            }
            break; 
  
        default: 
            break; 
        } 

    }

    void TimeCalculate(int[] num)
    {
        cook_time = num[3]*600 + num[2]*60 + num[1]*10 + num[0];
    }

    void PowerCalculate(int[] num)
    {
        cook_power =  num[3]*1000 + num[2]*100 + num[1]*10 + num[0];
    }

    void MicrowaveStart()
    {
        gameObject.SetActive(false);
        if (Light != null) Light.SetActive(true);
        if (Sound != null) Sound.SetActive(true);
    }

    void MicrowaveStop()
    {
        gameObject.SetActive(false);
        if (Light != null) Light.SetActive(false);
        if (Sound != null) Sound.SetActive(false);

        NumberReset();
    }

    void NumberReset() 
    {
        
        cook_time = 0;
        cook_power = 0;
        
        num_press_count = 0;
        number_setted[0] = 0;
        number_setted[1] = 0;
        number_setted[2] = 0;
        number_setted[3] = 0;
    }

}
