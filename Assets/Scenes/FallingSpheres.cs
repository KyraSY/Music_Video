using System.Collections;
using UnityEngine;

public class FallingSpheres : MonoBehaviour
{
    public GameObject spherePrefab; // Assign in Inspector
    public int spawnCount = 10; // Number of spheres to spawn
    public float spawnHeight = 10f; // Height above ground where they spawn
    public float spawnRadius = 5f; // Area in which they spawn
    public float spawnInterval = 1f; // Time between each spawn
    public float sphereLifetime = 5f; // Time before spheres are destroyed
    public int offset = 0;

    void Start()
    {
        StartCoroutine(SpawnSpheres());
    }

    IEnumerator SpawnSpheres()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            SpawnSphere();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnSphere()
    {
        // Generate a random position within a circular area
        Vector3 spawnPosition = new Vector3(
            Random.Range(-spawnRadius + offset, spawnRadius + offset),
            spawnHeight, // Spawn above ground
            Random.Range(-spawnRadius, spawnRadius)
        );

        // Instantiate the sphere
        GameObject sphere = Instantiate(spherePrefab, spawnPosition, Quaternion.identity);

        // Ensure it has a Rigidbody to fall
        if (!sphere.GetComponent<Rigidbody>())
        {
            sphere.AddComponent<Rigidbody>();
        }

        // Destroy the sphere after 'sphereLifetime' seconds
        Destroy(sphere, sphereLifetime);
    }
}
