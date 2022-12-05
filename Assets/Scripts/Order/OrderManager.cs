using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public List<Order> orderlist = new List<Order>();

    [SerializeField] LevelManager levelManager;
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

    public bool StopSystem { get; set; } = false;
    
    /*int count = 0;
    int[] housenumber = { 0, 1, 2, 3, 4, 5 };

    int makeDest()
    {
        if(count%6 == 0)
        {
            Utils.Random.Shuffle(housenumber);
            return housenumber[count % 6];
        }
        count++;
        return housenumber[count % 6];
    }*/


    void MakeOrder()
    {
        Order data = new Order();
        /*data.destination = houselist[makeDest()];*/

        if(orderlist.Count == 0)
        {
            int houseCount = Random.Range(0, 6);
            data.destination = houselist[houseCount];
            houselist.Remove(houselist[houseCount]);
        }
        else
        {
            int houseCount = Random.Range(0, 6- orderlist.Count);
            data.destination = houselist[houseCount];
            houselist.Remove(houselist[houseCount]);
        }

        //가중치 적용
        float r = Random.Range(0f, 1f);
        int foodCount = 1;
        if (r < 0.6f)
            foodCount = 1;
        else if (r < 0.8f)
            foodCount = 2;
        else
            foodCount = 3;

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
        if (StopSystem)
            return;
        // 주문 들어오는 시간
        if (updateTime > freq)
        {
            MakeOrder();
            //Debug.Log(orderlist.Count + "개의 주문받았습니다");
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
                    levelManager.OnOrderFail();
                    houselist.Add(orderlist[i].destination);
                    for (int j =0; j < orderlist[i].Foodlist.Count; j++)
                    {
                        orderlist[i].Foodlist[j].foodNum--;
                    }
                }
            }
        }
    }
    public void CompleteOrder(Order order)
    {
        levelManager.OnOrderDeliver(order.Foodlist.Count);
        ordersPanel.RemoveOrderSlot(order);
        orderlist.Remove(order);
        houselist.Add(order.destination);
    }
}
