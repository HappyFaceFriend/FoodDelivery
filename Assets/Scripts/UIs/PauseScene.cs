using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScene : MonoBehaviour
{
    public static bool IsPause = true;

    private void Update()
    {
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        IsPause = true;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        IsPause = false;
    }
}
