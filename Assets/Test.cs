using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

	GameObject fivePointTest;
	TextMesh timer, board, instructions;

	string welcome = "Welcome!\nX-Button - simulator sickness test\nRB Button- Design Organization Test\nTEST C - j key - Five Point Test\nRETURN - o key";
	string fptDirections = "You have 2 minutes to connect 4 dots \nin as many ways a possible";

	// Use this for initialization
	void Start () {
		board = GameObject.Find ("Introduction").GetComponent<TextMesh> ();
		instructions = GameObject.Find ("Directions").GetComponent<TextMesh> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("p"))
		{
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
			board.text = "";
			instructions.text = fptDirections;
			FivePointTest fpt = gameObject.AddComponent<FivePointTest> ();
			fivePointTest = (GameObject)Instantiate (Resources.Load ("Five Point Test"));
			timer = GameObject.Find("Timer").GetComponent<TextMesh>();
			timer.text = "02:00";
		}
	}
}
