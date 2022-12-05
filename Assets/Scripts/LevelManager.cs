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
        //게임 시작 애니메이션

        //게임 시작! 
        //ordermanager.start

        //시간 계쏙 측정

        //시간 다되면 게임 종료
        //
        //결과 보여주고 씬 전환

        yield return null;
    }

}
