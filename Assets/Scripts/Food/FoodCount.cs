using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FoodCount : MonoBehaviour
{
    public GameObject[] _foods;

    // Scene 음식 개수
    public int total = 0;
    public int sodaCount = 0;
    public int lolipopCount = 0;
    public int cakeCount = 0;
    public int pizzaCount = 0;
    public int hotdogCount = 0;

    // 플레이어가 가진 음식 개수
    public int getTotal = 0;
    public int getSoda = 0;
    public int getLolipop = 0;
    public int getCake = 0;
    public int getPizza = 0;
    public int getHotdog = 0;

    public TextMeshProUGUI totalText;
    public TextMeshProUGUI sodaText;
    public TextMeshProUGUI lolipopText;
    public TextMeshProUGUI cakeText;
    public TextMeshProUGUI hotdogText;
    public TextMeshProUGUI pizzaText;

    public TextMeshProUGUI getTotalText;
    public TextMeshProUGUI getSodaText;
    public TextMeshProUGUI getLolipopText;
    public TextMeshProUGUI getCakeText;
    public TextMeshProUGUI getHotdogText;
    public TextMeshProUGUI getPizzaText;

    private void Awake()
    {
        _foods = GameObject.FindGameObjectsWithTag("Food");
        for (int i = 0; i < _foods.Length; i++)
        {
            FoodBehaviour food = _foods[i].GetComponent<FoodBehaviour>();
            if (food.type.ToString().Equals("Soda"))
                sodaCount++;
            else if (food.type.ToString().Equals("Cake"))
                cakeCount++;
            else if (food.type.ToString().Equals("Lolipop"))
                lolipopCount++;
            else if (food.type.ToString().Equals("Hotdog"))
                hotdogCount++;
            else if (food.type.ToString().Equals("Pizza"))
                pizzaCount++;
        }
        total = sodaCount + lolipopCount + cakeCount + pizzaCount + hotdogCount;
        totalText.SetText(total.ToString());
        sodaText.SetText(sodaCount.ToString());
        lolipopText.SetText(lolipopCount.ToString());
        cakeText.SetText(cakeCount.ToString());
        pizzaText.SetText(pizzaCount.ToString());
        hotdogText.SetText(hotdogCount.ToString());
        getSoda = 0;
    }
    // Update is called once per frame
    void Update()
    {
    }
}
