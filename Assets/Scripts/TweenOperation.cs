using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenOperation
{
    GameObject target;


    event Action OnTweenStart = () => { };
    event Action<float> OnTweenUpdate = (value) => { };
    event Action OnTweenComplete = () => { };

    float time = 0.0f, duration = 0.0f;

    SimpleTweenEngine.InterpolationType interpolationType = default;

    public TweenOperation()
    {
        time = 0.0f;
        duration = 1.0f;
        interpolationType = SimpleTweenEngine.InterpolationType.Linear;
    }

    public void SetInterpolation(SimpleTweenEngine.InterpolationType _interpolationType)
    {
        interpolationType = _interpolationType;
    }

    public void SetDuration(float _duration)
    {
        duration = _duration;
    }

    public void Start()
    {
        OnTweenStart.Invoke();
        TweenCore.AddNewOperation(this);
    }

    public void RegisterTweenStartCallback(Action _callback)
    {
        OnTweenStart += _callback;
    }
    public void RegisterTweenUpdateCallback(Action<float> _callback)
    {
        OnTweenUpdate += _callback;
    }
    public void RegisterTweenCompleteCallback(Action _callback)
    {
        OnTweenComplete += _callback;
    }

    public void OperationUpdate()
    {
        if (time < duration)
        {
            time += (Time.fixedDeltaTime / duration);
            OnTweenUpdate.Invoke(SimpleTweenEngine.Instance.GetTweenValue(interpolationType, time));
            return;
        }
        else
        {
            time = duration;
            OnTweenUpdate.Invoke(time);
        }

        OnTweenComplete.Invoke();

        TweenCore.RemOperation(this);
    }
}
