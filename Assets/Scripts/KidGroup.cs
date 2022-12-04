using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidGroup : MonoBehaviour
{
    [SerializeField] List<KidBehaviour> kids;
    [SerializeField] FoodBehaviour food;
    [SerializeField] FoodBehaviour foodPrefab;

    public void Awake()
    {
        foreach (KidBehaviour kid in kids)
            kid.Group = this;
    }

    public void AlertAllKids(KidBehaviour observer)
    {
        foreach(KidBehaviour kid in kids)
        {
            if(kid != observer)
                kid.AlertByMate();
        }
    }
}
