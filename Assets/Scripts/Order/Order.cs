using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Order 
{
    public House destination;
    public List<Food> Foodlist = new List<Food>();
    public float timelimit = 0.0f;
}
