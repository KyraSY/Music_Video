using UnityEngine;

public class AudioSpectrum : MonoBehaviour
{
    public static float audioAmp = 0f; // This will store the loudness of the audio

    public AudioSource audioSource; // Reference to the audio source
    private float[] spectrumData = new float[64]; // Array to hold spectrum data

    void Update()
    {
        // Ensure we have an audio source assigned
        if (audioSource == null) return;

        // Get spectrum data (frequency analysis)
        audioSource.GetSpectrumData(spectrumData, 0, FFTWindow.BlackmanHarris);

        // Use the first few frequencies to determine audio amplitude
        float sum = 0f;
        for (int i = 0; i < 10; i++) // Adjust the range for sensitivity
        {
            sum += spectrumData[i];
        }

        // Normalize and amplify the result
        audioAmp = sum * 100f; // Multiplier to make values more noticeable
    }
}
