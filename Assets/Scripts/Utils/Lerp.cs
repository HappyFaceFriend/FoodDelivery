using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public static class Lerp
    {//https://forum.unity.com/threads/passing-ref-variable-to-coroutine.379640/
        /// <summary>
        /// Usage : yield return StartCoroutine(LerpUtils.LerpCoroutine(x => ScrollBar.value = x, originalScroll, targetScroll, 0.1f));
        /// </summary>
        /// <param name="setVar"></param>
        /// <param name="original"></param>
        /// <param name="target"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        public static IEnumerator EaseCoroutine(System.Action<float> setVar, float original, float target, float duration)
        {
            float eTime = 0f;
            while (eTime < duration)
            {
                setVar(Mathf.Lerp(original, target, eTime / duration));
                yield return null;
                eTime += Time.deltaTime;
            }
            setVar(target);
        }
    }

}