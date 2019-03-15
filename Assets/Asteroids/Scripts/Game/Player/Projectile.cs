using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    //Travel speed of projectile
    public float speed = 10f;
    // Reference to ridgidbody
    private Rigidbody2D rigid;

    private void Awake()
    {
        // Get reference to Rigidbody
        rigid = GetComponent<Rigidbody2D>();
    }

    // Fire's this bullet in a given direction (using defined speed)
    public void Fire(Vector3 direction)
    {
        // Add force in the given direction by speed
        rigid.AddForce(direction * speed, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Try getting asteroid script from collision
        Asteroid asteroid = collision.GetComponent<Asteroid>();
        //If it is an asteroid
        if (asteroid)
        {
            //Destroy the Asteroid
            asteroid.Destroy();
            //Destroy the projectile
            Destroy(gameObject);
        }
    }
}
