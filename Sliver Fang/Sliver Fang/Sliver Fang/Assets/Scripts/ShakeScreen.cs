using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeScreen : MonoBehaviour
{
    public static bool isShaking = false;
    public float duration = 1f;

    public AnimationCurve curve;
    Vector3 startPosition;
    private void Start()
    {
        startPosition = transform.position;

    }
    private void Update()
    {
        if (isShaking)
        {
            isShaking = false;
            StartCoroutine(shake());


        }
    }




    IEnumerator shake()
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float strenght = curve.Evaluate(elapsedTime / duration);
            transform.position = startPosition + Random.insideUnitSphere * strenght;
            yield return null;
        }
        transform.position = startPosition;
    }
}
