using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    public List<Food> FoodList;
    int count = 0;

    public int getCount()
    {
        return count;
    }
    
    public void AddFood(Food obj) 
    {
        FoodList.Add(obj);
        count++;
    }
    
    public void DeleteFood(Food obj)
    {
        Debug.Log(obj.Name + "을 player가 잃었습니다");
        FoodList.Remove(obj);
    }
}
