using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class FivePointTest : MonoBehaviour {

	TextMesh timer;
	GameObject testObject;
	GameObject highlightedSphere;
	List<GameObject> selectedSpheres, sphereLines, models, modelLines;
	float modelOffsetX;
	float modelOffsetY;
	int min, sec;
	bool isRunning;

    void Start () {
		min = 2;
		sec = 0;
		timer = GameObject.Find("Timer").GetComponent<TextMesh>();
		highlightedSphere = null;
		selectedSpheres = new List<GameObject> ();
		sphereLines = new List<GameObject> ();
		models = new List<GameObject> ();
		modelLines = new List<GameObject> ();
		modelOffsetX = 0.0f;
		modelOffsetY = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("v")) {
			if (!isRunning) {
				isRunning = true;
				resetTest ();
				StartCoroutine ("countdown");
			} else {
				isRunning = false;
				StopCoroutine ("countdown");
			}
		}

		if (Input.GetKeyDown ("t")) {
			select ();
		}

		if (Input.GetKeyDown ("y")) {
			undoSelect ();
		}

		if (Input.GetKeyDown ("g")) {
			saveModel ();
		}

		Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.55f, 0.55f, 0));
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit)) {
			string target = hit.transform.name;
			if (target == "TL" || target == "TR" || target == "MM" || target == "BL"|| target == "BR") {
				if (highlightedSphere == null) {
					highlightedSphere = hit.collider.gameObject;
				}
				if (highlightedSphere.transform.name != target) {
					highlightedSphere.GetComponent<Select> ().isHighlighted = false;
					highlightedSphere = hit.collider.gameObject;
				}
				hit.collider.gameObject.GetComponent<Select> ().isHighlighted = true;
				print("I'm looking at " + target);
			}
		}
	}

	void resetTest() {
		resetTestModel ();
		foreach(GameObject model in models) {
			Destroy(model);
		}
		foreach (GameObject line in modelLines) {
			Destroy (line);
		}
		models = new List<GameObject> ();
		modelLines = new List<GameObject> ();
		modelOffsetX = 0.0f;
		modelOffsetY = 0.0f;
		min = 2;
		sec = 0;
	}

	void resetTestModel() {
		selectedSpheres = new List<GameObject> ();
		foreach (GameObject line in sphereLines) {
			Destroy (line);
		}
		sphereLines = new List<GameObject> ();
	}

	void transferSelectionToModel(GameObject model) {
		Transform prev = null;
		foreach (GameObject sphere in selectedSpheres) {
			Transform curr = null;
			switch (sphere.transform.name) {
			case "TL":
				curr = model.transform.Find ("UL");
				break;
			case "TR":
				curr = model.transform.Find ("UR");
				break;
			case "MM":
				curr = model.transform.Find ("M");
				break;
			case "BL":
				curr = model.transform.Find ("LL");
				break;
			case "BR":
				curr = model.transform.Find ("LR");
				break;
			}
			curr.GetComponentInChildren<Select> ().isSelected = true;
			if (prev != null && prev != curr) {
				modelLines.Add(drawLine (prev.position, curr.position, Color.red, false));
			}
			prev = curr;
			// reset point for new pattern
			sphere.GetComponent<Select> ().isSelected = false;
		}
	}

	void saveModel() {
		if (models.Count < 27) {
			GameObject model = (GameObject)Instantiate (Resources.Load ("Point Model"));
			Vector3 orig = model.transform.position;
			orig.x -= modelOffsetX;
			orig.y -= modelOffsetY;
			model.transform.position = orig;
			modelOffsetX += 0.5f;
			models.Add (model);
			if (models.Count % 9 == 0) {
				modelOffsetY += 0.5f;
				modelOffsetX = 0.0f;
			}

			transferSelectionToModel (model);

			resetTestModel();
		}
	}

	void select() {
		if (selectedSpheres.Count > 0) {
			if (highlightedSphere != null) {
				highlightedSphere.GetComponent<Select> ().isSelected = true;
				GameObject line = drawLine (selectedSpheres.Last().transform.position, highlightedSphere.transform.position, Color.red, true);
				sphereLines.Add (line);
				selectedSpheres.Add (highlightedSphere);
			}
		} else {
			if (highlightedSphere != null) {
				highlightedSphere.GetComponent<Select> ().isSelected = true;
				selectedSpheres.Add (highlightedSphere);
			}
		}
	}

	void undoSelect() {
		selectedSpheres.Last ().GetComponent<Select> ().isSelected = false;
		selectedSpheres.RemoveAt (selectedSpheres.Count-1);

		Destroy (sphereLines.Last());
		sphereLines.RemoveAt (sphereLines.Count-1);
	}

	GameObject drawLine(Vector3 start , Vector3 end, Color color, bool large){

		GameObject line = new GameObject ();
		line.transform.position = start;
		line.AddComponent<LineRenderer> ();
		LineRenderer lr = line.GetComponent<LineRenderer> ();
		lr.material = (Material)Resources.Load("Materials/red");
		if (large) {
			lr.SetWidth (0.05f, 0.05f);
		} else {
			lr.SetWidth (0.025f, 0.025f);
		}
		lr.SetPosition (0, start);
		lr.SetPosition (1, end);

		return line;
	}

	IEnumerator countdown() {
		while (min > 0 || sec >= 0) {
			if (sec > 0) {
				sec--;
			} else {
				sec = 59;
				min--;
			}
			timer.text = string.Format ("{0:00}:{1:00}", min, sec);
			yield return new WaitForSeconds (1);
		}
	}
}

