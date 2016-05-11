using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Rotation : MonoBehaviour {
    float speed = 0.5f; //testing, will be moving at a constant speed at all times
    public float startSpeed = 0;
    float rotate = 15.0f;
    float leftrightrotate = 15.0f;
    float MaxSpeed = 20.0f;
    public bool startFlag = false;
    public bool turn_left_flag = false;
    public bool turn_right_flag = false;
    public  bool start = false;
    public bool upFlag = false;
    public bool start_protect = false;
    // Use this for initialization
    void Start () {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (start == false) { startSpeed = 0;startFlag = false; turn_left_flag = false; turn_right_flag = false;  }
        if (start)
        {
            float speedDiff = startSpeed * Time.deltaTime;
            float rotateDiff = rotate * Time.deltaTime;
            float lrotateDiff = leftrightrotate * Time.deltaTime;
            transform.Translate(0, 0, speedDiff);
            if (startFlag)
            {
                StartCoroutine("Speedup");
                startFlag = false;
                start_protect = true;
            }
            if (turn_left_flag)
            {
                StartCoroutine("turn_left"); // change this time based on testing
                StartCoroutine("str");
               
                turn_right_flag = true;
                //upFlag = true;
                
            }
           // if (upFlag)
           // {
             //   StartCoroutine("go_up");
            //    StartCoroutine("str3");

           // }
            if (turn_right_flag)
            {
                StartCoroutine("turn_right");
                StartCoroutine("str2");
            }


            

            if (Input.GetKey(KeyCode.JoystickButton0) && !start_protect)
            {
                startFlag = true;
            }/*
            if (Input.GetKey(KeyCode.JoystickButton4)) //LB is button 4
            {
                transform.Rotate(0, 0, rotateDiff);
                // print("LB button pressed");
            }
            if (Input.GetKey(KeyCode.JoystickButton5)) // RB is button 5
            {
                transform.Rotate(0, 0, -rotateDiff);
                //print("RB button pressed"); //works
            }
            if (Input.GetAxis("RT") == 1)
            {
                //print("RT button pressed");
            }
            if (Input.GetAxis("Horizontal1") == 1)
            {
                if (startSpeed < MaxSpeed)
                    startSpeed += speed;
                //transform.Translate(0, 0, speedDiff);

                // print("accel");
            }
            if (Input.GetAxis("Horizontal1") == -1)
            {
                if (startSpeed != 0)
                {
                    startSpeed -= speed;
                    //transform.Translate(0, 0, speedDiff);
                }

                //print("deAccel");
            }
            if (Input.GetAxis("Vertical1") == 1)
            {
                transform.Rotate(0, -lrotateDiff, 0);
                //print("going left");
            }
            if (Input.GetAxis("Vertical1") == -1)
            {
                transform.Rotate(0, lrotateDiff, 0);
                //print("going right");
            }
            if (Input.GetAxis("Horizontal2") == -1)
            {
                transform.Rotate(rotateDiff, 0, 0);
                // print("going up");
            }
            if (Input.GetAxis("Horizontal2") == 1)
            {
                transform.Rotate(-rotateDiff, 0, 0);
                // print("going down");
            }*/
        }
    }
    void Speedup()
    {
        startSpeed += speed*40f;
        startFlag = false;
        turn_left_flag = true;
    }
    IEnumerator turn_left()
    {
        float lrotateDiff = leftrightrotate * Time.deltaTime;

        
        yield return new WaitForSeconds(2f);
        transform.Rotate(0, -lrotateDiff*2, 0);
    }
    IEnumerator turn_right()
    {
        float lrotateDiff = leftrightrotate * Time.deltaTime;

        yield return new WaitForSeconds(12);
        transform.Rotate(0, lrotateDiff*2, 0);
    }
    IEnumerator str()
    {   
        yield return new WaitForSeconds(3);
        turn_left_flag = false;
        
    }
    IEnumerator str2()
    {
        yield return new WaitForSeconds(15);
        turn_right_flag = false;
    }
    IEnumerator go_up()
    {
        float rotateDiff = rotate * Time.deltaTime;
        yield return new WaitForSeconds(7);
        //rotate up for a bit, then even out
        transform.Rotate(-rotateDiff*.5f, 0, 0);
    }
    IEnumerator str3()
    {
        yield return new WaitForSeconds(8);
        upFlag = false;
    }
}
