using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class DesignOrganizationTest : MonoBehaviour {
    public GameObject[] initial;
    public GameObject[][] example;
    public GameObject[][] testA;
    public GameObject[][] testA_small;
    public Rigidbody box;
	List<GameObject> exampleEntries, testEntries;
	GameObject highlightedBox, selectedBox;
    bool exampleFlag = false;
    bool testAflag = false;
    bool testBflag = false;
    bool noFlags = false;
    bool noFlagspre = true;
	bool isSelecting = false;

    // Use this for initialization
    //TODO:
    //move coordinates to a proper room/space, can be done last.
    //set z coordinate so it is moved back properly
    //replace the spheres with the blender squares
    //after, decide whether this is random or not for square configurations, i think it should be in a set order like the handout
    //after the test, decide to output all squares or not at the end
    //TIME THIS from testA to end, two minute test.
	void Start () {
<<<<<<< HEAD
		Random rnd = new Random ();
=======
		highlightedBox = null;
		selectedBox = null;
		exampleEntries = new List<GameObject> ();
		testEntries = new List<GameObject> ();
>>>>>>> origin/master
        initial = new GameObject[6];
        example = new GameObject[3][];
        testA = new GameObject[4][];
        testA_small = new GameObject[5][];
        init();
		disappear_init();
        example_init();
        disappear_ex();
		int num = random_num();
		testA_init(num);
        disappear_A();
        testA_small_init(num);
        disappear_A_small();
        //make a random number 0(A) or 1(B)

	}
	
	// Update is called once per frame
	void Update () {

       if(Input.GetKeyDown(KeyCode.B) && testAflag)
        {
			disappear_init ();
            disappear_A();
            disappear_A_small();
            testAflag = false;
            noFlagspre = true;
        }
        if (Input.GetKeyDown(KeyCode.B) && exampleFlag)
        {
            disappear_ex();
            appear_A();
            appear_A_small();
            testAflag = true;
            exampleFlag = false;
        }
        if (Input.GetKeyDown(KeyCode.B) && noFlags){
            noFlags = false;
            exampleFlag = true;
            appear_ex();
			show_board (false);
        }
		if (Input.GetKeyDown(KeyCode.B) && noFlagspre){
			appear_init ();
            noFlags = true;
            noFlagspre = false;
        }

		if (Input.GetKeyDown ("1") && isSelecting) {
			TextMesh curr = selectedBox.transform.Find ("Number").GetComponent<TextMesh> ();
			string num = curr.text;
			switch (num) {
			case "":
				curr.text = "1";
				break;
			case "1":
				curr.text = "2";
				break;
			case "2":
				curr.text = "3";
				break;
			case "3":
				curr.text = "4";
				break;
			case "4":
				curr.text = "5";
				break;
			case "5":
				curr.text = "6";
				break;
			case "6":
				curr.text = "";
				break;
			}
		}

		if (Input.GetKeyDown ("t")) {
			select ();
		}

		Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit)) {
			string target = hit.transform.name;
			if (target == "Box") {
				if (highlightedBox == null) {
					highlightedBox = hit.collider.gameObject;
				}
				highlightedBox.GetComponent<Select> ().isHighlighted = false;
				highlightedBox = hit.collider.gameObject;
				hit.collider.gameObject.GetComponent<Select> ().isHighlighted = true;
			}
		}
	}

	void select() {
		if (highlightedBox != null) {
			isSelecting = true;
			if (selectedBox != null)
				selectedBox.GetComponent<Select> ().isSelected = false;
			selectedBox = highlightedBox;
			selectedBox.GetComponent<Select> ().isSelected = true;
		} else {
			isSelecting = false;
			selectedBox.GetComponent<Select> ().isSelected = false;
			selectedBox = null;
		}
	}

	void show_board(bool active) {
		GameObject.Find ("Board").SetActive (active);
	}


    void init()
    {
		initial[0] = (GameObject)Instantiate (Resources.Load ("Block 1"));
		initial[1] = (GameObject)Instantiate (Resources.Load ("Block 2"));
		initial[2] = (GameObject)Instantiate (Resources.Load ("Block 3"));
		initial[3] = (GameObject)Instantiate (Resources.Load ("Block 4"));
		initial[4] = (GameObject)Instantiate (Resources.Load ("Block 5"));
		initial[5] = (GameObject)Instantiate (Resources.Load ("Block 6"));
		/*  int len = 6;
        int i = 0;
        for(; i < len; i++)
        {
            float j = .0f;
            initial[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);//new GameObject()
            initial[i].transform.localScale = new Vector3(.2f, .2f, .2f);
            initial[i].transform.position = new Vector3(0.5f-(float)i/2, 11, -12);
            j++;
        }
        assign_shade(initial[0], "block1");
        assign_shade(initial[1], "block2");
        assign_shade(initial[2], "block3");
        assign_shade(initial[3], "block4");
        assign_shade(initial[4], "block5");
        assign_shade(initial[5], "block6"); */
    }
    void disappear_init()
    {
        for (int i = 0; i <6; i++)
        {
            initial[i].active = false;
        }
    }
    void appear_init()
    {
        for (int i = 0; i < 6; i++)
        {
            initial[i].active = true;
        }
    }
    void example_init()
    {   
        int len = 3;
        float top = 10.9f;
        int z = -11;
        float x = 0.2f;
        for(int i = 0; i < len; i++)
        {
            example[i] = new GameObject[4];
            float currx = 0;
            for (int j = 0; j < 4; j++)
            {
                example[i][j] = GameObject.CreatePrimitive(PrimitiveType.Cube);
                //Renderer r = example[i][j].GetComponent<Renderer>();
                example[i][j].transform.localScale = new Vector3(.2f, .2f, .2f);
                //r.material.mainTexture = Resources.Load("block2") as Texture;
                //Texture2D t = (Texture2D)Resources.Load("block2", typeof(Texture2D));
                // r.material.mainTexture = t;
                if ( j % 2 == 0)
                {
					example[i][j].transform.position = new Vector3((x - (i * .5f) - j * .1f) - .4f, top-.2f, z);
                    currx = (x - (i * .5f) - j * .1f);
                }
                else
                {
                    example[i][j].transform.position = new Vector3(currx - .4f, top, z);
                    
                }
            }
			GameObject entry = (GameObject)Instantiate (Resources.Load ("2x2 Entry"));
			Vector3 entryPosition = example[i][0].transform.position;
			entryPosition.x -= 0.2f;
			entryPosition.y -= 0.25f;
			entry.transform.position = entryPosition;
			exampleEntries.Add (entry);
        }
        assign_shade(example[0][0], "block6");
        assign_shade(example[0][1], "block1");
        assign_shade(example[0][2], "block1");
        assign_shade(example[0][3], "block6");

        assign_shade(example[1][0], "block5");
        assign_shade(example[1][1], "block6");
        assign_shade(example[1][2], "block6");
        assign_shade(example[1][3], "block1");

        assign_shade(example[2][0], "block6");
        assign_shade(example[2][1], "block3");
        assign_shade(example[2][2], "block2");
        assign_shade(example[2][3], "block6");

    }
    void disappear_ex()
    {
        for(int i = 0; i <3; i++)
        {
            for(int j = 0; j < 4; j++)
            {
                example[i][j].active = false;
            }
        }
		foreach (GameObject entry in exampleEntries) {
			entry.SetActive (false);
		}
    }
    void appear_ex()
    {
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    example[i][j].active = true;
                }
            }
        }
		foreach (GameObject entry in exampleEntries) {
			entry.SetActive (true);
		}
    }


    //TODO: testA small, initing the small blocks, do the same for testB, basically just the example one done again.
    //testB will be testA_small + testA just with different shades assigned, can just modify this to reflect both
    void testA_small_init(int test)
    {
        
        int len = 5;
        float top = 12f;
        int z = -11;
        float x = .2f;
        for (int i = 0; i < len; i++)
        {
            testA_small[i] = new GameObject[4];
            float currx = 0;
            for (int j = 0; j < 4; j++)
            {
                testA_small[i][j] = GameObject.CreatePrimitive(PrimitiveType.Cube);
                //Renderer r = example[i][j].GetComponent<Renderer>();
                testA_small[i][j].transform.localScale = new Vector3(.2f, .2f, .2f);
                //r.material.mainTexture = Resources.Load("block2") as Texture;
                //Texture2D t = (Texture2D)Resources.Load("block2", typeof(Texture2D));
                // r.material.mainTexture = t;
                if (j % 2 == 0)
                {
					testA_small[i][j].transform.position = new Vector3((x - (i * .5f) - j * .1f) + 0.1f, top - .2f, z);
                    currx = (x - (i * .5f) - j * .1f);
                }
                else
                {
					testA_small[i][j].transform.position = new Vector3(currx + 0.1f, top, z);

                }
            }
			GameObject entry = (GameObject)Instantiate (Resources.Load ("2x2 Entry"));
			Vector3 entryPosition = testA_small[i][0].transform.position;
			entryPosition.x -= 0.2f;
			entryPosition.y -= 0.25f;
			entry.transform.position = entryPosition;
			testEntries.Add (entry);
        }
        if (test == 0)
        {
            assign_shade(testA_small[0][0], "block1");
            assign_shade(testA_small[0][1], "block5");
            assign_shade(testA_small[0][2], "block1");
            assign_shade(testA_small[0][3], "block6");

            assign_shade(testA_small[1][0], "block5");
            assign_shade(testA_small[1][1], "block1");
            assign_shade(testA_small[1][2], "block2");
            assign_shade(testA_small[1][3], "block1");

            assign_shade(testA_small[2][0], "block3");
            assign_shade(testA_small[2][1], "block2");
            assign_shade(testA_small[2][2], "block4");
            assign_shade(testA_small[2][3], "block5");

            assign_shade(testA_small[3][0], "block4");
            assign_shade(testA_small[3][1], "block6");
            assign_shade(testA_small[3][2], "block6");
            assign_shade(testA_small[3][3], "block5");

            assign_shade(testA_small[4][0], "block2");
            assign_shade(testA_small[4][1], "block1");
            assign_shade(testA_small[4][2], "block1");
            assign_shade(testA_small[4][3], "block3");


        }
        else
        {
            assign_shade(testA_small[0][0], "block6");
            assign_shade(testA_small[0][1], "block4");
            assign_shade(testA_small[0][2], "block4");
            assign_shade(testA_small[0][3], "block1");

            assign_shade(testA_small[1][0], "block6");
            assign_shade(testA_small[1][1], "block6");
            assign_shade(testA_small[1][2], "block3");
            assign_shade(testA_small[1][3], "block5");

            assign_shade(testA_small[2][0], "block3");
            assign_shade(testA_small[2][1], "block5");
            assign_shade(testA_small[2][2], "block4");
            assign_shade(testA_small[2][3], "block2");

            assign_shade(testA_small[3][0], "block3");
            assign_shade(testA_small[3][1], "block4");
            assign_shade(testA_small[3][2], "block5");
            assign_shade(testA_small[3][3], "block2");

            assign_shade(testA_small[4][0], "block2");
            assign_shade(testA_small[4][1], "block6");
            assign_shade(testA_small[4][2], "block6");
            assign_shade(testA_small[4][3], "block3");
        }

    }

    void testA_init(int test) // for now just spawning the 3x3's, four of them. TODO: add the smaller 4x4 squares on top.
    {
        int len = 4;
        float top = 10.9f;
        int z = -11;
        float x = 0.5f;
        for(int i = 0; i < len; i++)
        {
            testA[i] = new GameObject[9];
            float currx2 = 0;
            for (int j = 0; j < 9; j++)
            {
                
                testA[i][j] = GameObject.CreatePrimitive(PrimitiveType.Cube);
                testA[i][j].transform.localScale = new Vector3(.2f, .2f, .2f);
                if (j % 3 == 0)
                {
                    currx2 = (x - (i * 0.7f) - j * .06666666666666666666f); //x + (i * .5f) + (j) / 3;
                    testA[i][j].transform.position = new Vector3(currx2, top - .4f, z);
                    
                }
                else if (j %3 == 1)
                {
                    testA[i][j].transform.position = new Vector3(currx2, top - .2f, z);
                }
                else
                {
                    testA[i][j].transform.position = new Vector3(currx2, top, z);

                }
            }
			GameObject entry = (GameObject)Instantiate (Resources.Load ("3x3 Entry"));
			Vector3 entryPosition = testA[i][0].transform.position;
			entryPosition.x -= 0.2f;
			entryPosition.y -= 0.25f;
			entry.transform.position = entryPosition;
			testEntries.Add (entry);
        }
        //if(testa...., keep testA var name, if testB just assign different
        if (test == 0)
        {
            assign_shade(testA[0][0], "block2");
            assign_shade(testA[0][1], "block1");
            assign_shade(testA[0][2], "block5");

            assign_shade(testA[0][3], "block1");
            assign_shade(testA[0][4], "block6");
            assign_shade(testA[0][5], "block1");

            assign_shade(testA[0][6], "block4");
            assign_shade(testA[0][7], "block1");
            assign_shade(testA[0][8], "block3");

            assign_shade(testA[1][0], "block2");
            assign_shade(testA[1][1], "block3");
            assign_shade(testA[1][2], "block2");

            assign_shade(testA[1][3], "block3");
            assign_shade(testA[1][4], "block2");
            assign_shade(testA[1][5], "block3");

            assign_shade(testA[1][6], "block2");
            assign_shade(testA[1][7], "block3");
            assign_shade(testA[1][8], "block2");

            assign_shade(testA[2][0], "block3");
            assign_shade(testA[2][1], "block2");
            assign_shade(testA[2][2], "block4");

            assign_shade(testA[2][3], "block2");
            assign_shade(testA[2][4], "block3");
            assign_shade(testA[2][5], "block5");

            assign_shade(testA[2][6], "block5");
            assign_shade(testA[2][7], "block4");
            assign_shade(testA[2][8], "block2");

            assign_shade(testA[3][0], "block2");
            assign_shade(testA[3][1], "block1");
            assign_shade(testA[3][2], "block3");

            assign_shade(testA[3][3], "block5");
            assign_shade(testA[3][4], "block4");
            assign_shade(testA[3][5], "block6");

            assign_shade(testA[3][6], "block1");
            assign_shade(testA[3][7], "block3");
            assign_shade(testA[3][8], "block5");
        }
        else
        {
            assign_shade(testA[0][0], "block3");
            assign_shade(testA[0][1], "block1");
            assign_shade(testA[0][2], "block5");

            assign_shade(testA[0][3], "block1");
            assign_shade(testA[0][4], "block6");
            assign_shade(testA[0][5], "block1");

            assign_shade(testA[0][6], "block4");
            assign_shade(testA[0][7], "block1");
            assign_shade(testA[0][8], "block2");

            assign_shade(testA[1][0], "block6");
            assign_shade(testA[1][1], "block5");
            assign_shade(testA[1][2], "block1");

            assign_shade(testA[1][3], "block5");
            assign_shade(testA[1][4], "block1");
            assign_shade(testA[1][5], "block4");

            assign_shade(testA[1][6], "block1");
            assign_shade(testA[1][7], "block4");
            assign_shade(testA[1][8], "block6");

            assign_shade(testA[2][0], "block3");
            assign_shade(testA[2][1], "block2");
            assign_shade(testA[2][2], "block4");

            assign_shade(testA[2][3], "block2");
            assign_shade(testA[2][4], "block3");
            assign_shade(testA[2][5], "block5");

            assign_shade(testA[2][6], "block3");
            assign_shade(testA[2][7], "block2");
            assign_shade(testA[2][8], "block4");

            assign_shade(testA[3][0], "block4");
            assign_shade(testA[3][1], "block5");
            assign_shade(testA[3][2], "block1");

            assign_shade(testA[3][3], "block5");
            assign_shade(testA[3][4], "block6");
            assign_shade(testA[3][5], "block2");

            assign_shade(testA[3][6], "block1");
            assign_shade(testA[3][7], "block3");
            assign_shade(testA[3][8], "block5");
        }
    }
   void disappear_A()
    {
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    testA[i][j].active = false;
                }
            }
        }
		foreach (GameObject entry in testEntries) {
			entry.SetActive (false);
		}
    }
    void appear_A()
    {
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    testA[i][j].active = true;
                }
            }
        }
		foreach (GameObject entry in testEntries) {
			entry.SetActive (true);
		}
    }
    void appear_A_small()
    {
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    testA_small[i][j].active = true;
                }
            }
        }
		foreach (GameObject entry in testEntries) {
			entry.SetActive (true);
		}
    }
    void disappear_A_small()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                testA_small[i][j].active = false;
            }
        }
		foreach (GameObject entry in testEntries) {
			entry.SetActive (false);
		}
    }
    void assign_shade(GameObject a, string tex)
    {
        Renderer r = a.GetComponent<Renderer>();
        Texture2D t = (Texture2D)Resources.Load(tex, typeof(Texture2D));
        r.material.mainTexture = t;
		//r.material.color.a = 1.0f;
	}
	int random_num(){
		float val = Random.value;
		int ret;
		if (val < 0.5f) {
			ret = 0;
		} else {
			ret = 1;
		}
		return ret;
	}
}
