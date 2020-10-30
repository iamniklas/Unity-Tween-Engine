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
    const float c5 = (2.0f * Mathf.PI) * 4.5f;

    const float n1 = 7.5625f;
    const float d1 = 2.75f;

    float startTime = 0.0f;

    [SerializeField] float duration = 1.0f;

    int fallBackRep = 1000;
    int fbrC = 0;

    float pastTime = 0.0f;

    float val = 0.0f;

    Vector3 lastPosition = default;

    [SerializeField] AnimationCurve curve = null;

    enum InterpolationType
    {
        Linear, CustomCurve,
        EaseInSine, EaseOutSine, EaseInOutSine,
        EaseInQuad, EaseOutQuad, EaseInOutQuad,
        EaseInCubic, EaseOutCubic, EaseInOutCubic,
        EaseInQuart, EaseOutQuart, EaseInOutQuart,
        EaseInQuint, EaseOutQuint, EaseInOutQuint,
        EaseInExpo, EaseOutExpo, EaseInOutExpo,
        EaseInCirc, EaseOutCirc, EaseInOutCirc,
        EaseInBack, EaseOutBack, EaseInOutBack,
        EaseInElastic, EaseOutElastic, EaseInOutElastic,
        EaseInBounce, EaseOutBounce, EaseInOutBounce
    }

    enum InterpolationBehaviour
    {
        MoveX, MoveY, MoveZ,
        LocalMoveX, LocalMoveY, LocalMoveZ,
        RotateX, RotateY, RotateZ,
        ScaleX, ScaleY, ScaleZ,
        Value
    }

    [SerializeField] InterpolationType interpolationType = default;
    [SerializeField] InterpolationBehaviour interpolationTarget = default;
    [SerializeField] LeanTweenType leanInterpolationType = default;

    void Start()
    {
        InvokeRepeating("RunCoroutine", 0.0f, 1.5f);
    }

    void RunCoroutine()
    {
        switch (interpolationType)
        {
            case InterpolationType.Linear: StartCoroutine(EaseLinear(null)); break;

            case InterpolationType.CustomCurve: StartCoroutine(EaseCustom(null)); break;

            //case InterpolationType.EaseSineIn: StartCoroutine((null)); break;
            //case InterpolationType.EaseSineOut: StartCoroutine(EaseInOutElastic(null)); break;
            //case InterpolationType.EaseSineInOut: StartCoroutine(EaseInOutElastic(null)); break;

            case InterpolationType.EaseInQuad: StartCoroutine(EaseInQuad(null)); break;
            case InterpolationType.EaseOutQuad: StartCoroutine(EaseOutQuad(null)); break;
            case InterpolationType.EaseInOutQuad: StartCoroutine(EaseInOutQuad(null)); break;

            case InterpolationType.EaseInCubic: StartCoroutine(EaseInCubic(null)); break;
            case InterpolationType.EaseOutCubic: StartCoroutine(EaseOutCubic(null)); break;
            case InterpolationType.EaseInOutCubic: StartCoroutine(EaseInOutCubic(null)); break;

            case InterpolationType.EaseInQuart: StartCoroutine(EaseInQuart(null)); break;
            case InterpolationType.EaseOutQuart: StartCoroutine(EaseOutQuart(null)); break;
            case InterpolationType.EaseInOutQuart: StartCoroutine(EaseInOutQuart(null)); break;

            case InterpolationType.EaseInQuint: StartCoroutine(EaseInQuint(null)); break;
            case InterpolationType.EaseOutQuint: StartCoroutine(EaseOutQuint(null)); break;
            case InterpolationType.EaseInOutQuint: StartCoroutine(EaseInOutQuint(null)); break;

            case InterpolationType.EaseInExpo: StartCoroutine(EaseInExpo(null)); break;
            case InterpolationType.EaseOutExpo: StartCoroutine(EaseOutExpo(null)); break;
            case InterpolationType.EaseInOutExpo: StartCoroutine(EaseInOutExpo(null)); break;

            case InterpolationType.EaseInCirc: StartCoroutine(EaseInCirc(null)); break;
            case InterpolationType.EaseOutCirc: StartCoroutine(EaseOutCirc(null)); break;
            case InterpolationType.EaseInOutCirc: StartCoroutine(EaseInOutCirc(null)); break;

            case InterpolationType.EaseInBack: StartCoroutine(EaseInBack(null)); break;
            case InterpolationType.EaseOutBack: StartCoroutine(EaseOutBack(null)); break;
            case InterpolationType.EaseInOutBack: StartCoroutine(EaseInOutBack(null)); break;

            case InterpolationType.EaseInElastic: StartCoroutine(EaseInElastic(null)); break;
            case InterpolationType.EaseOutElastic: StartCoroutine(EaseOutElastic(null)); break;
            case InterpolationType.EaseInOutElastic: StartCoroutine(EaseInOutElastic(null)); break;

            case InterpolationType.EaseInBounce: StartCoroutine(EaseInBounce(null)); break;
            case InterpolationType.EaseOutBounce: StartCoroutine(EaseOutBounce(null)); break;
            case InterpolationType.EaseInOutBounce: StartCoroutine(EaseInOutBounce(null)); break;
        }
    }

    //--------------------Linear--------------------//
    IEnumerator EaseLinear(GameObject _target)
    {
        pastTime = 0.0f;
        val = 0.0f;
        Vector3 lastPosition = transform.position;

        while (pastTime < duration)
        {
            val = pastTime;

            pastTime += Time.deltaTime;

            transform.position = lastPosition + new Vector3(0, 0, val);

            yield return new WaitForEndOfFrame();
        }

        val = 1.0f;
        transform.position = lastPosition + new Vector3(0, 0, val);

        yield return null;
    }


    //--------------------Custom--------------------//
    IEnumerator EaseCustom(GameObject _target)
    {
        pastTime = 0.0f;
        val = 0.0f;
        Vector3 lastPosition = transform.position;

        while (pastTime < duration)
        {
            val = curve.Evaluate(pastTime);

            pastTime += Time.deltaTime;

            transform.position = lastPosition + new Vector3(0, 0, val);

            yield return new WaitForEndOfFrame();
        }

        val = 1.0f;
        transform.position = lastPosition + new Vector3(0, 0, val);

        yield return null;
    }


    //--------------------Quad--------------------//
    IEnumerator EaseInQuad(GameObject _target)
    {
        pastTime = 0.0f;
        val = 0.0f;
        Vector3 lastPosition = transform.position;

        while (pastTime < duration)
        {
            val = Mathf.Pow(pastTime, 2);

            pastTime += Time.deltaTime;

            transform.position = lastPosition + new Vector3(0, 0, val);

            yield return new WaitForEndOfFrame();
        }

        val = 1.0f;
        transform.position = lastPosition + new Vector3(0, 0, val);

        yield return null;
    }

    IEnumerator EaseOutQuad(GameObject _target)
    {
        pastTime = 0.0f;
        val = 0.0f;
        Vector3 lastPosition = transform.position;

        while (pastTime < duration)
        {
            val = 1 - Mathf.Pow(1 - pastTime, 2);

            pastTime += Time.deltaTime;

            transform.position = lastPosition + new Vector3(0, 0, val);

            yield return new WaitForEndOfFrame();
        }

        val = 1.0f;
        transform.position = lastPosition + new Vector3(0, 0, val);

        yield return null;
    }

    IEnumerator EaseInOutQuad(GameObject _target)
    {
        pastTime = 0.0f;
        val = 0.0f;
        Vector3 lastPosition = transform.position;

        while (pastTime < duration)
        {
            val = pastTime < 0.5f ? 
                2 * Mathf.Pow(pastTime, 2) : 
                1 - Mathf.Pow(-2 * pastTime + 2, 2) / 2;

            pastTime += Time.deltaTime;

            transform.position = lastPosition + new Vector3(0, 0, val);

            yield return new WaitForEndOfFrame();
        }

        val = 1.0f;
        transform.position = lastPosition + new Vector3(0, 0, val);

        yield return null;
    }


    //--------------------Cubic--------------------//
    IEnumerator EaseInCubic(GameObject _target)
    {
        pastTime = 0.0f;
        val = 0.0f;
        Vector3 lastPosition = transform.position;

        while (pastTime < duration)
        {
            val = Mathf.Pow(pastTime, 3);

            pastTime += Time.deltaTime;

            transform.position = lastPosition + new Vector3(0, 0, val);

            yield return new WaitForEndOfFrame();
        }

        val = 1.0f;
        transform.position = lastPosition + new Vector3(0, 0, val);

        yield return null;
    }

    IEnumerator EaseOutCubic(GameObject _target)
    {
        pastTime = 0.0f;
        val = 0.0f;
        Vector3 lastPosition = transform.position;

        while (pastTime < duration)
        {
            val = 1 - Mathf.Pow(1 - pastTime, 3);

            pastTime += Time.deltaTime;

            transform.position = lastPosition + new Vector3(0, 0, val);

            yield return new WaitForEndOfFrame();
        }

        val = 1.0f;
        transform.position = lastPosition + new Vector3(0, 0, val);

        yield return null;
    }

    IEnumerator EaseInOutCubic(GameObject _target)
    {
        pastTime = 0.0f;
        val = 0.0f;
        Vector3 lastPosition = transform.position;

        while (pastTime < duration)
        {
            val = pastTime < 0.5f ? 4 * Mathf.Pow(pastTime, 3) : 1 - Mathf.Pow(-2 * pastTime + 2, 3) / 2;

            pastTime += Time.deltaTime;

            transform.position = lastPosition + new Vector3(0, 0, val);

            yield return new WaitForEndOfFrame();
        }

        val = 1.0f;
        transform.position = lastPosition + new Vector3(0, 0, val);

        yield return null;
    }


    //--------------------Quart--------------------//
    IEnumerator EaseInQuart(GameObject _target)
    {
        pastTime = 0.0f;
        val = 0.0f;
        Vector3 lastPosition = transform.position;

        while (pastTime < duration)
        {
            val = Mathf.Pow(pastTime, 4);

            pastTime += Time.deltaTime;

            transform.position = lastPosition + new Vector3(0, 0, val);

            yield return new WaitForEndOfFrame();
        }

        val = 1.0f;
        transform.position = lastPosition + new Vector3(0, 0, val);

        yield return null;
    }

    IEnumerator EaseOutQuart(GameObject _target)
    {
        pastTime = 0.0f;
        val = 0.0f;
        Vector3 lastPosition = transform.position;

        while (pastTime < duration)
        {
            val = 1 - Mathf.Pow(1 - pastTime, 4);

            pastTime += Time.deltaTime;

            transform.position = lastPosition + new Vector3(0, 0, val);

            yield return new WaitForEndOfFrame();
        }

        val = 1.0f;
        transform.position = lastPosition + new Vector3(0, 0, val);

        yield return null;
    }

    IEnumerator EaseInOutQuart(GameObject _target)
    {
        pastTime = 0.0f;
        val = 0.0f;
        Vector3 lastPosition = transform.position;

        while (pastTime < duration)
        {
            val = pastTime < 0.5f ? 8 * Mathf.Pow(pastTime, 4) : 1 - Mathf.Pow(-2 * pastTime + 2, 4) / 2;

            pastTime += Time.deltaTime;

            transform.position = lastPosition + new Vector3(0, 0, val);

            yield return new WaitForEndOfFrame();
        }

        val = 1.0f;
        transform.position = lastPosition + new Vector3(0, 0, val);

        yield return null;
    }


    //--------------------Quint--------------------//
    IEnumerator EaseInQuint(GameObject _target)
    {
        pastTime = 0.0f;
        val = 0.0f;
        Vector3 lastPosition = transform.position;

        while (pastTime < duration)
        {
            val = Mathf.Pow(pastTime, 5);

            pastTime += Time.deltaTime;

            transform.position = lastPosition + new Vector3(0, 0, val);

            yield return new WaitForEndOfFrame();
        }

        val = 1.0f;
        transform.position = lastPosition + new Vector3(0, 0, val);

        yield return null;
    }

    IEnumerator EaseOutQuint(GameObject _target)
    {
        pastTime = 0.0f;
        val = 0.0f;
        Vector3 lastPosition = transform.position;

        while (pastTime < duration)
        {
            val = 1 - Mathf.Pow(1 - pastTime, 5);

            pastTime += Time.deltaTime;

            transform.position = lastPosition + new Vector3(0, 0, val);

            yield return new WaitForEndOfFrame();
        }

        val = 1.0f;
        transform.position = lastPosition + new Vector3(0, 0, val);

        yield return null;
    }

    IEnumerator EaseInOutQuint(GameObject _target)
    {
        pastTime = 0.0f;
        val = 0.0f;
        Vector3 lastPosition = transform.position;

        while (pastTime < duration)
        {
            val = pastTime < 0.5f ? 16 * Mathf.Pow(pastTime, 5) : 1 - Mathf.Pow(-2 * pastTime + 2, 5) / 2;

            pastTime += Time.deltaTime;

            transform.position = lastPosition + new Vector3(0, 0, val);

            yield return new WaitForEndOfFrame();
        }

        val = 1.0f;
        transform.position = lastPosition + new Vector3(0, 0, val);

        yield return null;
    }


    //--------------------Expo--------------------//
    IEnumerator EaseInExpo(GameObject _target)
    {
        pastTime = 0.0f;
        val = 0.0f;
        Vector3 lastPosition = transform.position;

        while (pastTime < duration)
        {
            val = Mathf.Pow(2, 10 * pastTime - 10);

            pastTime += Time.deltaTime;

            transform.position = lastPosition + new Vector3(0, 0, val);

            yield return new WaitForEndOfFrame();
        }

        val = 1.0f;
        transform.position = lastPosition + new Vector3(0, 0, val);

        yield return null;
    }

    IEnumerator EaseOutExpo(GameObject _target)
    {
        pastTime = 0.0f;
        val = 0.0f;
        Vector3 lastPosition = transform.position;

        while (pastTime < duration)
        {
            val = 1 - Mathf.Pow(2, -10 * pastTime);

            pastTime += Time.deltaTime;

            transform.position = lastPosition + new Vector3(0, 0, val);

            yield return new WaitForEndOfFrame();
        }

        val = 1.0f;
        transform.position = lastPosition + new Vector3(0, 0, val);

        yield return null;
    }

    IEnumerator EaseInOutExpo(GameObject _target)
    {
        lastPosition = transform.position;
        pastTime = 0f;
        val = 0f;

        while (pastTime < duration)
        {
            val = pastTime < 0.5f ? Mathf.Pow(2, 20 * pastTime - 10) / 2 :
                (2 - Mathf.Pow(2, -20 * pastTime + 10)) / 2;

            pastTime += Time.deltaTime;

            transform.position = lastPosition + new Vector3(0, 0, val);

            yield return new WaitForEndOfFrame();
        }

        val = 1.0f;
        transform.position = lastPosition + new Vector3(0, 0, val);

        yield return null;
    }


    //--------------------Circ--------------------//
    IEnumerator EaseInCirc(GameObject _target)
    {
        pastTime = 0.0f;
        val = 0.0f;
        Vector3 lastPosition = transform.position;

        while (pastTime < duration)
        {
            val = 1 - Mathf.Sqrt(1 - Mathf.Pow(pastTime, 2));

            pastTime += Time.deltaTime;

            transform.position = lastPosition + new Vector3(0, 0, val);

            yield return new WaitForEndOfFrame();
        }

        val = 1.0f;
        transform.position = lastPosition + new Vector3(0, 0, val);

        yield return null;
    }

    IEnumerator EaseOutCirc(GameObject _target)
    {
        pastTime = 0.0f;
        val = 0.0f;
        Vector3 lastPosition = transform.position;

        while (pastTime < duration)
        {
            val = Mathf.Sqrt(1 - Mathf.Pow(pastTime - 1, 2));

            pastTime += Time.deltaTime;

            transform.position = lastPosition + new Vector3(0, 0, val);

            yield return new WaitForEndOfFrame();
        }

        val = 1.0f;
        transform.position = lastPosition + new Vector3(0, 0, val);

        yield return null;
    }

    IEnumerator EaseInOutCirc(GameObject _target)
    {
        pastTime = 0.0f;
        val = 0.0f;
        Vector3 lastPosition = transform.position;

        while (pastTime < duration)
        {
            val = pastTime < 0.5f ? (1 - Mathf.Sqrt(1 - Mathf.Pow(2 * pastTime, 2))) / 2 :
                (Mathf.Sqrt(1 - Mathf.Pow(-2 * pastTime + 2, 2)) + 1) / 2;

            pastTime += Time.deltaTime;

            transform.position = lastPosition + new Vector3(0, 0, val);

            yield return new WaitForEndOfFrame();
        }

        val = 1.0f;
        transform.position = lastPosition + new Vector3(0, 0, val);

        yield return null;
    }

    //--------------------Back--------------------//
    IEnumerator EaseInBack(GameObject _target)
    {
        pastTime = 0.0f;
        val = 0.0f;
        Vector3 lastPosition = transform.position;

        while (pastTime < duration)
        {
            val = c3 * Mathf.Pow(pastTime, 3) - c1 * Mathf.Pow(pastTime, 2);

            pastTime += Time.deltaTime;

            transform.position = lastPosition + new Vector3(0, 0, val);

            yield return new WaitForEndOfFrame();
        }

        val = 1.0f;
        transform.position = lastPosition + new Vector3(0, 0, val);

        yield return null;
    }

    IEnumerator EaseOutBack(GameObject _target)
    {
        pastTime = 0.0f;
        val = 0.0f;
        Vector3 lastPosition = transform.position;

        while (pastTime < duration)
        {
            val = 1 + c3 * Mathf.Pow(pastTime - 1, 3) + c1 * Mathf.Pow(pastTime - 1, 2);

            pastTime += Time.deltaTime;

            transform.position = lastPosition + new Vector3(0, 0, val);

            yield return new WaitForEndOfFrame();
        }

        val = 1.0f;
        transform.position = lastPosition + new Vector3(0, 0, val);

        yield return null;
    }

    IEnumerator EaseInOutBack(GameObject _target)
    {
        pastTime = 0.0f;
        val = 0.0f;
        Vector3 lastPosition = transform.position;


        while (pastTime < duration)
        {
            val = pastTime < 0.5f ?
                (Mathf.Pow(2 * pastTime, 2) * ((c2 + 1) * 2 * pastTime - c2)) / 2 :
                (Mathf.Pow(2 * pastTime - 2, 2) * ((c2 + 1) * (pastTime * 2 - 2) + c2) + 2) / 2;

            pastTime += Time.deltaTime;

            transform.position = lastPosition + new Vector3(0, 0, val);

            yield return new WaitForEndOfFrame();
        }

        val = 1.0f;
        transform.position = lastPosition + new Vector3(0, 0, val);

        yield return null;
    }


    //--------------------Elastic--------------------//
    IEnumerator EaseInElastic(GameObject _target)
    {
        pastTime = 0.0f;
        val = 0.0f;
        Vector3 lastPosition = transform.position;

        while (pastTime < duration)
        {
            val = -Mathf.Pow(2, 10 * pastTime - 10) * Mathf.Sin((pastTime * 10 - 10.75f) * c4);

            pastTime += Time.deltaTime;

            transform.position = lastPosition + new Vector3(0, 0, val);

            yield return new WaitForEndOfFrame();
        }

        val = 1.0f;
        transform.position = lastPosition + new Vector3(0, 0, val);

        yield return null;
    }

    IEnumerator EaseOutElastic(GameObject _target)
    {
        pastTime = 0.0f;
        val = 0.0f;
        Vector3 lastPosition = transform.position;

        while (pastTime < duration)
        {
            val = Mathf.Pow(2, -10 * pastTime) * Mathf.Sin((10 * pastTime - 0.75f) * c4) + 1;

            pastTime += Time.deltaTime;

            transform.position = lastPosition + new Vector3(0, 0, val);

            yield return new WaitForEndOfFrame();
        }

        val = 1.0f;
        transform.position = lastPosition + new Vector3(0, 0, val);


        yield return null;
    }

    IEnumerator EaseInOutElastic(GameObject _target)
    {
        pastTime = 0.0f;
        val = 0.0f;
        Vector3 lastPosition= transform.position;

        while (pastTime < duration)
        {

            val = pastTime == 0 ? 0 : 
                pastTime == 1 ? 1 :
                pastTime < 0.5f ? 
                -(Mathf.Pow(2, 20 * pastTime - 10) * Mathf.Sin((20 * pastTime - 11.125f) * c5)) / 2 : 
                (Mathf.Pow(2, -20 * pastTime + 10) * Mathf.Sin((20 * pastTime - 11.125f) * c5)) / 2 + 1;

            pastTime += Time.deltaTime;

            transform.position = lastPosition + new Vector3(0, 0, val);

            yield return new WaitForEndOfFrame();
        }

        val = 1.0f;
        transform.position = new Vector3(0, 0, val);

        yield return null;
    }

    //--------------------Bounce--------------------//
    IEnumerator EaseInBounce(GameObject _target)
    {
        pastTime = 0.0f;
        val = 0.0f;
        Vector3 lastPosition = transform.position;

        while (pastTime < duration)
        {
            //1 - easeOutBounce(1 - x);
            //val = ;

            pastTime += Time.deltaTime;

            transform.position = lastPosition + new Vector3(0, 0, val);

            yield return new WaitForEndOfFrame();
        }

        val = 1.0f;
        transform.position = lastPosition + new Vector3(0, 0, val);

        yield return null;
    }

    IEnumerator EaseOutBounce(GameObject _target)
    {
        pastTime = 0.0f;
        val = 0.0f;
        Vector3 lastPosition = transform.position;

        while (pastTime < duration)
        {
            if (pastTime < 1f / d1)
            {
                val = n1 * pastTime * pastTime;
            }
            else if (pastTime < 2f / d1)
            {
                val = n1 * (pastTime -= 1.5f / d1) * pastTime + 0.75f;
            }
            else if (pastTime < 2.5f / d1)
            {
                val = n1 * (pastTime -= 2.25f / d1) * pastTime + 0.9375f;
            }
            else
            {
                val = n1 * (pastTime -= 2.625f / d1) * pastTime + 0.984375f;
            }

            pastTime += Time.deltaTime;

            transform.position = lastPosition + new Vector3(0, 0, val);

            yield return new WaitForEndOfFrame();
        }

        val = 1.0f;
        transform.position = lastPosition + new Vector3(0, 0, val);

        yield return null;
    }

    IEnumerator EaseInOutBounce(GameObject _target)
    {
        pastTime = 0.0f;
        val = 0.0f;
        Vector3 lastPosition = transform.position;

        while (pastTime < duration)
        {
            //val = pastTime < 0.5 ? 
            //    (1 - easeOutBounce(1 - 2 * pastTime)) / 2 : 
            //    (1 + easeOutBounce(2 * pastTime - 1)) / 2;
            
            pastTime += Time.deltaTime;

            transform.position = lastPosition + new Vector3(0, 0, val);

            yield return new WaitForEndOfFrame();
        }

        val = 1.0f;
        transform.position = lastPosition + new Vector3(0, 0, val);

        yield return null;
    }

}