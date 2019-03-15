using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    //Pieces of asteroids to spawn
    public GameObject[] asteroidPieces;
    public int spawnAmount = 4;
    public float maxVelocity = 3f;

    //Spawn a random asteroid in a random direction
    void Spawn()
    {
        //Generate random index into asteroid pieces array
        int randomIndex = Random.Range(0, asteroidPieces.Length);

        //Select random asteroid piece
        GameObject astroidPiece = asteroidPieces[randomIndex];

        //Ask the Asteroid Manager to spawn a new asteroid piece at a position
        AsteroidManager.Spawn(astroidPiece, transform.position);
    }

    //Spawns Asteroid pieces when Asteroid gets destroyed
    public void Destroy()
    {
        //Destroy self
        Destroy(gameObject);

        //If there are assigned asteroid pieces
        if (asteroidPieces.Length > 0)
        {
            //Spawn an asteroid
            Spawn();
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
