using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveScript : MonoBehaviour
{
    // the f denotes its a float (5.0)
    public float moveSpeed = 500f;

    // what's rigidBody2D again? gives physics to object (makes it fall off-screen)

    // Update is called once per frame
    void Update()
    {
        // this is simply a vector object:
        Vector3 moveDirection = Vector3.zero;       // shorthand for: (0, 0, 0)

        float gameObjectY = transform.position.y;
        float gameObjectX = transform.position.x;

        if (Input.GetKey(KeyCode.W))
        {
            moveDirection += Vector3.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection += Vector3.left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDirection += Vector3.down;
        }  
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection += Vector3.right;
        }

        transform.position += moveDirection.normalized * moveSpeed * Time.deltaTime;

    }
}
