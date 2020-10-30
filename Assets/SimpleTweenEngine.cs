using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SimpleTweenEngine : MonoBehaviour
{
    const float c1 = 1.70158f;
    const float c2 = c1 * 1.525f;
    const float c3 = c1 + 1f;
    const float c4 = (2.0f * Mathf.PI) / 3.0f;

    float startTime = 0.0f;

    [SerializeField] float duration = 1.0f;

    int fallBackRep = 1000;
    int fbrC = 0;

    float pastTime = 0.0f;

    float val = 0.0f;

    Vector3 lastPosition = default;

    [SerializeField] AnimationCurve curve = null;

    void Start()
    {
        InvokeRepeating("RunCoroutine", 1.0f, 1.5f);
    }

    void RunCoroutine()
    {
        StartCoroutine(EaseOutElastic());
    }

    //--------------------Linear--------------------//
    IEnumerator EaseLinear()
    {
        while (pastTime < duration)
        {
            val = pastTime;

            pastTime += Time.deltaTime;

            transform.localScale = new Vector3(val, val, val);

            yield return new WaitForEndOfFrame();
        }

        transform.localScale = Vector3.one;

        yield return null;
    }

    //--------------------Custom--------------------//
    IEnumerator EaseCustom()
    {
        while (pastTime < duration)
        {
            fbrC++;

            val = curve.Evaluate(pastTime);

            pastTime += Time.deltaTime;

            transform.localScale = new Vector3(val, val, val);

            yield return new WaitForEndOfFrame();
        }

        transform.localScale = Vector3.one;

        yield return null;
    }

    //--------------------Quad--------------------//
    IEnumerator EaseInQuad()
    {
        while (pastTime < duration)
        {
            fbrC++;

            val = Mathf.Pow(pastTime, 2);

            pastTime += Time.deltaTime;

            transform.localScale = new Vector3(val, val, val);

            yield return new WaitForEndOfFrame();
        }

        transform.localScale = Vector3.one;

        yield return null;
    }

    IEnumerator EaseOutQuad()
    {
        while (pastTime < duration)
        {
            fbrC++;

            val = 1 - Mathf.Pow(1 - pastTime, 2);

            pastTime += Time.deltaTime;

            transform.localScale = new Vector3(val, val, val);

            yield return new WaitForEndOfFrame();
        }

        transform.localScale = Vector3.one;

        yield return null;
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


    //--------------------Cubic--------------------//
    IEnumerator EaseInCubic()
    {
        while (pastTime < duration)
        {
            fbrC++;

            val = Mathf.Pow(pastTime, 3);

            pastTime += Time.deltaTime;

            transform.localScale = new Vector3(val, val, val);

            yield return new WaitForEndOfFrame();
        }

        transform.localScale = Vector3.one;

        yield return null;
    }

    IEnumerator EaseOutCubic()
    {
        while (pastTime < duration)
        {
            fbrC++;

            val = 1 - Mathf.Pow(1 - pastTime, 3);

            pastTime += Time.deltaTime;

            transform.localScale = new Vector3(val, val, val);

            yield return new WaitForEndOfFrame();
        }

        transform.localScale = Vector3.one;

        yield return null;
    }

    IEnumerator EaseInOutCubic()
    {
        while (pastTime < duration)
        {
            fbrC++;

            val = pastTime < 0.5f ? 4 * Mathf.Pow(pastTime, 3) : 1 - Mathf.Pow(-2 * pastTime + 2, 3) / 2;

            pastTime += Time.deltaTime;

            transform.localScale = new Vector3(val, val, val);

            yield return new WaitForEndOfFrame();
        }

        transform.localScale = Vector3.one;

        yield return null;
    }


    //--------------------Quart--------------------//
    IEnumerator EaseInQuart()
    {
        while (pastTime < duration)
        {
            fbrC++;

            val = Mathf.Pow(pastTime, 4);

            pastTime += Time.deltaTime;

            transform.localScale = new Vector3(val, val, val);

            yield return new WaitForEndOfFrame();
        }

        transform.localScale = Vector3.one;

        yield return null;
    }

    IEnumerator EaseOutQuart()
    {
        while (pastTime < duration)
        {
            fbrC++;

            val = 1 - Mathf.Pow(1 - pastTime, 4);

            pastTime += Time.deltaTime;

            transform.localScale = new Vector3(val, val, val);

            yield return new WaitForEndOfFrame();
        }

        transform.localScale = Vector3.one;

        yield return null;
    }

    IEnumerator EaseInOutQuart()
    {
        while (pastTime < duration)
        {
            fbrC++;

            val = pastTime < 0.5f ? 8 * Mathf.Pow(pastTime, 4) : 1 - Mathf.Pow(-2 * pastTime + 2, 4) / 2;

            pastTime += Time.deltaTime;

            transform.localScale = new Vector3(val, val, val);

            yield return new WaitForEndOfFrame();
        }

        transform.localScale = Vector3.one;

        yield return null;
    }


    //--------------------Quint--------------------//
    IEnumerator EaseInQuint()
    {
        while (pastTime < duration)
        {
            fbrC++;

            val = Mathf.Pow(pastTime, 5);

            pastTime += Time.deltaTime;

            transform.localScale = new Vector3(val, val, val);

            yield return new WaitForEndOfFrame();
        }

        transform.localScale = Vector3.one;

        yield return null;
    }

    IEnumerator EaseOutQuint()
    {
        while (pastTime < duration)
        {
            fbrC++;

            val = 1 - Mathf.Pow(1 - pastTime, 5);

            pastTime += Time.deltaTime;

            transform.localScale = new Vector3(val, val, val);

            yield return new WaitForEndOfFrame();
        }

        transform.localScale = Vector3.one;

        yield return null;
    }

    IEnumerator EaseInOutQuint()
    {
        while (pastTime < duration)
        {
            fbrC++;

            val = pastTime < 0.5f ? 16 * Mathf.Pow(pastTime, 5) : 1 - Mathf.Pow(-2 * pastTime + 2, 5) / 2;

            pastTime += Time.deltaTime;

            transform.localScale = new Vector3(val, val, val);

            yield return new WaitForEndOfFrame();
        }

        transform.localScale = Vector3.one;

        yield return null;
    }


    //--------------------Expo--------------------//
    IEnumerator EaseInExpo()
    {
        while (pastTime < duration)
        {
            val = Mathf.Pow(2, 10 * pastTime - 10);

            pastTime += Time.deltaTime;

            transform.localScale = new Vector3(val, val, val);

            yield return new WaitForEndOfFrame();
        }

        transform.localScale = Vector3.one;

        yield return null;
    }

    IEnumerator EaseOutExpo()
    {
        while (pastTime < duration)
        {
            fbrC++;

            val = 1 - Mathf.Pow(2, -10 * pastTime);

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


    //--------------------Circ--------------------//
    IEnumerator EaseInCirc()
    {
        while (pastTime < duration)
        {
            fbrC++;

            val = 1 - Mathf.Sqrt(1 - Mathf.Pow(pastTime, 2));

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
            val = Mathf.Sqrt(1 - Mathf.Pow(pastTime - 1, 2));

            pastTime += Time.deltaTime;

            transform.localScale = new Vector3(val, val, val);

            yield return new WaitForEndOfFrame();
        }

        transform.localScale = Vector3.one;

        yield return null;
    }

    IEnumerator EaseInOutCirc()
    {
        while (pastTime < duration)
        {
            fbrC++;

            val = pastTime < 0.5f ? (1 - Mathf.Sqrt(1 - Mathf.Pow(2 * pastTime, 2))) / 2 :
                (Mathf.Sqrt(1 - Mathf.Pow(-2 * pastTime + 2, 2)) + 1) / 2;

            pastTime += Time.deltaTime;

            transform.localScale = new Vector3(val, val, val);

            yield return new WaitForEndOfFrame();
        }

        transform.localScale = Vector3.one;

        yield return null;
    }

    //--------------------Back--------------------//
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

    IEnumerator EaseOutBack()
    {
        while (pastTime < duration)
        {
            val = 1 + c3 * Mathf.Pow(pastTime - 1, 3) + c1 * Mathf.Pow(pastTime - 1, 2);

            pastTime += Time.deltaTime;

            transform.localScale = new Vector3(val, val, val);

            yield return new WaitForEndOfFrame();
        }

        transform.localScale = Vector3.one;

        yield return null;
    }

    IEnumerator EaseIntOutBack()
    {
        while (pastTime < duration)
        {
            val = pastTime < 0.5f ?
                (Mathf.Pow(2 * pastTime, 2) * ((c2 + 1) * 2 * pastTime - c2)) / 2:
                (Mathf.Pow(2 * pastTime - 2, 2) * ((c2 + 1) * (pastTime * 2 - 2) + c2) + 2) / 2;

            pastTime += Time.deltaTime;

            transform.localScale = new Vector3(val, val, val);

            yield return new WaitForEndOfFrame();
        }

        transform.localScale = Vector3.one;

        yield return null;
    }


    //--------------------Elastic--------------------//
    IEnumerator EaseInElastic()
    {
        while (pastTime < duration)
        {
            val = -Mathf.Pow(2, 10 * pastTime - 10) * Mathf.Sin((pastTime * 10 - 10.75f) * c4);

            pastTime += Time.deltaTime;

            transform.localScale = new Vector3(val, val, val);

            yield return new WaitForEndOfFrame();
        }

        transform.localScale = Vector3.one;

        yield return null;
    }

    IEnumerator EaseOutElastic()
    {
        pastTime = 0.0f;
        val = 0.0f;
        Vector3 lastPos = transform.position;

        while (pastTime < duration)
        {
            val = Mathf.Pow(2, -10 * pastTime) * Mathf.Sin((10 * pastTime - 0.75f) * c4) + 1;

            pastTime += Time.deltaTime;

            transform.position = lastPos + new Vector3(0, 0, val);

            yield return new WaitForEndOfFrame();
        }

        yield return null;
    }

    IEnumerator EaseInOutElastic()
    {
        while (pastTime < duration)
        {
            //val = ;

            pastTime += Time.deltaTime;

            transform.localScale = new Vector3(val, val, val);

            yield return new WaitForEndOfFrame();
        }

        transform.localScale = Vector3.one;

        yield return null;
    }

    //--------------------Bounce--------------------//
    IEnumerator EaseInBounce()
    {
        while (pastTime < duration)
        {
            //val = ;

            pastTime += Time.deltaTime;

            transform.localScale = new Vector3(val, val, val);

            yield return new WaitForEndOfFrame();
        }

        transform.localScale = Vector3.one;

        yield return null;
    }

    IEnumerator EaseOutBounce()
    {
        while (pastTime < duration)
        {
            //val = ;

            pastTime += Time.deltaTime;

            transform.localScale = new Vector3(val, val, val);

            yield return new WaitForEndOfFrame();
        }

        transform.localScale = Vector3.one;

        yield return null;
    }

    IEnumerator EaseInOutBounce()
    {
        while (pastTime < duration)
        {
            //val = ;

            pastTime += Time.deltaTime;

            transform.localScale = new Vector3(val, val, val);

            yield return new WaitForEndOfFrame();
        }

        transform.localScale = Vector3.one;

        yield return null;
    }

    
}
