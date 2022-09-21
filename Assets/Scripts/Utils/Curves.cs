using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public static class Curves
    {
        public static float EaseIn(float x)
        {
            return x * x;
        }
        public static float EaseOut(float x)
        {
            x = x - 1;
            return 1 - x * x;
        }
        public static float Linear(float x)
        {
            return x;
        }
    }

}