using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ease
{
    public class Sine
    {
        public static event Action<float> Sack = (x) => { };
        static IEnumerator EaseInSine(IFormattable f, float duration = 0.0f)
        {
            float pastTime = 0.0f, val = 0.0f;

            while (pastTime < duration)
            {
                val = 1 - Mathf.Cos((pastTime * Mathf.PI) / 2);
            
                pastTime += Time.deltaTime;
            
                Sack.Invoke(val);
            
                //transform.localScale = new Vector3(val, val, val);
            
                yield return new WaitForEndOfFrame();
            }

            //val = 1.0f;
            //transform.position = lastPosition + new Vector3(0, 0, val);

            yield return null;
        }

        static IEnumerator EaseOutSine()
        {
            float pastTime = 0.0f, val = 0.0f;

            //while (pastTime < duration)
            //{
            //    val = Mathf.Sin((pastTime * Mathf.PI) / 2);
            //
            //    pastTime += Time.deltaTime;
            //
            //    transform.localScale = new Vector3(val, val, val);
            //
            //    yield return new WaitForEndOfFrame();
            //}
            //
            //val = 1.0f;
            //transform.position = lastPosition + new Vector3(0, 0, val);

            yield return null;
        }

        static IEnumerator EaseInOutSine()
        {
            float pastTime = 0.0f, val = 0.0f;

            //while (pastTime < duration)
            //{
            //    val = -(Mathf.Cos(Mathf.PI * pastTime) - 1) / 2;
            //
            //    pastTime += Time.deltaTime;
            //
            //    transform.position = lastPosition + new Vector3(0, 0, val);
            //
            //    yield return new WaitForEndOfFrame();
            //}

            //val = 1.0f;
            //transform.position = lastPosition + new Vector3(0, 0, val);

            yield return null;
        }
    }
}
