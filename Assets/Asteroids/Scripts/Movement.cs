﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Units to travel per second
    public float movementSpeed = 20f;
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

    // Control is a custom made function to handle movement
    private void Control()
    {
        // If the W key is pressed
        if (Input.GetKey(KeyCode.W))
        {
            // Add a force up
            rigid.AddForce(transform.up * movementSpeed);
        }

        //If the S key is pressed
        if (Input.GetKey(KeyCode.S))
        {
            rigid.AddForce(-transform.up * movementSpeed);
        }

        // If the A key is pressed
        if (Input.GetKey(KeyCode.A))
        {
            rigid.rotation += rotationSpeed * Time.deltaTime;
        }

        // If D key is presssed
        if (Input.GetKey(KeyCode.D))
        {
            rigid.rotation -= rotationSpeed * Time.deltaTime;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Control();

    }
}
