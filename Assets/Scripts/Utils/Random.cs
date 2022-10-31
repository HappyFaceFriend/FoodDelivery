using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public static class Random
    {
        /// <summary>
        /// Shuffles the list with Fisher-Yates algorithm
        /// </summary>
        /// <param name="list">List to shuffle.</param>
        public static void Shuffle<T>(List<T> list)
        {
            for (int i = list.Count - 1; i >= 1; i--)
            {
                int r = UnityEngine.Random.Range(0, i + 1);
                T temp = list[i];
                list[i] = list[r];
                list[r] = temp;
            }
        }
        public static void Shuffle<T>(T [] list)
        {
            for (int i = list.Length - 1; i >= 1; i--)
            {
                int r = UnityEngine.Random.Range(0, i + 1);
                T temp = list[i];
                list[i] = list[r];
                list[r] = temp;
            }
        }
        public static int RandomIndex<T>(List<T> list)
        {
            return UnityEngine.Random.Range(0, list.Count);
        }
        public static T RandomElement<T>(List<T> list)
        {
            return list[UnityEngine.Random.Range(0, list.Count)];
        }
        public static T[] RandomElements<T>(T [] array, int count)
        { 
            int [] indicies = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
                indicies[i] = i;
            Shuffle(indicies);
            T [] result = new T[count];
            for(int i=0; i<count; i++)
                result[i] = array[indicies[i]];
            return result;
        }
        public static Vector2 RandomVector(float minX, float maxX, float minY, float maxY)
        {
            return new Vector2(UnityEngine.Random.Range(minX, maxX), UnityEngine.Random.Range(minY, maxY));
        }
        public static Vector2 RandomUnitVector2()
        {
            float angle = UnityEngine.Random.Range(0, Mathf.PI * 2);
            return new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        }
        public static Vector3 RandomVector(Vector3 minVec, Vector3 maxVec)
        {
            return new Vector3(UnityEngine.Random.Range(minVec.x, maxVec.x),
                UnityEngine.Random.Range(minVec.y, maxVec.y), UnityEngine.Random.Range(minVec.z, maxVec.z));
        }
    }

}