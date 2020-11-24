using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenTestLine : MonoBehaviour
{
    [SerializeField] float duration = 2.0f;

    [SerializeField] SimpleTweenEngine.InterpolationType interpolationType;

    int runThrough = 0;

    private void Start()
    {
        GetComponent<LineRenderer>().positionCount = Mathf.RoundToInt(duration) * 50 + 1;

        Invoke("SndTween", 5.0f);
    }

    void SndTween()
    {
        runThrough = 0;
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
        runThrough = 0;

    }

    void TweenUpdateCallback(float _value)
    {
        GetComponent<LineRenderer>().SetPosition(runThrough, 
            new Vector3(0, _value, runThrough * Time.fixedDeltaTime));

        runThrough++;
    }

    void TweenCompleteCallback()
    {

    }
}
