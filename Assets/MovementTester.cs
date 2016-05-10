using UnityEngine;
using System.Collections;

public class MovementTester : MonoBehaviour {
    int movementFlag = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if (Input.GetKey("m")){
            if (movementFlag == 0)
            {
                movementFlag = 1;
            }
            else
            {
                movementFlag = 0;
            }
        }
    if(movementFlag == 1)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.01f);
        }

	}
}
