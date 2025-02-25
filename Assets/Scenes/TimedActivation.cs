using System.Collections;
using UnityEngine;

public class TimedActivation : MonoBehaviour
{
    public GameObject targetObject; // Assign in Inspector
    public float startTime = 2f; // When to activate
    public float endTime = 5f;   // When to deactivate

    void Start()
    {
        targetObject.SetActive(false); // Ensure it's off at the start
        StartCoroutine(ActivateBetweenTimes());
    }

    IEnumerator ActivateBetweenTimes()
    {
        yield return new WaitForSeconds(startTime); // Wait for start time
        targetObject.SetActive(true); // Activate object

        float activeDuration = endTime - startTime;
        if (activeDuration > 0)
        {
            yield return new WaitForSeconds(activeDuration); // Wait until end time
            targetObject.SetActive(false); // Deactivate object
        }
    }
}
