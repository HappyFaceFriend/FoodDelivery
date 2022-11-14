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

        Debug.Log(data.Foodlist[0]);
        Debug.Log("����" + data.timelimit + "�� �ȿ�");
        Debug.Log(data.destination.HouseName + "���� ������ּ���");
    }

    void Update() // freq �ð����� �ֹ� ���� 
    {

        if (updateTime > freq)
        {
            MakeOrder();
            Debug.Log(orderlist.Count + "���� �ֹ��޾ҽ��ϴ�");
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
                    orderlist.RemoveAt(i);
            }
        }
    }
}
