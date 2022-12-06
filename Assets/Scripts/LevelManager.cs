using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float leftTime = 60f;
    [SerializeField] OrderManager orderManager;
    [SerializeField] ResultPanel resultPanel;
    [SerializeField] Slider timer;
    [SerializeField] Gradient timerGradient;

    [SerializeField] int[] starLimit;

    int successCount = 0;
    int failCount = 0;
    int foodCount = 0;

    Image timerFill;
    private void Awake()
    {
        timerFill = timer.fillRect.GetComponent<Image>();
        timer.maxValue = leftTime;
        timer.value = leftTime;
    }
    private void Start()
    {
        StartCoroutine(RoundCoroutine());
    }

    IEnumerator RoundCoroutine()
    {
        //게임 시작 애니메이션

        //게임 시작! 
        //ordermanager.start
        orderManager.StopSystem = false;
        //시간 계쏙 측정
        while(leftTime > 0)
        {
            leftTime -= Time.deltaTime;
            UpdateTimer();
            yield return null;
        }
        leftTime = 0f;
        orderManager.StopSystem = true;
        //결과 보여주고 씬 전환
        int star = 1;
        if (successCount > starLimit[2])
            star = 3;
        else if (successCount > starLimit[1])
            star = 2;
        else if (successCount > starLimit[0])
            star = 1;
        else
            star = 0;

        GameObject.FindObjectOfType<PlayerBehaviour>().OnGameClear();
        foreach (KidBehaviour kid in GameObject.FindObjectsOfType<KidBehaviour>())
            kid.OnGameClear();

        resultPanel.Open(successCount, foodCount, failCount, star);
        SoundManager.Instance.PlaySound(SoundManager.Instance.OverSound);
        yield return null;
    }
    public void OnOrderFail()
    {
        failCount++;
        SoundManager.Instance.PlaySound(SoundManager.Instance.OrderFailSound, 0.4f);
    }
    public void OnOrderDeliver(int foodCount)
    {
        successCount++;
        this.foodCount += foodCount;
        SoundManager.Instance.PlaySound(SoundManager.Instance.OrderSuccessSound, 0.65f);
    }
    void UpdateTimer()
    {
        timer.value = leftTime;
        timerFill.color = timerGradient.Evaluate(1 - timer.normalizedValue);
    }

}
