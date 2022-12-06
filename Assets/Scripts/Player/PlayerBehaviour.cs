using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerBehaviour : StateMachineBase
{
    [SerializeField] float _moveSpeed;
    [SerializeField] float _dashSpeed;
    [SerializeField] float _rotateSpeed;
    [SerializeField] float _stunDuration;

    [SerializeField] GameObject _foodEffect;
    [SerializeField] GameObject _deliveryEffect;

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
        if (CurrentState.GetType() != typeof(KidStates.LoseState) ||
            CurrentState.GetType() != typeof(KidStates.WinState))
        {
            SoundManager.Instance.PlaySound(SoundManager.Instance.HittedSound); 
            ChangeState(new PlayerStates.StunnedState(this, _stunDuration));
        }
    }
    public void OnGameClear()
    {
        ChangeState(new PlayerStates.WinState(this));
    }

    private void OnCollisionEnter(Collision collision)
    {
        FoodBehaviour food = collision.transform.GetComponentInParent<FoodBehaviour>();
        if (food != null)
        {
            Instantiate(_foodEffect, food.transform.position, _foodEffect.transform.rotation);
            food.OnCollideWithPlayer();

            SoundManager.Instance.PlaySound(SoundManager.Instance.GemSound);
            FoodManager.AddFood(food.data);
        }
        HouseBehaviour house = collision.transform.GetComponentInParent<HouseBehaviour>();

        if (house != null)
        {
            for (int i = 0; i < OrderManager.orderlist.Count; i++)
            {
                if (OrderManager.orderlist[i].destination == house.getHouse())
                {
                    List<Food> templist = FoodManager.FoodList.Intersect(OrderManager.orderlist[i].Foodlist).ToList();
                    templist.Sort();
                    OrderManager.orderlist[i].Foodlist.Sort((a,b)=>string.Compare(a.Name,b.Name));
                    bool same = templist.SequenceEqual(OrderManager.orderlist[i].Foodlist);

                    if (same)
                    {
                        for (int j = 0; j < OrderManager.orderlist[i].Foodlist.Count; j++)
                        {
                            FoodManager.DeleteFood(OrderManager.orderlist[i].Foodlist[j]);
                        }
                        OrderManager.CompleteOrder(OrderManager.orderlist[i]);
                        Instantiate(_deliveryEffect, transform.position, _deliveryEffect.transform.rotation);
                        Debug.Log("배달 완료했습니다");
                    }
                }
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        CarBehaviour car = other.GetComponent<CarBehaviour>();
        if (car != null)
        {
            car.OnCollideWithPlayer();
        }
    }
}
