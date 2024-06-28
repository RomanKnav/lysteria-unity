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
    public LineController logic;    // if given filename that doesn't exist in project, error. How does it know LineController exists? Who cares, it works.

    // what's rigidBody2D again? gives physics to object (makes it fall off-screen)

    private Camera mainCamera;
    private float cameraBottom;
    private float cameraTop;
    private float cameraLeft;
    private float cameraRight;


    // Start is called before the first frame update
    void Start()
    {

        // TODO: get reference to lineRenderer obj/component:   
        logic = GameObject.FindGameObjectWithTag("lineRend").GetComponent<LineController>();

        mainCamera = Camera.main;

        cameraTop = mainCamera.transform.position.y + mainCamera.orthographicSize;
        cameraBottom = mainCamera.transform.position.y - mainCamera.orthographicSize;
        cameraLeft = mainCamera.transform.position.x - mainCamera.orthographicSize * mainCamera.aspect;
        cameraRight = mainCamera.transform.position.x + mainCamera.orthographicSize * mainCamera.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        float gameObjectY = transform.position.y;
        float gameObjectX = transform.position.x;


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
