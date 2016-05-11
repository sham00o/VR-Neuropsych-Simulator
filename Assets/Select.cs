using UnityEngine;
using System.Collections;

public class Select : MonoBehaviour {

	public Material normal;
	public Material highlight;
	public Material selected;
	public bool isHighlighted;
	public bool isSelected;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Material[] mats = GetComponent<Renderer> ().materials;
		mats [0] = normal;
		if (isSelected) {
			mats [0] = selected;
		}
		if (isHighlighted) {
			mats [0] = highlight;
		}

		GetComponent<Renderer> ().materials = mats;
	}
}
