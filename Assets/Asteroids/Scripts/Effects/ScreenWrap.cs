using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrap : MonoBehaviour
{

    // Padding around the screen for screen wrapping
    public float padding = 3f;
    // Colour of gizmos
    public Color debugColor = Color.blue;

    // Reference to sprite renderer
    private SpriteRenderer SpriteRenderer;

    //Awake runs before start
    private void Awake()
    {
        // Get reference to sprite renderer
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    //Draws Gizmos for debugging
    private void OnDrawGizmos()
    {
        // Get the bounds around the cameras with given padding
        Bounds camBounds = Camera.main.GetBounds(padding);
        // Then Draw the Camera Bounds
        Gizmos.color = debugColor;
        Gizmos.DrawWireCube(camBounds.center, camBounds.size);
    }

    // Updates position of entity (GameObject this script is attahed to)
    void UpdatePosition()
    {
        // Get the Camera Dimensions using padding
        Bounds camBounds = Camera.main.GetBounds(padding);
        // Store position and size in a shorter variable name
        Vector3 pos = transform.position;
        // Store min and max vectors
        Vector3 min = camBounds.min;
        Vector3 max = camBounds.max;
        // Check left
        if (pos.x < min.x)
        {
            pos.x = max.x;
        }
        // Check right
        if (pos.x > max.x)
        {
            pos.x = min.x;
        }

        // Check up
        if (pos.y < min.y)
        {
            pos.y = max.y;
        }

        // Check down
        if (pos.y > max.y)
        {
            pos.y = min.y;
        }
        // Apply position
        transform.position = pos;

    }

    // Update is called once per frame
    private void LateUpdate()
    {
        // Update the player's position
        UpdatePosition();
    }


}
