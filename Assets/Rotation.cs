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
	public bool turn_right_flag2 = false;
	public bool turn_right_flag3 = false;
	public bool endFlag = false;
	GameObject Menu;
	Text hold;
	// Use this for initialization
    void Start () {
		Menu = GameObject.Find ("Menu");
		hold = Menu.GetComponent<UnityEngine.UI.Text> ();
		Debug.Log(hold);
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
				turn_right_flag2 = true;
            }
			if (turn_right_flag2) {
				//Debug.Log ("This is active now!");
				StartCoroutine ("str4");
				StartCoroutine ("turn_right2");
				turn_right_flag3 = true;


			}
			if (turn_right_flag3) {
				StartCoroutine ("str5");
				StartCoroutine ("turn_right3");
				endFlag = true;
			}
			if (endFlag) {
				StartCoroutine ("end");
				endFlag = false;
			}
            

            if (Input.GetKey(KeyCode.JoystickButton0) && !start_protect)
            {
                startFlag = true;
            }/*
            if (Input.GetKey(KeyCode.JoystickButton4)) //LB is button 4
			
            */
			if (!startFlag && start_protect) {
				Menu.active = false;
			} else {
				Menu.active = true;
			}

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
	IEnumerator turn_right2(){
		float lrotateDiff = leftrightrotate * Time.deltaTime;

		yield return new WaitForSeconds(33.5f);
		if (turn_right_flag2) {
			transform.Rotate (0, lrotateDiff * 1.5f, 0);
		}
		//Debug.Log ("turning right");


	}
	IEnumerator str4()
	{
		yield return new WaitForSeconds(37);
		//Debug.Log ("this is working now");
		turn_right_flag2 = false;
	}
	IEnumerator turn_right3(){
		float lrotateDiff = leftrightrotate * Time.deltaTime;

		yield return new WaitForSeconds(44f);
		if (turn_right_flag3) {
			transform.Rotate (0, lrotateDiff * 1.5f, 0);
		}
		//Debug.Log ("turning right");


	}
	IEnumerator str5()
	{
		yield return new WaitForSeconds(48.5f);
		//Debug.Log ("this is working now");
		turn_right_flag3 = false;
	}
	IEnumerator end(){
		yield return new WaitForSeconds (60);
		startSpeed = 0;
	}
}	