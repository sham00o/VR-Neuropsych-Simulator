using UnityEngine;
using System.Collections;

public class teleport : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("p"))
        {
            print("working for p");
            transform.position = new Vector3(300, 40, 30);
        }
        if (Input.GetKeyDown("o"))
        {
            transform.position = new Vector3(-1, 11, -9);
        }
        if (Input.GetKeyDown("k"))
        {
            transform.position = new Vector3(-300, 40, 30);
        }
        if (Input.GetKeyDown("j"))
        {
            transform.position = new Vector3(-300, 40, -300);
        }
    }
void OnCollisionEnter (Collision c)
    {
        if(c.collider.gameObject.tag == "test1")
        {
            print("working");
            transform.position = new Vector3(30, 40, 30);
        }
    }
}
