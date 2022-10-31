using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Food")]

public class Food : ScriptableObject 
{
    public string Name;
    
    public void Introduce()
    {
        Debug.Log("���� �̸� : " + Name);
    }
}
