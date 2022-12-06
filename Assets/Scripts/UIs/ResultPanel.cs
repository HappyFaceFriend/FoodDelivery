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

    int starCount = 3;
    public void Open(int deliveredCount, int foodCount, int failCount, int starCount)
    {
        totalDeliveredText.text = deliveredCount.ToString();
        totalFoodText.text = foodCount.ToString();
        totalFailText.text = failCount.ToString();
        gameObject.SetActive(true);
        this.starCount = starCount;
    }
    public void StartStar()
    {
        StartCoroutine(StarCoroutine(starCount));
    }
    IEnumerator StarCoroutine(int starCount)
    {
        for(int i=0; i<starCount; i++)
        {
           starImages[i].sprite = filledStar;
            yield return new WaitForSeconds(0.2f);
        }
    }

}
