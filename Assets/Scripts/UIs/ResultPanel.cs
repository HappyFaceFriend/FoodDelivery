using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResultPanel : MonoBehaviour
{
    [SerializeField] Image[] starImages;
    [SerializeField] Sprite filledStar;
    [SerializeField] Sprite emptyStar;

    [SerializeField] TextMeshProUGUI totalDeliveredText;
    [SerializeField] TextMeshProUGUI totalFoodText;
    [SerializeField] TextMeshProUGUI totalFailText;

    public void Init(int deliveredCount, int foodCount, int failCount)
    {
        totalDeliveredText.text = deliveredCount.ToString();
        totalFoodText.text = foodCount.ToString();
        totalFailText.text = failCount.ToString();
    }

}
