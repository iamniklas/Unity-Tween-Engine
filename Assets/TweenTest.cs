using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenTest : MonoBehaviour
{
    [SerializeField] float duration = 2.0f;

    [SerializeField] SimpleTweenEngine.InterpolationType interpolationType;

    private void Start()
    {
        Invoke("SndTween", 1.0f);
    }

    void SndTween()
    {
        TweenOperation tweenOperation = new TweenOperation();
        tweenOperation.SetInterpolation(interpolationType);
        tweenOperation.SetDuration(duration);
        tweenOperation.RegisterTweenStartCallback(TweenStartCallback);
        tweenOperation.RegisterTweenUpdateCallback(TweenUpdateCallback);
        tweenOperation.RegisterTweenCompleteCallback(TweenCompleteCallback);
        tweenOperation.Start();
    }

    void TweenStartCallback()
    {
        Debug.Log($"Start {DateTime.Now}");
    }

    void TweenUpdateCallback(float _value)
    {
        transform.position = new Vector3(transform.position.x, 
                                         transform.position.y, 
                                         _value); 
    }

    void TweenCompleteCallback()
    {
        Debug.Log($"End {DateTime.Now}");
    }
}
