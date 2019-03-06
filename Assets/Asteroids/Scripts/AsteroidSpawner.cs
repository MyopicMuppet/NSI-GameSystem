using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{

    public class AsteroidSpawner : MonoBehaviour
    {

        // Array of prefabs to spawn
        public GameObject[] asteroidPrefabs;
        // Rate of spawn (in seconds)
        public float spawnRate = 1f;
        // Distance to spawn each asteroid
        public float spawnRadius = 5f;

        void Spawn()
        {
            //Randomize a position within a circle
            Vector2 randomPos = Random.insideUnitCircle * spawnRadius;
            
            // Randomize a rotation for asteroid
            Quaternion randomRot = Quaternion.Euler(0, 0, Random.Range(0f, 360f));

            // Generate random index into asteroid prefabs array
            int randomIndex = Random.Range(0, asteroidPrefabs.Length);

            // Get random asteroid prefab from array using index
            GameObject randomAsteroid = asteroidPrefabs[randomIndex];

            // Spawn random asteroid at random position and default Quaternion
            Instantiate(randomAsteroid, randomPos, randomRot);


        }
        // Use this for initialization
        void Start()
        {
            // Repeatedly call the spawn function
            InvokeRepeating("Spawn", 0, spawnRate);

        }

        // Draws debug elements for testing
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, spawnRadius);
        }
    }

}