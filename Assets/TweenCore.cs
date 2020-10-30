using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenCore : MonoBehaviour
{
    private List<TweenOperation> TweenOperations = new List<TweenOperation>();

    void Start()
    {
        GameObject tweenCore = new GameObject();
        DontDestroyOnLoad(tweenCore);

        LeanTween.value(0.0f, 1.0f, 1.0f);

        //Instantiate(this);
        //DontDestroyOnLoad(this);
    }

    void FixedUpdate()
    {
        TweenUpdate();
    }

    private void TweenUpdate()
    {
        foreach (TweenOperation operation in TweenOperations)
        {
            operation.OperationUpdate();
        }
    }

    public static void AddNewOperation()
    {

    }
}
