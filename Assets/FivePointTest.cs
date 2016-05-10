using UnityEngine;
using System.Collections;

public class FivePointTest : MonoBehaviour {
    public class dot {
        public int edge { get; set; }
        public int num { get; set; }
        //representing this with a test object for now
    }
    public class edge
    {
        public dot n1; // lower number goes into here
        public dot n2;
        public int eType; // 0 is left |, 1 is top --, 2 is right |, 3 is bottom --, 4 is /, 5 is \
    }
    public class figure
    {
        dot num0 = new dot { edge = 0, num = 0 }; // bottom-left
        dot num1 = new dot { edge = 0, num = 1 }; //top-left
        dot num2 = new dot { edge = 0, num = 2 }; //top-right
        dot num3 = new dot { edge = 0, num = 3 }; // bottom-right
        dot num4 = new dot { edge = 0, num = 4 }; //middle dot
  

    }

    //make a structure that has five points
    //mke it compatable with edges
    //make is so when you click  a dot that dot is selected
    // and when you click another dot,( unless its itself, in which case it is deselected)
    //then it connects an edge to the dot , if the edge is already connected do nothing
    //be able to click somewhere else, if that happens then the data with the dots is saved
    //and a new set of dots takes its place
    //have a tutorial in the beginning to set it up
    //then on keypress it starts
    // struct with dots to make iut appear at the end.
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    edge createEdge(dot d1, dot d2)
    { // do a check to see if d1 == d2, if it does this function is skipped, check if edge exists as well.
        edge ret;
        if (d2.num < d1.num)
        {
            ret = new edge { n1 = d2, n2 = d1 };
        }
        else
        {
            ret = new edge { n1 = d1, n2 = d2 };
        }
        
        return ret;
        
    }
    void edgeType(edge e) // four types, horizontal, vertical, right-inclinded /, left-inclined \
    {
        if(e.n1.num == 0 && e.n2.num == 1)
        {
            e.eType = 0;
            return;
        }
        else if (e.n1.num == 2 && e.n2.num == 3)
        {
            e.eType = 2;
            return;
        }
        else if (e.n1.num == 1 && e.n2.num == 2)
        {
            e.eType = 1;
            return;
        }
        else if (e.n1.num == 0 && e.n2.num == 3)
        {
            e.eType = 3;
        }
        else if (e.n1.num == 0 && e.n2.num == 2)
        {
            e.eType = 4;
            return;
        }
        else if (e.n1.num == 1 && e.n2.num == 3)
        {
            e.eType = 6;
            return;
        }
        return;
    }
    void edge_orient(edge e) // spawns the lines based on eType
    {
        //or just draw lines from each dot to the next
    }

}

