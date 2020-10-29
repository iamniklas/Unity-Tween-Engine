using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SimpleTweenEngine : MonoBehaviour
{
    const float c1 = 1.70158f;
    const float c3 = c1 + 1f;

    float startTime = 0.0f;

    [SerializeField] float duration = 1.0f;

    int fallBackRep = 1000;
    int fbrC = 0;

    float pastTime = 0.0f;

    float val = 0.0f;

    Vector3 lastPosition = default;

    void Start()
    {
        InvokeRepeating("RunCoroutine", 1.0f, 1.5f);
    }

    void RunCoroutine()
    {
        StartCoroutine(EaseInOutExpo());
    }

    IEnumerator EaseInOutQuad()
    {
        while (pastTime < duration)
        {
            fbrC++;

            val = pastTime < 0.5f ? 2 * Mathf.Pow(pastTime, 2) : 1 - Mathf.Pow(-2 * pastTime + 2, 2) / 2;

            pastTime += Time.deltaTime;

            transform.localScale = new Vector3(val, val, val);

            yield return new WaitForEndOfFrame();
        }

        transform.localScale = Vector3.one;

        yield return null;
    }

    IEnumerator EaseOutCirc()
    {
        while (pastTime < duration)
        {
            fbrC++;

            val = Mathf.Sqrt(1 - Mathf.Pow(pastTime - 1, 2));

            pastTime += Time.deltaTime;

            transform.localScale = new Vector3(val, val, val);

            yield return new WaitForEndOfFrame();
        }

        transform.localScale = Vector3.one;

        yield return null;
    }

    IEnumerator EaseInBack()
    {
        while (pastTime < duration)
        {
            fbrC++;

            val = c3 * Mathf.Pow(pastTime, 3) - c1 * Mathf.Pow(pastTime, 2);

            pastTime += Time.deltaTime;

            transform.localScale = new Vector3(val, val, val);

            yield return new WaitForEndOfFrame();
        }

        transform.localScale = Vector3.one;

        yield return null;
    }

    IEnumerator EaseInOutExpo()
    {
        lastPosition = transform.position;
        pastTime = 0f;
        val = 0f;

        while (pastTime < duration)
        {
            fbrC++;

            val = pastTime < 0.5f ? Mathf.Pow(2, 20 * pastTime - 10) / 2 :
                (2 - Mathf.Pow(2, -20 * pastTime + 10)) / 2;

            pastTime += Time.deltaTime;

            transform.position = lastPosition + new Vector3(0, 0, val);

            yield return new WaitForEndOfFrame();
        }

        lastPosition = transform.position;

        yield return null;
    }
}
