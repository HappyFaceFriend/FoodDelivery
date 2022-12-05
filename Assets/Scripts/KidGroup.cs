using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GroupState
{
    Patrol, Follow, Returning
}
public class KidGroup : MonoBehaviour
{
    [SerializeField] List<KidBehaviour> kids;
    [SerializeField] float foodRegenTime=5;
    [SerializeField] FoodBehaviour food;
    [SerializeField] FoodBehaviour foodPrefab;
    [SerializeField] List<Transform> targetPoints;
    List<int> targetOwned;

    public GroupState State { get; private set; }

    Vector3 foodPosition;

    public Transform GetRandomTargetPoint(Transform returningPoint)
    {
        List<int> freeTargets = new List<int>();
        for (int i = 0; i < targetPoints.Count; i++)
        {
            if (!targetOwned.Contains(i))
                freeTargets.Add(i);
        }
        if(returningPoint != null)
            targetOwned.Remove(targetPoints.FindIndex(x=>x==returningPoint));

        int idx = Utils.Random.RandomElement(freeTargets);

        targetOwned.Add(idx);
        return targetPoints[idx];
    }
    public void Awake()
    {
        foreach (KidBehaviour kid in kids)
            kid.Group = this;
        foodPosition = food.transform.position;
        targetOwned = new List<int>();
    }
    public void StartReturn(KidBehaviour startKid)
    {
        State = GroupState.Returning;
    }
    public void AlertAllKids(KidBehaviour observer)
    {
            State = GroupState.Follow;
    }

    bool spawningFood = false;
    private void Update()
    {
        if (food == null && !spawningFood)
        {
            StartCoroutine(SpawnFood());
        }
        if(State == GroupState.Returning)
        {
            bool allReturned = true;
            foreach (KidBehaviour kid in kids)
            {
                if (!(kid.CurrentState is KidStates.WaitReturnState))
                    allReturned = false;
            }
            if (allReturned)
            {
                State = GroupState.Patrol;
            }

        
        }
    }
    IEnumerator SpawnFood()
    {
        spawningFood = true;
        yield return new WaitForSeconds(foodRegenTime);
        FoodBehaviour newFood = Instantiate(foodPrefab, transform);
        food = newFood;
        food.transform.position = foodPosition;
    }

}
