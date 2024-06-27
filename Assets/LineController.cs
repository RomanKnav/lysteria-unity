using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    private LineRenderer lr;
    private Transform[] points; // what's this? an array of "Transform" objects (points for our lines)
    /* The Transform class is a built-in Unity class that represents the position, rotation, and 
     * scale of an object in the scene. Each Transform is associated with a GameObject. */

    // gets the object's component. So what's LineRenderer above? Simply declares the variable TYPE.
    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    public void SetUpLine(Transform[] points)
    {
        lr.positionCount = points.Length;
        this.points = points;   // WE ARE USING FUCKING THIS???
    }

    private void Update()
    {
        for (int i = 0; i < points.Length; i++)
        {
            lr.SetPosition(i, points[i].position);
        }
    }
}
