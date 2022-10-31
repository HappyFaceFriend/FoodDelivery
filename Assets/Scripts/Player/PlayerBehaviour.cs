using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerBehaviour : StateMachineBase
{
    [SerializeField] float _moveSpeed;
    [SerializeField] float _dashSpeed;
    [SerializeField] float _rotateSpeed;

    public FoodManager FoodManager;
    public OrderManager OrderManager;

    public float MoveSpeed { get { return _moveSpeed; } }
    public float DashSpeed { get { return _dashSpeed; } }
    public float RotateSpeed { get { return _rotateSpeed; } }

    public AttackController AttackController { get; private set; }

    private void Awake()
    {
        AttackController = GetComponent<AttackController>();

    }

    public Vector3 GetInputVector()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 vec = new Vector3(hor, 0, ver);
        if (vec.sqrMagnitude > 1)
            vec.Normalize();
        return vec;
    }
    protected override StateBase GetInitialState()
    {
        return new PlayerStates.IdleState(this);
    }
    public void OnAttackedByKid(KidBehaviour attackedKid)
    {
        ChangeState(new PlayerStates.LoseState(this));
    }
    public void OnGameClear()
    {
        ChangeState(new PlayerStates.WinState(this));
    }

    void OnTriggerEnter(Collider other)
    {
        FoodBehaviour food = other.GetComponent<FoodBehaviour>();
        HouseBehaviour house = other.GetComponent<HouseBehaviour>();

        if (food != null)
        {
            food.OnCollideWithPlayer();
            FoodManager.AddFood(food.data);
        }

        if (house != null)
        {
            for (int i = 0; i < OrderManager.orderlist.Count; i++)
            {
                if (OrderManager.orderlist[i].destination == house.getHouse())
                {
                    List<Food> templist = FoodManager.FoodList.Intersect(OrderManager.orderlist[i].Foodlist).ToList();
                    templist.Sort();
                    OrderManager.orderlist[i].Foodlist.Sort();
                    bool same = templist.SequenceEqual(OrderManager.orderlist[i].Foodlist);

                    if (same)
                    {
                        for (int j = 0; j < OrderManager.orderlist[i].Foodlist.Count; j++)
                        {
                            FoodManager.FoodList.Remove(OrderManager.orderlist[i].Foodlist[j]);
                        }
                        OrderManager.orderlist.RemoveAt(i);
                        Debug.Log("배달 완료했습니다");
                    }
                }
            }
        }
    }
}
