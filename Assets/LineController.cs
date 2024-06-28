using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    private LineRenderer lr;    // line renderer reference
    private Transform[] points; // what's this? an array of "Transform" objects (reference for the points for our lines)
    /* The Transform class is a built-in Unity class that represents the position, rotation, and 
     * scale of an object in the scene. Each Transform is associated with a GameObject. */

    // gets the object's component. So what's LineRenderer above? Simply declares the variable TYPE.
    // HERE WE'VE GOT ANOTHER SPECIAL METHOD:  part of the MonoBehaviour class. 
    private void Awake()
    {
        lr = GetComponent<LineRenderer>();      // this has a given num of "positions" that make up the line
    }

    // what's this func do? Custom func (used in linTesting) gets array of points to store (sets number of points so LineRenderer knows how many lines to draw):
    public void SetUpLine(Transform[] points)   // arr of transform components? Yes.
    {
        // is this a custom var?
        lr.positionCount = points.Length;   // "positionCount" property Specifies the number of points (vertices) that make up the line.
        // positionCount is property of LineRenderer component. Sets the number of positions (vertices) in the LineRenderer
        this.points = points;               // WE ARE USING FUCKING THIS??? Why are we using this? 
        // Store the reference to the array of Transform objects in the class-level field (???)
    }

    private void Update()
    {
        for (int i = 0; i < points.Length; i++)
        {
            lr.SetPosition(i, points[i].position);
        }
    }
}

// WTF ARE TRANSFORM OBJS? Not objects, COMPONENTS. The very first one that ALL game objects have, lmfao.
