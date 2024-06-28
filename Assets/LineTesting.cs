using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// WHAT'S THIS DO?
public class LineTesting : MonoBehaviour
{
    // even though these are private, fields are still made for them in inspector. How?
    [SerializeField] private Transform[] points;     // quantity can be given in inspector
    [SerializeField] private LineController lines;   // reference to line to draw. THIS is a GAME OBJECT

    private void Start()
    {
        lines.SetUpLine(points);    // how the fuck is this accessed? Through the passed-in LineController object.
    }
}

