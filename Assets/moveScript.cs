using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

// RESPONSIBLE FOR PLAYER MOVEMENT:
public class moveScript : MonoBehaviour
{
    // the f denotes its a float (5.0)
    // this the only public var we have, so it actually shows in Inspector:
    public float moveSpeed = 500f;

    // what's rigidBody2D again? gives physics to object (makes it fall off-screen)

    private Camera mainCamera;
    private float cameraBottom;
    private float cameraTop;
    private float cameraLeft;
    private float cameraRight;

    // LINE STUFF:
    public LineController logic;    // if given filename that doesn't exist in project, error. How does it know LineController exists? Who cares, it works.
    // ^ why's this public?
    private LineRenderer lineRenderer;  // reference to obj's LineRenderer component. 

    private int currPoint = 0;      // refers to INDEX, not actual coord.

    // this is called BEFORE the game plays.
    void Awake() {
        // TODO: get reference to lineRenderer obj/component:  
        // need reference to Line Renderer component and it's positionCount property: 
        // reference to GAME OBJECT ITSELF:
        GameObject lineRendObject = GameObject.FindGameObjectWithTag("lineRend");   // game obj reference

        logic = lineRendObject.GetComponent<LineController>();          // script reference
        lineRenderer = lineRendObject.GetComponent<LineRenderer>();     // LineRenderer reference
    }

    // Start is called before the first frame update (and before Awake())
    void Start()
    {

        mainCamera = Camera.main;

        cameraTop = mainCamera.transform.position.y + mainCamera.orthographicSize;
        cameraBottom = mainCamera.transform.position.y - mainCamera.orthographicSize;
        cameraLeft = mainCamera.transform.position.x - mainCamera.orthographicSize * mainCamera.aspect;
        cameraRight = mainCamera.transform.position.x + mainCamera.orthographicSize * mainCamera.aspect;

        if (lineRenderer.positionCount > 0)
        {
            Vector3 position = lineRenderer.GetPosition(currPoint);
            Debug.Log($"Setting initial player position to: {position}");
            transform.position = position;          // why doesn't this work?
        }
        else
        {
            Debug.LogError("LineRenderer is null or has no positions.");
        }

        // now seems I need to access "points". I'd like to create custom arr property containing them.
        // I need to access LR's Positions arr (composed of point's Transform comps)
    }

    // Update is called once per frame
    void Update()
    {
        float gameObjectY = transform.position.y;
        float gameObjectX = transform.position.x;

        // maybe something like this:
        // if (logic != null)
        // {
        //     positions = logic.GetPositions();
        // }

        // putting this in Awake() and Start() prints the old values:
        if (lineRenderer != null)
        {
            int positionCount = lineRenderer.positionCount;     // with current setup, this is 3.
            // for loop simply prints all position coords. This prints the correct coords:
            for (int i = 0; i < positionCount; i++)
            {
                Vector3 position = lineRenderer.GetPosition(i);
                // Do something with each position
                Debug.Log($"Position {i}: {position}");
            }
        }


        // this is simply a vector object:
        Vector3 moveDirection = Vector3.zero;       // shorthand for: (0, 0, 0)

        if (Input.GetKey(KeyCode.W) && gameObjectY < cameraTop)
        {
            moveDirection += Vector3.up;
        }
        if (Input.GetKey(KeyCode.A) && gameObjectX > cameraLeft)
        {
            moveDirection += Vector3.left;
        }
        if (Input.GetKey(KeyCode.S) && gameObjectY > cameraBottom)
        {
            moveDirection += Vector3.down;
        }
        if (Input.GetKey(KeyCode.D) && gameObjectX < cameraRight)
        {
            moveDirection += Vector3.right;
        }
        

        transform.position += moveDirection.normalized * moveSpeed * Time.deltaTime;

        // this will run THOUSANDS OF TIMES, like in JS:
        // Debug.Log("Hello, World!");
    }
}
