using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenCore : MonoBehaviour
{
    private static List<TweenOperation> TweenOperations = new List<TweenOperation>();

    float updateInterval = 0.015f;

    void Start()
    {
        GameObject tweenCore = new GameObject();
        DontDestroyOnLoad(tweenCore);

        LeanTween.value(0.0f, 1.0f, 1.0f);

        StartCoroutine(TweenUpdate());
    }

    IEnumerator TweenUpdate()
    {
        while (true)
        {
            for (int i = 0; i < TweenOperations.Count; i++)
            {
                TweenOperations[i].OperationUpdate();
            }

            yield return new WaitForSecondsRealtime(updateInterval);
        }
    }

    public static void AddNewOperation(TweenOperation _newOperation)
    {
        TweenOperations.Add(_newOperation);
    }

    public static void RemOperation(TweenOperation _operation)
    {
        TweenOperations.Remove(_operation);
    }
}
