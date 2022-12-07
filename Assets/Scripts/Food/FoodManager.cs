using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    public List<Food> FoodList;
    int count = 0;

    [SerializeField] Inventory inventory;

    public int getCount()
    {
        return count;
    }
    
    public void AddFood(Food obj) 
    {
        if (FoodList.Count >= 10)
            return;
        inventory.Add(obj);
        FoodList.Add(obj);
        count++;
    }
    
    public void DeleteFood(Food obj)
    {
        inventory.Remove(obj);
        Debug.Log(obj.Name + "�� player�� �Ҿ����ϴ�");
        FoodList.Remove(obj);
    }
}
