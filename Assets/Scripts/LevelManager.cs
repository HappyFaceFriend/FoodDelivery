using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(RoundCoroutine());
    }

    IEnumerator RoundCoroutine()
    {
        //���� ���� �ִϸ��̼�

        //���� ����! 
        //ordermanager.start

        //�ð� ��� ����

        //�ð� �ٵǸ� ���� ����
        //
        //��� �����ְ� �� ��ȯ

        yield return null;
    }

}
