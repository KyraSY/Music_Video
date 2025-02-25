using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioReactiveSine : MonoBehaviour
{
    public int sphereCount = 20; // Number of spheres in the sine wave
    public float waveSpeed = 5f; // Speed of wave movement
    public float frequency = 1f; // Frequency of the sine wave
    public float amplitude = 2f; // Amplitude of the sine wave
    public GameObject spherePrefab;
    public AudioSource audioSource; 

    private GameObject[] spheres;
    private float timeOffset = 0f;
    private float[] audioSpectrum = new float[64]; 
    public int height = 0;

    void Start()
    {
        // Instantiate spheres
        spheres = new GameObject[sphereCount];
        for (int i = 0; i < sphereCount; i++)
        {
            spheres[i] = Instantiate(spherePrefab, transform);
        }
    }

    void Update()
    {
        timeOffset += Time.deltaTime * waveSpeed; // Move wave to the right

        for (int i = 0; i < sphereCount; i++)
        {
            float x = i * 3f; // Spacing between spheres
            float y = amplitude * Mathf.Sin((x + timeOffset) * frequency); // Sine wave with audio effect
            float z = 0f; // Keep spheres in a straight line

            spheres[i].transform.position = new Vector3(x, y + height, z);
        }
    }
}

