using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public List<Order> orderlist = new List<Order>();


    [SerializeField] float updateTime = 0.0f;
    [SerializeField] float freq = 30.0f;
    [SerializeField] float freqMinus = 5.0f;
    [SerializeField] float freqPlus = -5.0f;
    [SerializeField] float orderlimittime = 20.0f;

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
        if(houselist[houseNum - 1].ordercheck == false)
        {
            while (houselist[houseNum - 1].ordercheck == true)
            {
                houseNum = Random.Range(1, 7);
            }
        }
        data.destination = houselist[houseNum - 1];
        houselist[houseNum - 1].ordercheck = false;
        Debug.Log(houselist[houseNum - 1].ordercheck);

        //가중치 적용
        int foodCount = Random.Range(1, 6);
        if (foodCount == 1 || foodCount == 2) foodCount = 1;
        else if (foodCount == 3 || foodCount == 4) foodCount = 2;
        else foodCount = 3;
        data.timelimit = orderlimittime + foodCount*5;


        int[] number = new int[foodlist.Count];

        for(int i = 0; i < foodlist.Count; i++)
        {
            number[i] = i;
        }

        Utils.Random.Shuffle(number);
        int count = 0;
        for (int i = 0; i < foodCount; i++) 
        {
            if(foodlist[number[i]].foodNum > 1)
            {
                count++;
            }
            else
            {
                data.Foodlist.Add(foodlist[number[count]]);
                count++;
            }
        }

        orderlist.Add(data);
        ordersPanel.AddOrderSlot(data);
    }

    void Update() // freq 시간마다 주문 생성 
    {
        // 주문 들어오는 시간
        if (updateTime > freq)
        {
            MakeOrder();
            Debug.Log(orderlist.Count + "개의 주문받았습니다");
            if(orderlist.Count > 1) updateTime = freqPlus;
            else if(orderlist.Count > 7) updateTime = -5000.0f;
            else updateTime = freqMinus;
        }

        else
        {
             if(!stopOrderTime) updateTime += Time.deltaTime; 
        }

        if(orderlist.Count > 0)
        {
            for(int i = 0; i < orderlist.Count; i++)
            {
                if(!stopTimeCount)
                    orderlist[i].timelimit -= Time.deltaTime;
                if (orderlist[i].timelimit <= 0)
                {
                    ordersPanel.RemoveOrderSlot(orderlist[i]);
                    orderlist.RemoveAt(i);
                    orderlist[i].destination.ordercheck = true;
                    for(int j =0; j < orderlist[i].Foodlist.Count; j++)
                    {
                        orderlist[i].Foodlist[j].foodNum--;
                    }
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
