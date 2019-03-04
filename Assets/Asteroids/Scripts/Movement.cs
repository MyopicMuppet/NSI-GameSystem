using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Units to travel per second
    public float speed = 20f;
    // Amount of rotation per second

    // Reference to attached Rigidbody2D
    private Rigidbody2D rigid;

    public float rotationSpeed = 360f;
    // Use this for initialization
    void Start()
    {
        // Grab reference to rigidbody2d component
        // NOTE: It gets this from the GameObject this script is attached to
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if A key is pressed
        if (Input.GetKey(KeyCode.A))
        {
            //Rotate left
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        }

        // Check if D key is pressed
        if (Input.GetKey(KeyCode.D))
        {
            // Rotate Right
            transform.Rotate(Vector3.forward, -rotationSpeed * Time.deltaTime);
        }

        // Check if W is pressed
        if (Input.GetKey(KeyCode.W))
        {
            // Move in facing direction
            rigid.AddForce(transform.up * speed);
        }

        // Check if S key is pressed
        if (Input.GetKey(KeyCode.S))
        {
            // Move in facing direction
            rigid.AddForce(-transform.up * speed);
        }

    }
}
