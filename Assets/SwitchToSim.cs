using UnityEngine;
using System.Collections;

public class SwitchToSim : MonoBehaviour {
    //this will be used to make the classroom setting not active on keypress,
    //make the plane active on keypress and start simulator
    //upon another keypress, it will start the sim
    //at any time, the keypress can be pressed to stop the sim and go back to the classroom
    //if the sim stops, stop the plane from moving and put it in the starting position
    Vector3 startingPos2 = new Vector3(450, 237, 50);
    // Use this for initialization
    Vector3 startingPos1 = new Vector3(-1, 11, -9);
    Vector3 startingRot1 = new Vector3(0, 180, 0);
    Vector3 startingRot2 = new Vector3(0, 270, 0);
    GameObject cam1; 
    GameObject cam2; 
   // bool simFlag = false;
   // bool classFlag = false;
   // bool interFlag = false;
    void Start () {
        cam1 = GameObject.Find("OVRPlayerController");
        cam2 = GameObject.Find("Plane");
        cam2.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
       
            if (Input.GetKey(KeyCode.X))
            {
                //put the restart thing here
                cam1.SetActive(true);
                cam2.SetActive(false);
            cam1.transform.position = startingPos1;
            cam1.transform.rotation = Quaternion.Euler(startingRot1);
            cam2.GetComponent<Rotation>().start = false;
            cam2.GetComponent<Rotation>().startFlag = false;
            cam2.GetComponent<Rotation>().turn_left_flag = false;
            cam2.GetComponent<Rotation>().straightFlag = false;
            cam2.GetComponent<Rotation>().startSpeed = 0;
        }
        
        
        if (Input.GetKey(KeyCode.Z))
        {
            cam1.SetActive(false);
            cam2.SetActive(true);
            cam2.transform.position = startingPos2;
            cam2.transform.rotation = Quaternion.Euler(startingRot2);

            Debug.Log("yo");
            cam2.GetComponent<Rotation>().start = true;
        }
    }
}
