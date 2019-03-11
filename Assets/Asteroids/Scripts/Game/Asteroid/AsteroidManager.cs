﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{

    public class AsteroidManager : MonoBehaviour
    {

        // Array of prefabs to spawn
        public GameObject[] asteroidPrefabs;
        // Max velocity an asteroid can move
        public float maxVelocity = 3f;
        // Rate of spawn (in seconds)
        public float spawnRate = 1f;
        // Distance to spawn each asteroid
        public float spawnPadding = 2f;
        public Color debugColor = Color.cyan;

        public void Spawn(GameObject prefab, Vector3 position)
        {
            // Randomize a rotation for asteroid
            Quaternion randomRot = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));

            // Spawn random asteroid at random position and default Quaternion
            GameObject asteroid = Instantiate(prefab, position, randomRot, transform);

            // Get Rigidbody2d from asteroid
            Rigidbody2D rigid = asteroid.GetComponent<Rigidbody2D>();

            // Apply random force to rigidbody
            Vector2 randomForce = Random.insideUnitCircle * maxVelocity;
            rigid.AddForce(randomForce, ForceMode2D.Impulse);



        }

        // Spawns a random asteroid in the array at a random position
        void SpawnLoop()
        {
            // Get camera's bounds using Extension Method
            Bounds camBounds = Camera.main.GetBounds(spawnPadding);

            // Randomize a position within a circle
            Vector2 randomPos = camBounds.GetRandomPosOnBounds();

            // Generate random index into asteroid prefabs array
            int randomIndex = Random.Range(0, asteroidPrefabs.Length);

            // Get random asteroid prefabs from array using index
            GameObject randomAsteroid = asteroidPrefabs[randomIndex];

            // Spawn using random pos
            Spawn(randomAsteroid, randomPos);
        }
        // Use this for initialization
        void Start()
        {
            // Repeatedly call the spawn function
            InvokeRepeating("SpawnLoop", 0, spawnRate);

        }

        // Draws debug elements for testing
        private void OnDrawGizmos()
        {
            Bounds camBounds = Camera.main.GetBounds(spawnPadding);
            Gizmos.color = debugColor;
            Gizmos.DrawWireCube(camBounds.center, camBounds.size); 
        }
    }

}