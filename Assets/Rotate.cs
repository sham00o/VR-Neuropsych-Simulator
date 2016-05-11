using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

    int count;
    TextMesh score;

	// Use this for initialization
	void Start () {
        count = 0;
        score = gameObject.GetComponent<TextMesh>();
        score.text = "Score: " + count;
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.RotateAround(transform.position, transform.up, Time.deltaTime * 45f);
	}

    public void increment()
    {
        count++;
        score.text = "Score: " + count;
    }
}
