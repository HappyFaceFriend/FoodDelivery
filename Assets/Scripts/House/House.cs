using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "House")]

public class House : ScriptableObject
{
    public string HouseName;
    public void Introduce()
    {
        Debug.Log("�� �̸� : " + HouseName);
    }
}
