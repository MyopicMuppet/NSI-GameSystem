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
            //Randomize a position
            Vector2 rand = Random.insideUnitCircle * spawnRadius;
            //Offset position from spawner location
            Vector2 position = (Vector2)transform.position + rand;
            // Generate a random index into prefab array
            int randIndex = Random.Range(0, asteroidPrefabs.Length);
            // Get random asteroid using index
            GameObject randAsteroid = asteroidPrefabs[randIndex];
            // Clone random asteroid
            Instantiate(randAsteroid, position, Quaternion.identity);


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

}