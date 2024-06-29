using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// WHAT'S THIS DO?
public class lineTesting : MonoBehaviour
{
    // even though these are private, fields are still made for them in inspector. How? because [SerializeField]
    // I need to ensure that this arr gets populated before player is initialized:
    [SerializeField] private Transform[] points;     // quantity can be given in inspector
    // ^ this creates custom "Points" array in the script component, where we can drag our point objects. Accesses the Objs' Transform comp.
    [SerializeField] private LineController lines;   // reference to line to draw. THIS is a GAME OBJECT

    private void Start()
    {
        lines.SetUpLine(points);    // how the fuck is this accessed? Through the passed-in LineController object above.
        // remember: SetUpLine() takes arr of points (Transform components, which contain an obj's coords)
    }
}