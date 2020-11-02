using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SimpleTweenEngine
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

    float val = 0.0f;

    Vector3 lastPosition = default;

    [SerializeField] AnimationCurve curve = null;

    public static SimpleTweenEngine Instance = new SimpleTweenEngine();

    public enum InterpolationType
    {
        NotSpecified,
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

    public enum InterpolationBehaviour
    {
        MoveX, MoveY, MoveZ,
        LocalMoveX, LocalMoveY, LocalMoveZ,
        RotateX, RotateY, RotateZ,
        ScaleX, ScaleY, ScaleZ,
        Value
    }

    public float GetTweenValue(InterpolationType interpolationType, float _t)
    {
        Mathf.Clamp01(_t);

        switch (interpolationType)
        {
            case InterpolationType.Linear:          return EaseLinear(_t); 

            case InterpolationType.CustomCurve:     return EaseCustom(_t); 

            case InterpolationType.EaseInSine:      return EaseInSine(_t); 
            case InterpolationType.EaseOutSine:     return EaseOutSine(_t); 
            case InterpolationType.EaseInOutSine:   return EaseInOutSine(_t); 

            case InterpolationType.EaseInQuad:      return EaseInQuad(_t); 
            case InterpolationType.EaseOutQuad:     return EaseOutQuad(_t); 
            case InterpolationType.EaseInOutQuad:   return EaseInOutQuad(_t); 

            case InterpolationType.EaseInCubic:     return EaseInCubic(_t); 
            case InterpolationType.EaseOutCubic:    return EaseOutCubic(_t); 
            case InterpolationType.EaseInOutCubic:  return EaseInOutCubic(_t); 

            case InterpolationType.EaseInQuart:     return EaseInQuart(_t); 
            case InterpolationType.EaseOutQuart:    return EaseOutQuart(_t); 
            case InterpolationType.EaseInOutQuart:  return EaseInOutQuart(_t); 

            case InterpolationType.EaseInQuint:     return EaseInQuint(_t); 
            case InterpolationType.EaseOutQuint:    return EaseOutQuint(_t); 
            case InterpolationType.EaseInOutQuint:  return EaseInOutQuint(_t); 

            case InterpolationType.EaseInExpo:      return EaseInExpo(_t); 
            case InterpolationType.EaseOutExpo:     return EaseOutExpo(_t); 
            case InterpolationType.EaseInOutExpo:   return EaseInOutExpo(_t); 

            case InterpolationType.EaseInCirc:      return EaseInCirc(_t); 
            case InterpolationType.EaseOutCirc:     return EaseOutCirc(_t); 
            case InterpolationType.EaseInOutCirc:   return EaseInOutCirc(_t); 

            case InterpolationType.EaseInBack:      return EaseInBack(_t); 
            case InterpolationType.EaseOutBack:     return EaseOutBack(_t); 
            case InterpolationType.EaseInOutBack:   return EaseInOutBack(_t); 

            case InterpolationType.EaseInElastic:   return EaseInElastic(_t);
            case InterpolationType.EaseOutElastic:  return EaseOutElastic(_t);
            case InterpolationType.EaseInOutElastic: return EaseInOutElastic(_t);

            case InterpolationType.EaseInBounce:    return EaseInBounce(_t);
            case InterpolationType.EaseOutBounce:   return EaseOutBounce(_t);
            case InterpolationType.EaseInOutBounce: return EaseInOutBounce(_t);

            default: return 0.0f;
        }
    }

    //--------------------Linear--------------------//
    float EaseLinear(float _t)
    {
        return _t;
    }


    //--------------------Custom--------------------//
    float EaseCustom(float _t)
    {
        return curve.Evaluate(_t);
    }

    //--------------------Sine--------------------//
    float EaseInSine(float _t)
    {
        return 1 - Mathf.Cos((_t * Mathf.PI) / 2);
    }
    float EaseOutSine(float _t)
    {
        return Mathf.Sin((_t * Mathf.PI) / 2);
    }
    float EaseInOutSine(float _t)
    {
        return -(Mathf.Cos(Mathf.PI * _t) - 1) / 2;
    }

    //--------------------Quad--------------------//
    float EaseInQuad(float _t)
    {
        return Mathf.Pow(_t, 2);
    }
    float EaseOutQuad(float _t)
    {
        return 1 - Mathf.Pow(1 - _t, 2);
    }
    float EaseInOutQuad(float _t)
    {
        return _t < 0.5f ? 
            2 * Mathf.Pow(_t, 2) : 
            1 - Mathf.Pow(-2 * _t + 2, 2) / 2;
    }


    //--------------------Cubic--------------------//
    float EaseInCubic(float _t)
    {
        return Mathf.Pow(_t, 3);
    }
    float EaseOutCubic(float _t)
    {
        return 1 - Mathf.Pow(1 - _t, 3);
    }
    float EaseInOutCubic(float _t)
    {
        return _t < 0.5f ? 
            4 * Mathf.Pow(_t, 3) : 
            1 - Mathf.Pow(-2 * _t + 2, 3) / 2;

    }


    //--------------------Quart--------------------//
    float EaseInQuart(float _t)
    {
        return Mathf.Pow(_t, 4);
    }
    float EaseOutQuart(float _t)
    {
        return 1 - Mathf.Pow(1 - _t, 4);
    }
    float EaseInOutQuart(float _t)
    {
        return _t < 0.5f ? 8 * Mathf.Pow(_t, 4) : 1 - Mathf.Pow(-2 * _t + 2, 4) / 2;
    }


    //--------------------Quint--------------------//
    float EaseInQuint(float _t)
    {
        return Mathf.Pow(_t, 5);
    }
    float EaseOutQuint(float _t)
    {
        return 1 - Mathf.Pow(1 - _t, 5);
    }
    float EaseInOutQuint(float _t)
    {
        return _t < 0.5f ? 16 * Mathf.Pow(_t, 5) : 1 - Mathf.Pow(-2 * _t + 2, 5) / 2;
    }


    //--------------------Expo--------------------//
    float EaseInExpo(float _t)
    {
        return Mathf.Pow(2, 10 * _t - 10);
    }

    float EaseOutExpo(float _t)
    {
        return 1 - Mathf.Pow(2, -10 * _t);
    }

    float EaseInOutExpo(float _t)
    {
        return _t < 0.5f ? Mathf.Pow(2, 20 * _t - 10) / 2 :
            (2 - Mathf.Pow(2, -20 * _t + 10)) / 2;
    }


    //--------------------Circ--------------------//
    float EaseInCirc(float _t)
    {
        return 1 - Mathf.Sqrt(1 - Mathf.Pow(_t, 2));
    }

    float EaseOutCirc(float _t)
    {
        return Mathf.Sqrt(1 - Mathf.Pow(_t - 1, 2));
    }

    float EaseInOutCirc(float _t)
    {
        return _t < 0.5f ? (1 - Mathf.Sqrt(1 - Mathf.Pow(2 * _t, 2))) / 2 :
            (Mathf.Sqrt(1 - Mathf.Pow(-2 * _t + 2, 2)) + 1) / 2;
    }

    //--------------------Back--------------------//
    float EaseInBack(float _t)
    {
        return c3 * Mathf.Pow(_t, 3) - c1 * Mathf.Pow(_t, 2);

    }

    float EaseOutBack(float _t)
    {
        return 1 + c3 * Mathf.Pow(_t - 1, 3) + c1 * Mathf.Pow(_t - 1, 2);
    }

    float EaseInOutBack(float _t)
    {
        return _t < 0.5f ?
            (Mathf.Pow(2 * _t, 2) * ((c2 + 1) * 2 * _t - c2)) / 2 :
            (Mathf.Pow(2 * _t - 2, 2) * ((c2 + 1) * (_t * 2 - 2) + c2) + 2) / 2;
    }


    //--------------------Elastic--------------------//
    float EaseInElastic(float _t)
    {
        return -Mathf.Pow(2, 10 * _t - 10) * Mathf.Sin((_t * 10 - 10.75f) * c4);
    }

    float EaseOutElastic(float _t)
    {
        return Mathf.Pow(2, -10 * _t) * Mathf.Sin((10 * _t - 0.75f) * c4) + 1;
    }

    float EaseInOutElastic(float _t)
    {
        return _t == 0 ? 0 : 
                _t == 1 ? 1 :
                _t < 0.5f ? 
                -(Mathf.Pow(2, 20 * _t - 10) * Mathf.Sin((20 * _t - 11.125f) * c5)) / 2 : 
                (Mathf.Pow(2, -20 * _t + 10) * Mathf.Sin((20 * _t - 11.125f) * c5)) / 2 + 1;
    }

    //--------------------Bounce--------------------//
    float EaseInBounce(float _t)
    {
        return 1 - EaseOutBounce(1 - _t);
    }

    float EaseOutBounce(float _t)
    {
        if (_t < 1f / d1)
        {
            return n1 * _t * _t;
        }
        else if (_t < 2f / d1)
        {
            return n1 * (_t -= 1.5f / d1) * _t + 0.75f;
        }
        else if (_t < 2.5f / d1)
        {
            return n1 * (_t -= 2.25f / d1) * _t + 0.9375f;
        }
        else
        {
            return n1 * (_t -= 2.625f / d1) * _t + 0.984375f;
        }
    }

    float EaseInOutBounce(float _t)
    {
        return _t < 0.5 ? 
            (1 - EaseOutBounce(1 - 2 * _t)) / 2 : 
            (1 + EaseOutBounce(2 * _t - 1)) / 2;
    }

}