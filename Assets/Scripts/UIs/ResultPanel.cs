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
    [SerializeField] TextMeshProUGUI titleText;
    [SerializeField] TextMeshProUGUI timeupText;


    int starCount = 3;
    public void Open(int deliveredCount, int foodCount, int failCount, int starCount, bool died = false)
    {
        if (died)
            timeupText.text = "You died...";
        totalDeliveredText.text = deliveredCount.ToString();
        totalFoodText.text = foodCount.ToString();
        totalFailText.text = failCount.ToString();
        gameObject.SetActive(true);
        this.starCount = starCount;
        if (starCount >= 2)
            titleText.text = "Game Clear!";
        
    }
    public void StartStar()
    {
        StartCoroutine(StarCoroutine(starCount));
        if (starCount >= 2)
            SoundManager.Instance.PlaySound(SoundManager.Instance.ResultSound);
    }
    IEnumerator StarCoroutine(int starCount)
    {
        for(int i=0; i<starCount; i++)
        {
            yield return new WaitForSeconds(0.5f);
            starImages[i].sprite = filledStar;

            SoundManager.Instance.PlaySound(SoundManager.Instance.HittedSound);
        }
    }

}
