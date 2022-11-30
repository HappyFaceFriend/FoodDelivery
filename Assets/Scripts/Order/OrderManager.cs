using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public List<Order> orderlist = new List<Order>();


    [SerializeField] float updateTime = 0.0f;
    [SerializeField] float freq = 30.0f;

    [SerializeField] List<House> houselist;
    [SerializeField] List<Food> foodlist;

    [SerializeField] OrdersPanel ordersPanel;


    [Header("Test")]
    [SerializeField] bool stopOrderTime = false;
    [SerializeField] bool stopTimeCount = false;
    void MakeOrder()
    {
        Order data = new Order();
        int houseNum = Random.Range(1, 7);
        data.destination = houselist[houseNum - 1];


        int foodCount = Random.Range(1, 4); 
        data.timelimit = 20.0f * foodCount;


        int[] number = new int[foodlist.Count];
        for(int i = 0; i < foodlist.Count; i++)
        {
            number[i] = i;
        }
        int[] foodnumber = Utils.Random.RandomElements(number, foodCount);

        for (int i = 0; i < foodCount; i++) 
        {
            data.Foodlist.Add(foodlist[foodnumber[i]]);
        }

        orderlist.Add(data);

        ordersPanel.AddOrderSlot(data);
    }

    void Update() // freq 시간마다 주문 생성 
    {

        if (updateTime > freq)
        {
            MakeOrder();
            Debug.Log(orderlist.Count + "개의 주문받았습니다");
            updateTime = 0.0f;
        }

        else
        {
            if(!stopOrderTime)
               updateTime += Time.deltaTime;
        }

        if(orderlist.Count > 0)
        {
            for(int i =0; i < orderlist.Count; i++)
            {
                if(!stopTimeCount)
                    orderlist[i].timelimit -= Time.deltaTime;
                if (orderlist[i].timelimit <= 0)
                {
                    ordersPanel.RemoveOrderSlot(orderlist[i]);
                    orderlist.RemoveAt(i);
                }
            }
        }
    }
    public void CompleteOrder(Order order)
    {
        ordersPanel.RemoveOrderSlot(order);
        orderlist.Remove(order);
    }
}
