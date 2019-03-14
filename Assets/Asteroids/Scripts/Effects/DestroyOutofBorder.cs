﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutofBorder : MonoBehaviour {

    //Padding from bounds to destroy object
    public float padding = 10f;
    public Color debugColor = Color.red;

    private void OnDrawGizmos()
    {
        Bounds camBounds = Camera.main.GetBounds(padding);
        Gizmos.color = debugColor;
        Gizmos.DrawWireCube(camBounds.center, camBounds.center, camBounds.size);
    }

  
	// Update is called once per frame
	void Update ()
    {
        //Get Camera Bounds with Padding
        Bounds camBounds = Camera.main.GetBounds(padding);
        //If position is out of bounds
        if (!camBounds.Contains(transform.position))
        {
            //Destroy it
            Destroy(gameObject);
        }
	}
}
