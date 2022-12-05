using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float leftTime = 60f;
    [SerializeField] OrderManager orderManager;
    [SerializeField] Transform gameOverPanel;
    [SerializeField] ResultPanel resultPanel;

    [SerializeField] int[] starLimit;

    int successCount = 0;
    int failCount = 0;
    int foodCount = 0;

    private void Start()
    {
        StartCoroutine(RoundCoroutine());
    }

    IEnumerator RoundCoroutine()
    {
        //���� ���� �ִϸ��̼�

        //���� ����! 
        //ordermanager.start
        orderManager.StopSystem = false;
        //�ð� ��� ����
        while(leftTime > 0)
        {
            leftTime -= Time.deltaTime;
            yield return null;
        }
        leftTime = 0f;
        orderManager.StopSystem = true;
        //��� �����ְ� �� ��ȯ
        int star = 1;
        if (successCount > starLimit[2])
            star = 3;
        else if (successCount > starLimit[1])
            star = 2;
        else if (successCount > starLimit[0])
            star = 1;
        else
            star = 0;
        resultPanel.Init(successCount, foodCount, failCount, star);
        gameOverPanel.gameObject.SetActive(true);
        yield return null;
    }

    public void OnOrderFail()
    {
        failCount++;
    }
    public void OnOrderDeliver(int foodCount)
    {
        successCount++;
        this.foodCount += foodCount;
    }

}
