using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomly : MonoBehaviour
{
    GameObject[] spheres;
    static int numSphere = 50;
    float time = 0f;
    Vector3[] initPos;

    public GameObject spherePrefab;
    public float scaleSpeed = 2f; // Controls the smoothness of scaling
    public int offset = 0;

    void Start()
    {
        spheres = new GameObject[numSphere];
        initPos = new Vector3[numSphere];

        for (int i = 0; i < numSphere; i++)
        {
            float r = 10f;
            spheres[i] = Instantiate(spherePrefab, transform);

            initPos[i] = new Vector3(r * Random.Range(-1.5f + offset, 1.5f + offset), r * Random.Range(-1f, 1f), 1f);
            spheres[i].transform.position = initPos[i];
        }
    }

    void Update()
    {
        if (AudioSpectrum.audioAmp == 0) return;

        time += Time.deltaTime * AudioSpectrum.audioAmp;

        for (int i = 0; i < numSphere; i++)
        {
            // Target scale based on audio amplitude, adjusted for smooth scaling
            float targetScale = Mathf.Clamp(0.2f + AudioSpectrum.audioAmp * 0.05f, 0.2f, 3f);

            // Smoothly interpolate towards the target scale
            float smoothScale = Mathf.Lerp(spheres[i].transform.localScale.x, targetScale, Time.deltaTime * scaleSpeed);

            spheres[i].transform.localScale = new Vector3(smoothScale, smoothScale, smoothScale);

            // Rotate dynamically based on audio intensity
            spheres[i].transform.Rotate(new Vector3(AudioSpectrum.audioAmp * 1f, 1f, 1f) * Time.deltaTime);
        }
    }
}
