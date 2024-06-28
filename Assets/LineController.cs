using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Used by Line Renderer game obj. WHAT EXACTLY DOES THIS DO? sets up the points to draw the line at. 
public class LineController : MonoBehaviour
{
    private LineRenderer lr;    // line renderer reference.
    // how is the line renderer component passed here?

    // [SerializeField] could I use this to give player access to points?
    private Transform[] points; // what's this? an array of "Transform" objects (reference for the points for our lines)
    /* The Transform class is a built-in Unity class that represents the position, rotation, and 
     * scale of an object in the scene. Each Transform is associated with a GameObject. */

    // MY OWN SHIT: 
    private Vector3[] positions;

    public void UpdatePositions(Vector3[] newPositions)
    {
        positions = newPositions;
    }

        public Vector3[] GetPositions()
    {
        return positions;
    }


    // gets the object's component. So what's LineRenderer above? Simply declares the variable TYPE.
    // HERE WE'VE GOT ANOTHER SPECIAL METHOD:  part of the MonoBehaviour class. 
    private void Awake()
    {
        // THIS grabs the gameObject's LineRenderer component!!!
        lr = GetComponent<LineRenderer>();      // this has a given num of "positions" that make up the line
    }

    // what's this func do? the points are passed in via LineTesting.cs (where func is used):
    public void SetUpLine(Transform[] points)   // arr of transform components? Yes. This doesn't take in already defined "points" -just name of parameter
    {
        // is this a custom var? Nope. Line Renderer property
        // REMEMBER: length of arr must be defined before adding stuff into it.
        lr.positionCount = points.Length;   // "positionCount" property Specifies the number of points (vertices) that make up the line.
        // positionCount is property of LineRenderer component. Sets the number of positions (vertices) in the LineRenderer
        this.points = points;               // WE ARE USING FUCKING THIS??? Why are we using this? 
        // I understand: sets points defined at 11 to the points given here!
    }
    // confused by this func again. Are we setting the length of positionCount? Yes.

    // where's this used again? REMEMBER: Update() doesn't need to be manually used. IT'S AUTOMATICALLY CALLED EVERY FRAME:
    private void Update()
    {
        for (int i = 0; i < points.Length; i++)
        {
            // Line Renderer SetPosition() method: used to set the position of a specific vertex in a line
            // THIS IS RESPONSIBLE for adding values in "Positions" property:
            lr.SetPosition(i, points[i].position);      // .position is a Vector3: (0, 0, 0)

            /* this func is responsible for the "Positions" arr seen in the Line Renderer comp, composed of an index and (X, Y, Z) coords.          
    
            */
        }
    }
}

// WTF ARE TRANSFORM OBJS? Not objects, COMPONENTS. The very first one that ALL game objects have, lmfao.
