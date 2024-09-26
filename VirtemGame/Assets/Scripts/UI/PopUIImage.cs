using UnityEngine;
using System.Collections;

public class PopUIImage : MonoBehaviour
{
    public float popInterval = 2f; // Time in seconds between each pop
    public float popScale = 1.2f; // Scale factor for the pop
    public float popDuration = 0.2f; // Duration of the pop animation

    private Vector3 originalScale;
    private float timer;

    void Start()
    {
        originalScale = transform.localScale;
        StartCoroutine(PopRoutine());
    }

    IEnumerator PopRoutine()
    {
        while (true)
        {
            // Wait for the specified interval
            yield return new WaitForSeconds(popInterval);

            // Pop out
            StartCoroutine(ScaleOverTime(popScale, popDuration));

            // Wait for the pop to finish and a bit more to see the popped state
            yield return new WaitForSeconds(popDuration + 0.1f);

            // Pop back in
            StartCoroutine(ScaleOverTime(originalScale.x, popDuration));
        }
    }

    IEnumerator ScaleOverTime(float targetScale, float duration)
    {
        Vector3 startScale = transform.localScale;
        Vector3 endScale = new Vector3(targetScale, targetScale, targetScale);

        for (float t = 0; t < 1; t += Time.deltaTime / duration)
        {
            transform.localScale = Vector3.Lerp(startScale, endScale, t);
            yield return null;
        }

        transform.localScale = endScale;
    }
}
