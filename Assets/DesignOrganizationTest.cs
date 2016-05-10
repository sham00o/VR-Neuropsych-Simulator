using UnityEngine;
using System.Collections;

public class DesignOrganizationTest : MonoBehaviour {
    public GameObject[] initial;
    public GameObject[][] example;
    public GameObject[][] testA;
    public Rigidbody box;
    bool exampleFlag = false;
    bool testAflag = false;
    bool testBflag = false;
    bool noFlags = true;
    // Use this for initialization
    //TODO:
    //move coordinates to a proper room/space, can be done last.
    //set z coordinate so it is moved back properly
    //replace the spheres with the blender squares
    //after, decide whether this is random or not for square configurations, i think it should be in a set order like the handout
    //after the test, decide to output all squares or not at the end
    //TIME THIS from testA to end, two minute test.
	void Start () { 
        initial = new GameObject[6];
        example = new GameObject[3][];
        testA = new GameObject[4][];
        init();
        example_init();
        disappear_ex();
        testA_init();
        disappear_A();

       
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.B) && exampleFlag)
        {
            disappear_ex();
            appear_A();
            testAflag = true;
            exampleFlag = false;

        }
        if (Input.GetKeyDown(KeyCode.B) && noFlags){
            disappear_init();
            noFlags = false;
            exampleFlag = true;
            appear_ex();
        }
       
	}
    void init()
    {
        int len = 6;
        int i = 0;
        for(; i < len; i++)
        {
            initial[i] = GameObject.CreatePrimitive(PrimitiveType.Sphere);//new GameObject()
            initial[i].transform.position = new Vector3(-5+i, 7, -13);
        }
    }
    void disappear_init()
    {
        for (int i = 0; i <6; i++)
        {
            initial[i].active = false;
        }
    }
    void example_init()
    {   int seed = -3;
        int len = 3;
        int top = 9;
        int z = -13;
        for(int i = 0; i < len; i++)
        {
            example[i] = new GameObject[4];
            for(int j = 0; j < 4; j++)
            {
                example[i][j] = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                if( j % 2 == 0)
                {
                    example[i][j].transform.position = new Vector3(-5 + (i*2.5f) + j/2, top-1, z);
                }
                else
                {
                    example[i][j].transform.position = new Vector3(-5 + (i*2.5f) +j/2, top, z);
                }
            }
        }
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
    }

    void testA_init() // for now just spawning the 3x3's, four of them. TODO: add the smaller 4x4 squares on top.
    {
        int len = 4;
        int top = 9;
        int z = -13;
        int x = -6;
        for(int i = 0; i < len; i++)
        {
            testA[i] = new GameObject[9];
            for(int j = 0; j < 9; j++)
            {
                testA[i][j] = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                if(j % 3 == 0)
                {
                    testA[i][j].transform.position = new Vector3(x + (i * 3.5f) + (j) / 3, top - 2, z);
                }
                else if (j %3 == 1)
                {
                    testA[i][j].transform.position = new Vector3(x + (i * 3.5f) + (j) / 3, top - 1, z);
                }
                else
                {
                    testA[i][j].transform.position = new Vector3(x + (i * 3.5f) + (j) / 3, top, z);

                }
            }
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
    }
}
