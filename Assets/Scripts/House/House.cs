using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "House")]

public class House : ScriptableObject
{
    public string HouseName;
    public Sprite Icon;
    public bool ordercheck = true;
    public void Introduce()
    {
        Debug.Log("Áý ÀÌ¸§ : " + HouseName);
    }
}
